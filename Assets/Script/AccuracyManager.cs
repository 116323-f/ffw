using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccuracyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI accuracyText;
    [SerializeField] private TextMeshProUGUI comboText;
   
    [SerializeField] private HighScore highScoreScript;

    [SerializeField] private float bad = 0.05f;
    [SerializeField] private float good = 0.1f;
    [SerializeField] private float perfect = 0.2f;

    public int combo = 0;


    void Start()
    {
        accuracyText.text = "Good";
        combo = 0;
        comboText.text = "COMBO: " + combo;
    }

    public void Bad()
    {
        Debug.Log("Bad");
        accuracyText.text = "Bad";
        combo = 0;
        comboText.text = "COMBO: " + combo;
        PayAmount(bad);
        //pay amount

        //stitch in animation
    }

    public void Good()
    {
        Debug.Log("Good");
        accuracyText.text = "Good!";
        combo++;
        comboText.text = "COMBO: " + combo;
        PayAmount(good);
    }   

    public void Perfect()
    {
        Debug.Log("Perfect");
        accuracyText.text = "Perfect!";
        combo++;
        comboText.text = "COMBO: " + combo;
        PayAmount(perfect);
    }

    public void Miss()
    {
        Debug.Log("Miss");
        accuracyText.text = "Miss";
        combo = 0;
        comboText.text = "COMBO: " + combo;

    }

    private void PayAmount(float amount)
    {
        highScoreScript.AddScore(amount);
    }
}
