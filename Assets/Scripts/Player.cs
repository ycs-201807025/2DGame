using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    void Update()
    {
        //방향키 입력을 받아 플레이어 이동
        float horizontalInput = Input.GetAxisRaw("horizontal");
        float verticalInput = Input.GetAxisRaw("vertical");
    }
}
