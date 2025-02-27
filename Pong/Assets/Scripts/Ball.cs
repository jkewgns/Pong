using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public float speedIncrease = 1f;
    public float maxSpeed = 50f;
    public Rigidbody2D rb;
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Launch();
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }
    
    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody != null)
        {
            float currentSpeed = rb.velocity.magnitude;
            float newSpeed = Mathf.Min(currentSpeed + speedIncrease, maxSpeed);

            rb.velocity = rb.velocity.normalized * newSpeed;

            SoundManager.instance.PlayPaddleHit();
        }
        else
        {
            SoundManager.instance.PlayWallHit();
        }
    }
}
