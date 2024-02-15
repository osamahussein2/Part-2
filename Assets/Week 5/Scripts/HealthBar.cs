using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("PlayerHealth", slider.value);
    }

    public void TakeDamage(float damage)
    {
        slider.value -= damage;

        PlayerPrefs.SetFloat("PlayerHealth", slider.value);
    }
}
