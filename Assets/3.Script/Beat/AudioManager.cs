using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void audioPlay()
    {
        if(!source.isPlaying)
        {
            source.Play();
        }
    }

}
