using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;//플레이어 이동 속도

    [SerializeField]
    private GameObject weapon;//무기 프리팹

    [SerializeField]
    private Transform shootTransform;//발사 위치

    [SerializeField]
    private float shootInterval = 0.005f; // 발사 간격

    private float lastShootTime = 0f; // 마지막 발사 시간

    void Update()
    {
        //방향키 입력을 받아 플레이어 이동
        //float horizontalInput = Input.GetAxisRaw("Horizontal");
        ////float verticalInput = Input.GetAxisRaw("Vertical");
        //Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        //transform.position += moveTo * moveSpeed * Time.deltaTime;

        //Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{transform.position -= moveTo;}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{transform.position += moveTo; }

        //마우스로 플레이어 이동
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -8.4f, 8.4f); // 플레이어가 화면 밖으로 나가지 않도록 제한
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);

        //메소드 호출
        Shoot();
    }

    //무기 발사 메소드
    void Shoot()
    {
        if (Time.time - lastShootTime > shootInterval)
        {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lastShootTime = Time.time; // 마지막 발사 시간 업데이트
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
            GameManager.Instance.IncreaseCoin(); // 코인 획득
            Destroy(other.gameObject); // 코인 오브젝트 삭제
        }
    }
}
