using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    void Update()
    {
        //����Ű �Է��� �޾� �÷��̾� �̵�
        float horizontalInput = Input.GetAxisRaw("horizontal");
        float verticalInput = Input.GetAxisRaw("vertical");
    }
}
