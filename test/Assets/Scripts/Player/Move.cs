using UnityEngine;

public class Move : MonoBehaviour
{

    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 newPosition = transform.position;
        
        newPosition.x += horizontalInput * 10f * Time.deltaTime;
        newPosition.y += verticalInput * 10f * Time.deltaTime;

        transform.position = newPosition;

        if(horizontalInput != 0 || verticalInput != 0)
        {
            animator.SetBool("IsWalking", true);
        }

        else
        {
            animator.SetBool("IsWalking", false);
        }


    }
}
