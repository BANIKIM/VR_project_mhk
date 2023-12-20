using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCoin : MonoBehaviour
{    public GameManager gameManager;


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    public void InCoins()
    {
        if (gameManager.Coins > 0)
        {
            Destroy(gameManager.wallet.transform.GetChild(0).gameObject);
            Debug.Log("인서트 코인");
            gameManager.SetCoin += 1;
            gameManager.incoin = true;
        }
        else
        {
            Debug.Log("돈없어");
        }
    }
}
