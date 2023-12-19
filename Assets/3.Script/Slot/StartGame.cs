using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public bool Gamestart = false;
    public GameObject Leverpos;
    public bool ok = false;

    private float rotationSpeed = -180f; // ���� ȸ�� �ӵ�

    private bool leverRotated = false; // ���� ȸ�� �Ϸ� ����

    private Quaternion targetRotation; // ��ǥ ȸ�� ����

    private void Start()
    {
        Leverpos = GameObject.Find("pos");
        targetRotation = Quaternion.Euler(-130f, 0f, 0f); // ��ǥ ȸ�� ���� ����
    }

    private void Update()
    {
        if (ok && !leverRotated)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * 2f);

            if (Quaternion.Angle(transform.localRotation, targetRotation) < 1f) // ���� ȸ���� ��ǥ ������ ���� ���� ���� �����ϸ�
            {
                transform.localRotation = targetRotation; // ��ǥ ȸ�� ������ ����
                leverRotated = true; // ���� ȸ�� �Ϸ� �÷��� ����
            }
        }
        else if (leverRotated)
        {
            // ���� ȸ�� �Ϸ� �� �ʱ� ������ ����
            Quaternion originalRotation = Quaternion.Euler(-40f, 0f, 0f);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, originalRotation, Time.deltaTime * 2f);

            if (Quaternion.Angle(transform.localRotation, originalRotation) < 1f)
            {
                transform.localRotation = originalRotation; // �ʱ� ������ ����
                leverRotated = false; // ���� ȸ�� �Ϸ� �÷��� ����
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
