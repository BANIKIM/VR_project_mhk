using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControll : MonoBehaviour
{
    [Range(1f, 100f)]
    public float Speed = 20f;
    private void Update()
    {
        transform.position += Time.deltaTime * -transform.forward * Speed;
    }
}
