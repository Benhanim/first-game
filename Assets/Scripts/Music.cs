using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public static Music music;

    public Slider slider;

    public GameObject songSL, songSD, songZ;

    public KeyCode songsKey = KeyCode.Q;

    public float musicVolume = 1f;

    private void Awake()
    {
        if (music == null)
        {
            DontDestroyOnLoad(gameObject);
            music = this;
        }
        else if (music != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("currentVolume", 1);
        slider.value = musicVolume;
        StreetLove();
    }

    void Update()
    {
        PlayerPrefs.SetFloat("currentVolume", musicVolume);

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

    public void UpdateVolume()
    {
        musicVolume = slider.value;
    }
}
