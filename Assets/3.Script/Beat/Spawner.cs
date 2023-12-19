using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Cubes;
    [SerializeField] private Transform[] Point;
    //리듬게임 
    //60/128
    public float bpm = 128f;
    [SerializeField] private float beat 
    {
        get
        {
            return 60f / bpm;
        }
    }

    public float Timmer;

    private void Start()
    {
        Point = new Transform[transform.childCount];
        for(int i=0;i<transform.childCount;i++)
        {
            Point[i] = transform.GetChild(i);
        }
        Timmer = 0f;
    }

    private void Update()
    {
        if(Timmer>beat)
        {
            int Random_index = Random.Range(0, 2);
            GameObject cube = Instantiate(Cubes[Random_index]);

            float y = Random.Range(0.5f, 1.5f);
            Debug.Log(y);

            cube.transform.position =
                new Vector3(
                    Point[Random_index].transform.position.x,
                    y,
                    Point[Random_index].transform.position.z);
            cube.transform.Rotate(transform.forward, 90f * Random.Range(0, 4));
            Timmer -= beat;
            //audio manger 생성하면 Play 넣어주세요. todo 12.14
            AudioManager.instance.audioPlay();
        }
        Timmer += Time.deltaTime;
    }

}
