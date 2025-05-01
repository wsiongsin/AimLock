using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public Slider sensitivitySlider;
    public Slider crosshairLengthSlider;
    public Slider crosshairWidthSlider;
    public Slider crosshairGapSlider;

    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    public Toggle movingTargetToggle;

    private void Start()
    {
        //sliders
        sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity", 2f);
        crosshairLengthSlider.value = PlayerPrefs.GetFloat("CrosshairLength", 30f);
        crosshairWidthSlider.value = PlayerPrefs.GetFloat("CrosshairWidth", 2f);
        crosshairGapSlider.value = PlayerPrefs.GetFloat("CrosshairGap", 5f);

        redSlider.value = PlayerPrefs.GetFloat("CrosshairR", 0f);
        greenSlider.value = PlayerPrefs.GetFloat("CrosshairG", 1f);
        blueSlider.value = PlayerPrefs.GetFloat("CrosshairB", 0f);

        //toggle
        movingTargetToggle.isOn = PlayerPrefs.GetInt("MovingTarget", 0) == 1;
    }

    public void ApplySettings()
    {
        PlayerPrefs.SetFloat("Sensitivity", sensitivitySlider.value);
        PlayerPrefs.SetFloat("CrosshairLength", crosshairLengthSlider.value);
        PlayerPrefs.SetFloat("CrosshairWidth", crosshairWidthSlider.value);
        PlayerPrefs.SetFloat("CrosshairGap", crosshairGapSlider.value);

        PlayerPrefs.SetFloat("CrosshairR", redSlider.value);
        PlayerPrefs.SetFloat("CrosshairG", greenSlider.value);
        PlayerPrefs.SetFloat("CrosshairB", blueSlider.value);

        PlayerPrefs.SetInt("MovingTarget", movingTargetToggle.isOn ? 1 : 0);

        PlayerPrefs.Save();
        Debug.Log("Settings applied!");
    }

    public void ReturnToPreviousScene()
    {
        ApplySettings();
        string lastScene = PlayerPrefs.GetString("LastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(lastScene);
        PlayerPrefs.DeleteKey("LastScene");
    }
}




