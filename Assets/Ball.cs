using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    Vector3 initialPos;
    public string hitter;

    int playerScore;
    int botScore;

    public bool playing = true;
    [SerializeField] Text playerScoretext;
    [SerializeField] Text botScoretext;


    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        playerScore = 0;
        botScore = 0;


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Out"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            GameObject.Find("player").GetComponent<player>().Reset();

            if (playing)
            {
                if (hitter == "player")
                {
                    playerScore++;
                }
                else if (hitter == "bot")
                {
                    botScore++;
                }
                playing = false;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Out") && playing)
        {
            if(hitter == "player")
            {
                botScore++;
            }else if(hitter == "bot")
            {
                playerScore++;
            }
            playing = false;

        }
    }

}
