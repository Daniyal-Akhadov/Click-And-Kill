using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
        Slider.value = MaxValue;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }
}
