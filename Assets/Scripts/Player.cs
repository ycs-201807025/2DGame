using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

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
    }
}
