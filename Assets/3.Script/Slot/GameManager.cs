using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Coins;
    public GameObject wallet;
    public int SetCoin;
    public bool incoin = false;


    private void Awake()
    {
        wallet = GameObject.Find("CoindoutPos");

    }

    private void Start()
    {
        if (wallet != null)
        {
            chek();
            
        }
        else
        {
            Debug.LogWarning("CoindoutPos ������Ʈ�� ã�� �� �����ϴ�.");
        }
    }

    private void Update()
    {
        chek();

    }

    public void chek()
    {
        Coins = wallet.gameObject.transform.childCount;
        Debug.Log("�ڽ� ������Ʈ�� ��: " + Coins);
    }

}
