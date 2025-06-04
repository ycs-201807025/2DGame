using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;//�÷��̾� �̵� �ӵ�

    [SerializeField]
    private GameObject weapon;//���� ������

    [SerializeField]
    private Transform shootTransform;//�߻� ��ġ

    [SerializeField]
    private float shootInterval = 0.005f; // �߻� ����

    private float lastShootTime = 0f; // ������ �߻� �ð�

    void Update()
    {
        //����Ű �Է��� �޾� �÷��̾� �̵�
        //float horizontalInput = Input.GetAxisRaw("Horizontal");
        ////float verticalInput = Input.GetAxisRaw("Vertical");
        //Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        //transform.position += moveTo * moveSpeed * Time.deltaTime;

        //Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{transform.position -= moveTo;}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{transform.position += moveTo; }

        //���콺�� �÷��̾� �̵�
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -8.4f, 8.4f); // �÷��̾ ȭ�� ������ ������ �ʵ��� ����
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);

        //�޼ҵ� ȣ��
        Shoot();
    }

    //���� �߻� �޼ҵ�
    void Shoot()
    {
        if (Time.time - lastShootTime > shootInterval)
        {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lastShootTime = Time.time; // ������ �߻� �ð� ������Ʈ
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Coin")
        {
            GameManager.Instance.IncreaseCoin(); // ���� ȹ��
            Destroy(other.gameObject); // ���� ������Ʈ ����
        }
    }
}
