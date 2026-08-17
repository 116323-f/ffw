using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PayBar : MonoBehaviour
{
    private float maxPay = 20;
    private float currentPay = 0;
    //[SerializeField] so able to assign through inspector panel
    //hold fill image
    [SerializeField] private Image payBarFill;
    [SerializeField] private TextMeshProUGUI payTeller;
    [SerializeField] private float fillSpeed;
    [SerializeField] private Gradient colourGradient;
    
    void Start()
    {
        payTeller.text = "$" + currentPay;
    }

    //update pay and pay teller to match real amount
    public void UpdatePay (float amount)
    {
        currentPay += amount;
        //set minimum to 0 and maximum to max pay
        currentPay = Mathf.Clamp(currentPay, 0f, maxPay);
        payTeller.text = "$" + currentPay;
        UpdatePayBar();
    }

    //Change fill amount value of fill image
    private void UpdatePayBar()
    {
        //fill amount ranges from 0-1 so must divide to reach normalised value
        float targetFillAmount = currentPay / maxPay;
        //set fill amount of fill image to target value
        payBarFill.DOFillAmount(targetFillAmount, fillSpeed);
        payBarFill.DOColor(colourGradient.Evaluate(targetFillAmount), fillSpeed);
    }



}
