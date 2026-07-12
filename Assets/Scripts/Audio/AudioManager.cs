using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}
    static AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    public void PlayMusic(AudioClip clip, float volume)
    {
        audioSource.volume = volume;
        audioSource.loop = true;
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        audioSource.volume = volume;
        audioSource.loop = false;
        audioSource.clip = clip;
        audioSource.PlayOneShot(clip);
    }
}
