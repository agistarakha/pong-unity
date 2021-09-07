using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float speed = 50.0f;
    private Rigidbody2D rigidBody2D;

    public float xInitialForce = 50;
    public float yInitialForce = 15;
    private Vector2 trajectoryOrigin;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        RestartGame();
        trajectoryOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ResetBall()
    {

        transform.position = Vector2.zero;
        rigidBody2D.velocity = Vector2.zero;
    }
    void PushBall()
    {
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);
        float randomDirection = Random.Range(0, 2);
        if (randomDirection < 1.0f)
        {
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce).normalized * speed);
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce).normalized * speed);
        }
    }

    public void RestartGame()
    {
        ResetBall();
        Invoke("PushBall", 2);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
