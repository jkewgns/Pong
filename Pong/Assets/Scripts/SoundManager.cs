using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip paddleHit1;
    public AudioClip paddleHit2;
    public AudioClip wallHit;
    public AudioClip score;

    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPaddleHit()
    {
        AudioClip clip = Random.Range(0,2) == 0 ? paddleHit1 : paddleHit2;
        audioSource.PlayOneShot(clip);
    }

    public void PlayWallHit()
    {
        audioSource.PlayOneShot(wallHit);
    }

    public void PlayScore()
    {
        audioSource.PlayOneShot(score);
    }
}
