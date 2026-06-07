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

    void UpdateScore(int score)
    {
        ScoreText.text = score.ToString();
    }
}
