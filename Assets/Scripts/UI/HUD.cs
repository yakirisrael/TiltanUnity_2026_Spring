using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    
    public TextMeshProUGUI ScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        ScoreText.text = "Score: " + score.ToString();
    }
}
