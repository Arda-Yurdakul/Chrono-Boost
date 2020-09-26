using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip winJingle;
    [SerializeField] AudioClip deathExplosion;
    [SerializeField] AudioClip startCue;
    AudioSource audioSource;


    private static  AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("No AudioManager Found!");
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }




    public void PlayThruster()
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(mainEngine);
    }

    public void PlayWinJingle()
    {
        audioSource.PlayOneShot(winJingle);
    }

    public void PlayDeathExplosion()
    {
        audioSource.PlayOneShot(deathExplosion);
    }

    public void StartCue()
    {   
        if(!audioSource.isPlaying)
        audioSource.PlayOneShot(startCue);
    }

    public void StopPlaying()
    {
        audioSource.Stop();
    }


}
