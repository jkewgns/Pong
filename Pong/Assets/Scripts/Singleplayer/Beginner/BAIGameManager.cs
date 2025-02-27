using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BAIGameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player 1")]
    public GameObject player1Paddle;
    public GameObject player1Goal;

    [Header("Player 2")]
    public GameObject player2Paddle;
    public GameObject player2Goal;

    [Header("Score UI")]
    public GameObject Player1Text;
    public GameObject Player2Text;

    private int Player1Score;
    private int Player2Score;

    void Start()
    {
        if (ball == null)
            ball = GameObject.FindGameObjectWithTag("Ball");

        if (player1Paddle == null)
            player1Paddle = GameObject.FindGameObjectWithTag("Player1Paddle");

        if (player2Paddle == null)
            player2Paddle = GameObject.FindGameObjectWithTag("Player2Paddle");
    }

    public void Player1Scored()
    {
        Player1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
        ResetPosition();
    }

    public void Player2Scored()
    {
        Player2Score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
        ResetPosition();
    }

    private void ResetPosition()
    {
        if (ball != null)
            ball.GetComponent<Ball>().Reset();
        else
            Debug.LogError("Ball reference is missing in AIGameManager!");

        if (player1Paddle != null)
            player1Paddle.GetComponent<Paddle>().Reset();
        else
            Debug.LogError("Player 1 Paddle reference is missing in AIGameManager!");

        if (player2Paddle != null)
        {
            BAIPaddle aiPaddle = player2Paddle.GetComponent<BAIPaddle>();
            if (aiPaddle != null)
            {
                aiPaddle.Reset();
            }
            else
            {
                Debug.LogError("Player 2 Paddle is missing the AIPaddle script!");
            }
        }
        else
        {
            Debug.LogError("Player 2 Paddle reference is missing in AIGameManager!");
        }
    }
}
