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
            Debug.LogWarning("CoindoutPos 오브젝트를 찾을 수 없습니다.");
        }
    }

    private void Update()
    {
        chek();

    }

    public void chek()
    {
        Coins = wallet.gameObject.transform.childCount;
        Debug.Log("자식 오브젝트의 수: " + Coins);
    }

}
