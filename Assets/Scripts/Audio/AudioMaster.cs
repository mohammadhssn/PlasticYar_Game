using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMaster : MonoBehaviour
{
    [SerializeField] int AudioSorces_ = 10; // num of audiosorce want to create
    [SerializeField] AudioClip[] clips; // audio clips

    new AudioSource[] audio;
    public static AudioMaster ic;
    private void Start()
    {
        ic = this;
        audio = new AudioSource[AudioSorces_];
        for (int i = 0; i < AudioSorces_; i++)
        {
            GameObject clone = new GameObject("AudioSorce (" + i + ")");
            clone.AddComponent<AudioSource>();
            audio[i] = clone.GetComponent<AudioSource>();
            clone.transform.SetParent(this.transform);
        }
    }

    public static void Play(int n)
    {
        foreach (AudioSource s in ic.audio)
        {
            if (s.isPlaying == false)
            {
                s.clip = ic.clips[n];
                s.mute = false;
                s.Play();
                break;
            }
        }
    }

}
