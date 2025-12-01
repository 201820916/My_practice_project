using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10.0f; // �߻� �ӵ� (500�� AddForce��, velocity�� 10 ������ ����)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // ���� ���� ��ġ�� ������ �߾� �ϴ����� ��� �ʹٸ� �ּ� ����
        // transform.position = new Vector3(0, -3.5f, 0);

        Launch();
    }

    void Launch()
    {
        // X: -0.5 ~ 0.5 (�ణ ���� or ������ ����)
        // Y: 1.0 (������ ����)
        float x = Random.Range(-0.5f, 0.5f);
        float y = 1.0f;

        Vector2 direction = new Vector2(x, y).normalized;

        // �ӵ�(Velocity)�� ���� �����Ͽ� �����ϰ� �����̵��� ��
        rb.linearVelocity = direction * speed;
    }
}