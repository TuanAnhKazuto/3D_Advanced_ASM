using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float heath = 50f;

    [Tooltip("HpBar => 'Slider'")]
    public Slider hpSlider;

    private void Start()
    {
        hpSlider.maxValue = heath;
        hpSlider.value = heath;
    }

    private void Update()
    {
        hpSlider.value = heath;
    }

    public void TakeDamage (float amount)
    {
        heath -= amount;
    }
}
