using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PayBar : MonoBehaviour
{
    [SerializeField] private float maxPay = 20f;
    [SerializeField] private Image payBarFill;
    [SerializeField] private TextMeshProUGUI payTeller;
    [SerializeField] private float fillSpeed = 0.3f;
    [SerializeField] private Gradient colourGradient;

    private float currentPay = 0f;
    private Tween fillTween;
    private Tween colourTween;

    void Start()
    {
        UpdatePay(0f);
    }

    //match current score.
    public void UpdatePay(float amount)
    {
        currentPay = Mathf.Clamp(amount, 0f, maxPay);

        if (payTeller != null)
            payTeller.text = "$" + currentPay.ToString("0.00");

        UpdatePayBar();
    }

    private void UpdatePayBar()
    {
        if (payBarFill == null)
            return;

        float targetFillAmount = currentPay / maxPay;
        Color targetColour = colourGradient.Evaluate(targetFillAmount);

        // Stop previous animation
        fillTween?.Kill();
        colourTween?.Kill();

        fillTween = payBarFill
            .DOFillAmount(targetFillAmount, fillSpeed);

        colourTween = payBarFill
            .DOColor(targetColour, fillSpeed);
    }

    private void OnDestroy()
    {
        fillTween?.Kill();
        colourTween?.Kill();
    }
}
