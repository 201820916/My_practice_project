using UnityEngine;

public class Move_player : MonoBehaviour
{
    public float speed = 10f;

    public float minX = -7.0f;
    public float maxX = 7.0f;


    void Start()
    {

    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float movement = horizontalInput * speed * Time.deltaTime;

        Vector3 newPosition = transform.position;
        newPosition.x += movement;


        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();

            // [1] ���� ��� (������ ����)
            float hitPoint = collision.transform.position.x - transform.position.x;

            // [2] �߿�! ���� ���� ������ �ִ� '������ �ӷ�(Speed)'�� ������ �Ӵϴ�.
            // (������ �ٲٱ� ���� ������)
            float oldSpeed = ballRb.linearVelocity.magnitude;

            // [3] ���ο� ������ ����ϴ�.
            Vector2 newDirection = new Vector2(hitPoint * 5.0f, ballRb.linearVelocity.y);

            // [4] �ٽ� �ذ�å! 
            // ����(newDirection)�� ����ȭ(.normalized)�ؼ� ���� 1¥�� ȭ��ǥ�� ���� ��,
            // �Ʊ� �����ص� ���� �ӵ�(oldSpeed)�� �����ݴϴ�.
            ballRb.linearVelocity = newDirection.normalized * oldSpeed;

            // (����: ���� ���� ���� �������� �� ���ٸ� oldSpeed ��� ������ ��(��: 10.0f)�� �־ �˴ϴ�.)
        }
    }
}