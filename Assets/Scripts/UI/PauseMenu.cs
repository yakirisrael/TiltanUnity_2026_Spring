using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Level Music")]
    [SerializeField] private AudioClip Level1Music;
    [SerializeField] private AudioClip Level2Music;
    [SerializeField] private AudioClip Level3Music;
    [Range(0f, 1f)]
    [SerializeField]
    private float volume = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnContinueButtonPressed()
    {
        Debug.Log("OnContinueButtonPressed");
        gameObject.SetActive(false);
        ResumeGame();
    }

    void ResumeGame()
    {
        AudioManager.Instance.PlayMusic(Level1Music, volume);
        Time.timeScale = 1;
    }
    
    void PauseGame()
    {
        Time.timeScale = 0;
    }
}
