using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccuracyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI accuracyText;
    [SerializeField] private TextMeshProUGUI comboText;
    public int combo = 0;

    void Start()
    {
        accuracyText.text = "";
        combo = 0;
        comboText.text = "COMBO: " + combo;
    }

    public void Bad()
    {
        Debug.Log("Bad");
        accuracyText.text = "Bad";
        combo = 0;
        comboText.text = "COMBO: " + combo;

        //stitch in animation
    }

    public void Good()
    {
        Debug.Log("Good");
        accuracyText.text = "Good!";
        combo++;
        comboText.text = "COMBO: " + combo;

    }   

    public void Perfect()
    {
        Debug.Log("Perfect");
        accuracyText.text = "Perfect!";
        combo++;
        comboText.text = "COMBO: " + combo;

    }

    public void Miss()
    {
        Debug.Log("Miss");
        accuracyText.text = "Miss";
        combo = 0;
        comboText.text = "COMBO: " + combo;

    }
}
