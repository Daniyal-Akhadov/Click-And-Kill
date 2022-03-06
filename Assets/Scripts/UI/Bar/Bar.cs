using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;

    protected const int MaxValue = 1;
    protected const int MinValue = 0;

    public void OnValueChanged(int value, int maxValue)
    {
        Slider.value = (float)value / maxValue;
    }
}
