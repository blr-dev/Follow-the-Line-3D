using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    public static Sound instance;

    public AudioClip[] audioClip;
    public AudioSource audio;

    public void FallDown()
    {
        Debug.Log("elo");
    }

    public void Awake()
    {
        instance = this;
    }

    public void PlayAudio(int number)
    {
        audio.clip = audioClip[number];
        audio.Play();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (audio.isPlaying)
            {
                audio.Stop();
                audio.clip = audioClip[0];
                audio.Play();
            }
            else
            {
                audio.clip = audioClip[0];
                audio.Play();
            }
        }
    }
}