using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource source;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }

    public void playLoop()
    {
        source.loop = true;
        source.Play();
    }

    public void playEnd(AudioClip sound)
    {
        source.Stop();
        /*source.clip = sound;
        source.loop = false;
        source.Play();*/
    }

    public void stopLoop()
    {
        source.Stop();
    }
}
