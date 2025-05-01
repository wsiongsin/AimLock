using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    public Image top, bottom, left, right;

    private float length;
    private float width;
    private float gap;
    private Color color;

    void Start()
    {
        //load values from PlayerPrefs
        length = PlayerPrefs.GetFloat("CrosshairLength", 30f);
        width = PlayerPrefs.GetFloat("CrosshairWidth", 2f);
        gap = PlayerPrefs.GetFloat("CrosshairGap", 5f);

        float r = PlayerPrefs.GetFloat("CrosshairR", 0f);
        float g = PlayerPrefs.GetFloat("CrosshairG", 1f);
        float b = PlayerPrefs.GetFloat("CrosshairB", 0f);
        color = new Color(r, g, b, 1f);

        Debug.Log($"Crosshair Loaded: length={length}, width={width}, gap={gap}, color={color}");

        ApplySettings();
    }

    void ApplySettings()
    {
        Vector2 horizontal = new Vector2(length, width);
        Vector2 vertical = new Vector2(width, length);

        top.rectTransform.sizeDelta = horizontal;
        bottom.rectTransform.sizeDelta = horizontal;
        left.rectTransform.sizeDelta = vertical;
        right.rectTransform.sizeDelta = vertical;

        top.rectTransform.anchoredPosition = new Vector2(0, gap + length / 2);
        bottom.rectTransform.anchoredPosition = new Vector2(0, -(gap + length / 2));
        left.rectTransform.anchoredPosition = new Vector2(-(gap + length / 2), 0);
        right.rectTransform.anchoredPosition = new Vector2(gap + length / 2, 0);

        top.color = bottom.color = left.color = right.color = color;
    }
}



