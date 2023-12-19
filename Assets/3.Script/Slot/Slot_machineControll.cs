using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot_machineControll : MonoBehaviour
{
    public InCoin inCoin;
    public GameManager gameManager;

    public GameObject Slots;
    public GameObject Coinout;
    public StartGame startbtn;
    public GameObject[] slot = new GameObject[3];
    public float Stop =0f;
    [SerializeField] private GameObject Coin;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        slot = new GameObject[3];
        inCoin = FindObjectOfType<InCoin>();
        Slots = GameObject.Find("Slots");
        Coinout = GameObject.Find("CoindoutPos");
        startbtn = FindObjectOfType<StartGame>();
        for (int i = 0; i < slot.Length; i++)
        {
            slot[i] = Slots.transform.GetChild(i).gameObject; // Transform.GetChild(i)�� �����Ͽ� GameObject ��������

        }

        for (int i = 0; i < 10; i++)
        {
            Instantiate(Coin, Coinout.transform);
        }
    }
    private void Update()
    {
        if (gameManager.incoin && startbtn.Gamestart)
        {
            int slotspeed1 = Random.Range(1000, 1500);
            int slotspeed2 = Random.Range(1000, 1500);
            int slotspeed3 = Random.Range(1000, 1500);

            if(Stop<3)
            {
                slot[0].transform.Rotate(new Vector3(0, slotspeed1 * Time.deltaTime, 0));
                slot[1].transform.Rotate(new Vector3(0, slotspeed2 * Time.deltaTime, 0));
                slot[2].transform.Rotate(new Vector3(0, slotspeed3 * Time.deltaTime, 0));

                Stop += Time.deltaTime;
            }
            else
            {
                Stop = 0f;
                gameManager.incoin = false;
                startbtn.Gamestart = false;
                Result();
                gameManager.SetCoin = 0;
            }


        }
    }





    //������ ��� �޼���
    public void Result()
    {
        int slotspeed1 = Random.Range(1, 1000);
        int slotspeed2 = Random.Range(1, 1000);
        int slotspeed3 = Random.Range(1, 1000);

        int[] slots = new int[3];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = 0;
        }


        //����
        if (slotspeed1 == 1)
        {
            slot[0].transform.rotation = Quaternion.Euler(new Vector3(-45f, 0, 90));//7
            Debug.Log("Slot1 ����");
            slots[0] = 1;
        }
        else if (slotspeed1 < 5)
        {
            slot[0].transform.rotation = Quaternion.Euler(new Vector3(-180f, 0, 90));//Bar
            slots[0] = 2;
        }
        else if(slotspeed1<20)
        {
            slot[0].transform.rotation = Quaternion.Euler(new Vector3(-90f, 0, 90));//��
            slots[0] = 3;
        }
        else if(slotspeed1<100)
        {
            slot[0].transform.rotation = Quaternion.Euler(new Vector3(-315f, 0, 90));//����
            slots[0] = 4;
        }
        else if(slotspeed1<200)
        {
            slot[0].transform.rotation = Quaternion.Euler(new Vector3(-270f, 0, 90));//������
            slots[0] = 5;
        }
        else if (slotspeed1 < 400)
        {
            slot[0].transform.rotation = Quaternion.Euler(new Vector3(-225f, 0, 90));//��纣��
            slots[0] = 6;
        }
        else if (slotspeed1 < 700)
        {
            slot[0].transform.rotation = Quaternion.Euler(new Vector3(-135f, 0, 90));//�ٳ���
            slots[0] = 7;
        }
        else if (slotspeed1 < 1000)
        {
            slot[0].transform.rotation = Quaternion.Euler(new Vector3(-360f, 0, 90));//ä��
            slots[0] = 8;
        }



        if (slotspeed2 == 1)
        {
            slot[1].transform.rotation = Quaternion.Euler(new Vector3(-45f, 0, 90));//7
            Debug.Log("Slot1 ����");
            slots[1] = 1;
        }
        else if (slotspeed2 < 5)
        {
            slot[1].transform.rotation = Quaternion.Euler(new Vector3(-180f, 0, 90));//Bar
            slots[1] = 2;
        }
        else if (slotspeed2 < 20)
        {
            slot[1].transform.rotation = Quaternion.Euler(new Vector3(-90f, 0, 90));//��
            slots[1] = 3;
        }
        else if (slotspeed2 < 100)
        {
            slot[1].transform.rotation = Quaternion.Euler(new Vector3(-315f, 0, 90));//����
            slots[1] = 4;
        }
        else if (slotspeed2 < 200)
        {
            slot[1].transform.rotation = Quaternion.Euler(new Vector3(-270f, 0, 90));//������
            slots[1] = 5;
        }
        else if (slotspeed2 < 400)
        {
            slot[1].transform.rotation = Quaternion.Euler(new Vector3(-225f, 0, 90));//��纣��
            slots[1] = 6;
        }
        else if (slotspeed2 < 700)
        {
            slot[1].transform.rotation = Quaternion.Euler(new Vector3(-135f, 0, 90));//�ٳ���
            slots[1] = 7;
        }
        else if (slotspeed2 < 1000)
        {
            slot[1].transform.rotation = Quaternion.Euler(new Vector3(-360f, 0, 90));//ä��
            slots[1] = 8;
        }




        if (slotspeed3 == 1)
        {
            slot[2].transform.rotation = Quaternion.Euler(new Vector3(-45f, 0, 90));//7
            Debug.Log("Slot1 ����");
            slots[2] = 1;
        }
        else if (slotspeed3 < 5)
        {
            slot[2].transform.rotation = Quaternion.Euler(new Vector3(-180f, 0, 90));//Bar
            slots[2] = 2;
        }
        else if (slotspeed3 < 20)
        {
            slot[2].transform.rotation = Quaternion.Euler(new Vector3(-90f, 0, 90));//��
            slots[2] = 3;
        }
        else if (slotspeed3 < 100)
        {
            slot[2].transform.rotation = Quaternion.Euler(new Vector3(-315f, 0, 90));//����
            slots[2] = 4;
        }
        else if (slotspeed3 < 200)
        {
            slot[2].transform.rotation = Quaternion.Euler(new Vector3(-270f, 0, 90));//������
            slots[2] = 5;
        }
        else if (slotspeed3 < 400)
        {
            slot[2].transform.rotation = Quaternion.Euler(new Vector3(-225f, 0, 90));//��纣��
            slots[2] = 6;
        }
        else if (slotspeed3 < 700)
        {
            slot[2].transform.rotation = Quaternion.Euler(new Vector3(-135f, 0, 90));//�ٳ���
            slots[2] = 7;
        }
        else if (slotspeed3 < 1000)
        {
            slot[2].transform.rotation = Quaternion.Euler(new Vector3(-360f, 0, 90));//ä��
            slots[2] = 8;
        }


        //3�� ���߱�
        if(slots[0]== slots[1] && slots[0]== slots[2])
        {
            if(slots[0].Equals(8)|| slots[0].Equals(7))
            {
                for (int i = 0; i < gameManager.SetCoin*3; i++)
                {
                    Instantiate(Coin, Coinout.transform);
                }
            }
            else if(slots[0].Equals(6))
            {
                for (int i = 0; i < gameManager.SetCoin * 6; i++)
                {
                    Instantiate(Coin, Coinout.transform);
                }
            }
            else if(slots[0].Equals(5))
            {
                for (int i = 0; i < gameManager.SetCoin * 12; i++)
                {
                    Instantiate(Coin, Coinout.transform);
                }
            }
            else if (slots[0].Equals(4))
            {
                for (int i = 0; i < gameManager.SetCoin * 24; i++)
                {
                    Instantiate(Coin, Coinout.transform);
                }
            }
            else if (slots[0].Equals(3))
            {
                for (int i = 0; i < gameManager.SetCoin * 48; i++)
                {
                    Instantiate(Coin, Coinout.transform);
                }
            }
            else if (slots[0].Equals(2))
            {
                for (int i = 0; i < gameManager.SetCoin * 96; i++)
                {
                    Instantiate(Coin, Coinout.transform);
                }
            }
            else if (slots[0].Equals(1))
            {
                for (int i = 0; i < gameManager.SetCoin * 192; i++)
                {
                    Instantiate(Coin, Coinout.transform);
                }
            }

        }

        //���� 7, 7����
        if(slots[0].Equals(1)|| slots[1].Equals(1) || slots[2].Equals(1))
        {
            for (int i = 0; i < gameManager.SetCoin * 6; i++)
            {
                Instantiate(Coin, Coinout.transform);
            }
            if(slots[0].Equals(1) && slots[1].Equals(1))
            {
                for (int i = 0; i < gameManager.SetCoin * 12; i++)
                {
                    Instantiate(Coin, Coinout.transform);
                }
            }
            else if(slots[0].Equals(1) && slots[2].Equals(1))
            {
                for (int i = 0; i < gameManager.SetCoin * 12; i++)
                {
                    Instantiate(Coin, Coinout.transform);
                }
            }
            else if(slots[1].Equals(1) && slots[2].Equals(1))
            {
                for (int i = 0; i < gameManager.SetCoin * 12; i++)
                {
                    Instantiate(Coin, Coinout.transform);
                }
            }
        }

        //���� Bar, Bar����
        if (slots[0].Equals(2) || slots[1].Equals(2) || slots[2].Equals(2))
        {
            for (int i = 0; i < gameManager.SetCoin * 3; i++)
            {
                Instantiate(Coin, Coinout.transform);
            }
            if (slots[0].Equals(2) && slots[1].Equals(2))
            {
                for (int i = 0; i < gameManager.SetCoin * 6; i++)
                {
                    Instantiate(Coin, Coinout.transform);
                }
            }
            else if (slots[0].Equals(2) && slots[2].Equals(2))
            {
                for (int i = 0; i < gameManager.SetCoin * 6; i++)
                {
                    Instantiate(Coin, Coinout.transform);
                }
            }
            else if (slots[1].Equals(2) && slots[2].Equals(2))
            {
                for (int i = 0; i < gameManager.SetCoin * 6; i++)
                {
                    Instantiate(Coin, Coinout.transform);
                }
            }
        }


        //����
        if (slots[0].Equals(8) && slots[1].Equals(8))
        {
            for (int i = 0; i < gameManager.SetCoin * 2; i++)
            {
                Instantiate(Coin, Coinout.transform);
            }
        }
        else if (slots[0].Equals(8) && slots[2].Equals(8))
        {
            for (int i = 0; i < gameManager.SetCoin * 2; i++)
            {
                Instantiate(Coin, Coinout.transform);
            }
        }
        else if (slots[1].Equals(8) && slots[2].Equals(8))
        {
            for (int i = 0; i < gameManager.SetCoin * 2; i++)
            {
                Instantiate(Coin, Coinout.transform);
            }
        }
        if (slots[0].Equals(8) && slots[1].Equals(7))
        {
            for (int i = 0; i < gameManager.SetCoin * 2; i++)
            {
                Instantiate(Coin, Coinout.transform);
            }
        }
        else if (slots[0].Equals(8) && slots[2].Equals(7))
        {
            for (int i = 0; i < gameManager.SetCoin * 2; i++)
            {
                Instantiate(Coin, Coinout.transform);
            }
        }
        else if (slots[1].Equals(8) && slots[2].Equals(7))
        {
            for (int i = 0; i < gameManager.SetCoin * 2; i++)
            {
                Instantiate(Coin, Coinout.transform);
            }
        }

    }


}
