using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Cube"))
        {
            Destroy(collision.gameObject);
        }
    }
}
