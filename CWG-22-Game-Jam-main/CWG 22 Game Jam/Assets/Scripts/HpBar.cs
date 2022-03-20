using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Slider slider;

    public void ResetHp() {
        slider.maxValue = 100;
        slider.value = 100;
    }
    
    public void SetHp(int hp) {
        slider.value = hp;
    }
}