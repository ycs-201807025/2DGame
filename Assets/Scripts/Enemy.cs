using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject Coin;

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
                if (gameObject.tag == "Boss")
                {
                    GameManager.Instance.SetGameOver(); //���� ���� ����
                }
                Destroy(gameObject); //Enemy ������Ʈ ����
                Instantiate(Coin, transform.position,Quaternion.identity);
            }
            Destroy(other.gameObject); //���� ������Ʈ ����
        }
    }
}
