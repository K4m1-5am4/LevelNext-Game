using UnityEngine;
using UnityEngine.UI;

public class HealthbarS : MonoBehaviour
{
    public Slider slider;
    public void setmaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealth(int health)
    {
        slider.value = health;
    }
}
