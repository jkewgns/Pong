using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAIGoal : MonoBehaviour
{
    public bool isPlayer1Goal;
    private IAIGameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("IAIGameManager")?.GetComponent<IAIGameManager>();

        if (gameManager == null)
        {
            Debug.LogError("AIGameManager not found! Make sure the AIGameManager object exists in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (gameManager == null)
            {
                Debug.LogError("AIGameManager is missing! Cannot update the score.");
                return;
            }

            if (!isPlayer1Goal)
            {
                Debug.Log("Player 1 Scored...");
                gameManager.Player1Scored();
            }
            else
            {
                Debug.Log("Player 2 Scored...");
                gameManager.Player2Scored();
            }
        }
    }
}
