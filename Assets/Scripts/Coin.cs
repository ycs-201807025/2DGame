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
    void Jump()// 코인 오브젝트 위로 점프
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>(); 

        float randomJumpForce = Random.Range(4f, 8f); // 랜덤 점프 힘 설정
        Vector2 jumpVelocity = Vector2.up * randomJumpForce; // 위로 점프하는 힘 벡터
        jumpVelocity.x = Random.Range(-2f, 2f); // 좌우로 약간의 랜덤 힘 추가

        rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse); // 위로 힘을 가함
    }
    void Update()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject); //Coin 오브젝트 삭제
        }
    }
}
