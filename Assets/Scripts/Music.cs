using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public GameObject songSL, songSD, songZ;
    //public AudioSource AsSL, AsSD, AsZ;

    public KeyCode songsKey = KeyCode.Q;

    public float musicVolume = 1f;

    void Start()
    {
        StreetLove();
    }
    void Update()
    {
        //AsSL.volume = musicVolume;
        //AsSD.volume = musicVolume;
        //AsZ.volume = musicVolume;

        songSL.GetComponent<AudioSource>().volume = musicVolume;
        songSD.GetComponent<AudioSource>().volume = musicVolume;
        songZ.GetComponent<AudioSource>().volume = musicVolume;

        if (Input.GetKeyDown(songsKey))
            ChangeShongs();
    }

    public void ChangeShongs()
    {
        if (songSL.activeInHierarchy)
        {
            StupidDancer();
        }
        else if (songSD.activeInHierarchy)
        {
            Zephyr();
        }
        else
        {
            StreetLove();
        }
    }

    public void StreetLove()
    {
        songZ.SetActive(false);
        songSD.SetActive(false);
        songSL.SetActive(true);
    }

    public void StupidDancer()
    {
        songSL.SetActive(false);
        songZ.SetActive(false);
        songSD.SetActive(true);
    }

    public void Zephyr()
    {
        songSL.SetActive(false);
        songSD.SetActive(false);
        songZ.SetActive(true);
    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }
}
