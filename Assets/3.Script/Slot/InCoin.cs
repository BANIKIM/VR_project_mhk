using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCoin : MonoBehaviour
{
    public bool incoin = false;
    public int SetCoin;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Right_Hand"))
        {
            Destroy(collision.gameObject);
            Debug.Log("인서트 코인");
            SetCoin += 1;
            incoin = true;
        }
    }
}
