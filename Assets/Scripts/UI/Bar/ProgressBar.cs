using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : Bar
{
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
    }

    private void OnEnable()
    {
        _spawner.EnemiesCountChanged += OnValueChanged;
        Slider.value = MinValue;
    }

    private void OnDisable()
    {
        _spawner.EnemiesCountChanged -= OnValueChanged;
    }
}
