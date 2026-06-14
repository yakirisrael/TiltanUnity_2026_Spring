using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    
    public TextMeshProUGUI ScoreText;
    public Image soulsImage;
    private int sizeSoulImage = 100; 
    
    
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

    public void UpdateSouls(int amount)
    {
        soulsImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, sizeSoulImage * amount);
    }
}
