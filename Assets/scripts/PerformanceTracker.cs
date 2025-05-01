using UnityEngine;
using TMPro;

public class PerformanceTracker : MonoBehaviour
{
    public TextMeshPro timerText, hitsText, missesText, accuracyText;

    private float timer = 0f;
    private int hits = 0;
    private int misses = 0;

    void Update()
    {
        timer += Time.deltaTime;
        UpdateUI();
    }

    public void RegisterHit()
    {
        hits++;
        UpdateUI();
    }

    public void RegisterMiss()
    {
        misses++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (timerText) timerText.text = $"Time: {timer:F1}s";
        if (hitsText) hitsText.text = $"Hits: {hits}";
        if (missesText) missesText.text = $"Misses: {misses}";
        if (accuracyText)
        {
            float accuracy = hits + misses > 0 ? (hits * 100f) / (hits + misses) : 0;
            accuracyText.text = $"Accuracy: {accuracy:F1}%";
        }
    }
}
