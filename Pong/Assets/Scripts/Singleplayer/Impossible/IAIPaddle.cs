using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAIPaddle : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    private GameObject ball;

    private float aiReactionTime;
    private float nextMoveTime = 0f;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        aiReactionTime = Random.Range(0.05f, 0.1f); // Set initial random reaction time
        //Beginner AI = 0.4f - 0.5f
        //Normal AI = 0.25f - 0.3f
        //Hard AI = 0.15f - 0.2f;
        //Impossible AI = 0.05f - 0.1f
    }

    void Update()
    {
        if (ball == null)
        {
            Debug.LogError("Ball not found! Make sure the Ball has the correct tag.");
            return;
        }

        if (Time.time >= nextMoveTime)
        {
            float targetY = ball.transform.position.y;
            float paddleY = transform.position.y;

            float moveDirection = Mathf.Clamp(targetY - paddleY, -1, 1);

            transform.position += new Vector3(0, moveDirection * speed * Time.deltaTime, 0);

            rb.velocity = new Vector2(0, moveDirection * speed);

            nextMoveTime = Time.time + aiReactionTime;

            aiReactionTime = Random.Range(0.05f, 0.1f); // Randomize reaction time each update, change this with aiReactionTime so it's the same
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
