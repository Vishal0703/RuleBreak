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
    // Start is called before the first frame update
    void Start()
    {
        InitialSetup();
    }

    private void InitialSetup()
    {
        slider.maxValue = healthData.maxHealth;
        slider.wholeNumbers = healthDecreasesInWholeNumbers;
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
