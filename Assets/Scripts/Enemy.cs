using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -7f;

    [SerializeField]
    private float hp = 1f;

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed; //Enemy �̵� �ӵ� ����
    }
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < minY)
        {
            Destroy(gameObject); //Enemy ������Ʈ ����
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage; //Enemy hp ����
            if (hp <= 0f)
            {
                Destroy(gameObject); //Enemy ������Ʈ ����
            }
            Destroy(other.gameObject); //���� ������Ʈ ����
        }
    }
}
