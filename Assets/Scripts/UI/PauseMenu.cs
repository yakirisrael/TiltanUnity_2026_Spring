using UnityEngine;

public class PauseMenu : MonoBehaviour
{
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
        Time.timeScale = 1;
    }
    
    void PauseGame()
    {
        Time.timeScale = 0;
    }
}
