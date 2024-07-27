using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ball : MonoBehaviour
{
    Vector3 initialPos;
    public string hitter;

    int playerScore;
    int botScore;

    public bool playing = true;

    [SerializeField] TextMeshProUGUI playerScoretext;
    [SerializeField] TextMeshProUGUI botScoretext;


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
                updateScores();

            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Out") && playing)
        {
            if (hitter == "player")
            {
                botScore++;
            } else if (hitter == "bot")
            {
                playerScore++;
            }
            playing = false;
            updateScores();

        }
    }

    void updateScores()
    {
        playerScoretext.text = "Player : " + playerScore;
        botScoretext.text = "Bot : " + botScore;

    }

}
 