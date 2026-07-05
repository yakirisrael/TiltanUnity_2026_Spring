using UnityEngine;

public class AudioManager : MonoBehaviour
{
   
    static AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public static void PlayMusic(AudioClip clip)
    {
        audioSource.volume = 1;
        audioSource.loop = true;
        audioSource.clip = clip;
        audioSource.Play();
        
    }
}
