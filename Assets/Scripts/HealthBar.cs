using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    HealthData healthData;
    [SerializeField]
    Slider slider;
    [SerializeField]
    bool healthDecreasesInWholeNumbers;
    [SerializeField]
    Gradient healthGradient;
    void Start()
    {
        InitialSetup();
    }

    private void InitialSetup()
    {
        slider.maxValue = healthData.maxHealth;
        slider.wholeNumbers = healthDecreasesInWholeNumbers;
        SetSliderFields(slider.maxValue);
    }

    public void SetSliderFields()
    {
        SetSliderFields(healthData.currentHealth);
    }

    public void SetSliderFields(float value)
    {
        slider.value = value;
        slider.fillRect.GetComponent<Image>().color = healthGradient.Evaluate(slider.value / slider.maxValue);
    }
}
