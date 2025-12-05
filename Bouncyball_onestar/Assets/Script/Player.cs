using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed = 4;
    public float jumpForce = 3;
    public GameObject panel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        rb.linearVelocityX = h * moveSpeed;

        if (transform.position.y < -5)
        {
            rb.linearVelocity = Vector2.zero;
            transform.position = new Vector3(-7.48f, -2.42f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            transform.position = new Vector3(-7.48f, -2.42f);
        }

        else if ( collision.gameObject.CompareTag("finish"))
        {
            Time.timeScale = 0;
            panel.SetActive(true);
        }

        else
        {
            Vector2 currentVelocity = rb.linearVelocity;
            rb.linearVelocity = new Vector2(currentVelocity.x, jumpForce);
        }
    }
}
