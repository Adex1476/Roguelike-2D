using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _sl;

    public void SetMaxHealth(int health)
    {
        _sl.maxValue = health;
        _sl.value = health;
    }

    public void SetHealth(int health)
    {
        _sl.value = health;
    }
}
