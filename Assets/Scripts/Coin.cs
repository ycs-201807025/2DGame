using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float minY = -7f;
    void Start()
    {
        Jump();
    }
    void Jump()// ���� ������Ʈ ���� ����
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>(); 

        float randomJumpForce = Random.Range(4f, 8f); // ���� ���� �� ����
        Vector2 jumpVelocity = Vector2.up * randomJumpForce; // ���� �����ϴ� �� ����
        jumpVelocity.x = Random.Range(-2f, 2f); // �¿�� �ణ�� ���� �� �߰�

        rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse); // ���� ���� ����
    }
    void Update()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject); //Coin ������Ʈ ����
        }
    }
}
