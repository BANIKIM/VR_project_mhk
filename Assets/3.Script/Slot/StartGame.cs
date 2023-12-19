using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public bool Gamestart = false;
    public GameObject Leverpos;
    public bool ok = false;

    private float rotationSpeed = -180f; // 레버 회전 속도

    private bool leverRotated = false; // 레버 회전 완료 여부

    private Quaternion targetRotation; // 목표 회전 각도

    private void Start()
    {
        Leverpos = GameObject.Find("pos");
        targetRotation = Quaternion.Euler(-130f, 0f, 0f); // 목표 회전 각도 설정
    }

    private void Update()
    {
        if (ok && !leverRotated)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * 2f);

            if (Quaternion.Angle(transform.localRotation, targetRotation) < 1f) // 레버 회전이 목표 각도와 일정 범위 내로 수렴하면
            {
                transform.localRotation = targetRotation; // 목표 회전 각도로 고정
                leverRotated = true; // 레버 회전 완료 플래그 설정
            }
        }
        else if (leverRotated)
        {
            // 레버 회전 완료 시 초기 각도로 복귀
            Quaternion originalRotation = Quaternion.Euler(-40f, 0f, 0f);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, originalRotation, Time.deltaTime * 2f);

            if (Quaternion.Angle(transform.localRotation, originalRotation) < 1f)
            {
                transform.localRotation = originalRotation; // 초기 각도로 고정
                leverRotated = false; // 레버 회전 완료 플래그 해제
            }
            ok = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Right_Hand"))
        {
            Gamestart = true;
            ok = true;
        }
    }
}
