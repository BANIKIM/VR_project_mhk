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
            Debug.Log("�μ�Ʈ ����");
            SetCoin += 1;
            incoin = true;
        }
    }
}
