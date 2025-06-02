using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 3;

    void Update()
    {
        //배경화면을 아래로 움직이고 일정위치까지 내려가면 위로 이동시켜 계속 이어지게 하기
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < -10)
        {
            transform.position += new Vector3(0, 20f, 0);
        }
    }
}
