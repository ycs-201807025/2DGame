using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [SerializeField]
    private TextMeshProUGUI text; // 코인 UI 텍스트

    private int coin = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void IncreaseCoin()
    {
        coin++;
        text.SetText(coin.ToString());

        if (coin % 30 == 0)
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.Upgrade(); // 플레이어 업그레이드 메소드 호출
            }
        }
    }
}
