using UnityEngine;

public class BallController : MonoBehaviour
{
    public float jumpForce = 5f;
    public float moveSpeed = 5f;
    public float doubleTapTimeThreshold = 0.2f;

    Rigidbody2D rb;
    Vector2 initialPosition;
    float lastTapTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastTapTime < doubleTapTimeThreshold)
            {
                Disappear();
            }
            else
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (mousePosition.x < transform.position.x - 0.5f)
                {
                    MoveLeft();
                }
                else if (mousePosition.x > transform.position.x + 0.5f)
                {
                    MoveRight();
                }
                else
                {
                    Jump();
                }
            }
            lastTapTime = Time.time;
        }
    }

    void MoveLeft()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }

    void MoveRight()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void Disappear()
    {
        gameObject.SetActive(false);
    }

    public void ResetBallPosition()
    {
        transform.position = initialPosition;
        rb.velocity = Vector2.zero;
    }
}
