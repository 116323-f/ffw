using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI highScoreText;

    private float score;
    private float highScore;

    //=> means get
    public float Score => score;

    void Start()
    {
        score = 0f;
        highScore = 0f;
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = "$" + highScore;
    }

    public void AddScore(float amount)
    {
        score += amount;
        scoreText.text = "Pay: " + score;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
            highScoreText.text = "$" + highScore;
        }
    }
}
