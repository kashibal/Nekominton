using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    float speed = 3;
    Animator animator;
    public Transform ball;
    public Transform aimTarget;
    float force = 13;

    public Transform[] targets;

    Vector3 targetPosition;

    ShotManager shotManager;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        animator = GetComponent<Animator>();
        shotManager = GetComponent<ShotManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        targetPosition.x = ball.position.x;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    Vector3 PickTarget()
    {
        int randomValue = Random.Range(0, targets.Length);
        return targets[randomValue].position;
    }
    Shot PickShot()
    {
        int randomValue = Random.Range(0, 2);
        if(randomValue == 0)
        {
            return shotManager.topSpin;
        }
        else
        {
            return shotManager.flat;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Shot currentShot = PickShot();

            Vector3 dir = PickTarget() - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);

            Vector3 ballDir = ball.position - transform.position;
            if (ballDir.x >= 0)
            {
                animator.Play("forehand");
            }
            else
            {
                animator.Play("backhand");
            }
        }
    }
}
