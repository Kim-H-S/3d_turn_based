using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_HPbar : MonoBehaviour
{
    [SerializeField] private Slider slider_HPbar;
    public float maxHP;
    public float currentHP;

    void Start()
    {
        
    }

    void Update()
    {
        slider_HPbar.value = currentHP / maxHP;
    }
}
