using TMPro;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textHealth;
    [SerializeField] private TextMeshProUGUI _textPoint;

    public void HealthDisplay(int health)
    {
        _textHealth.text = health.ToString();
    }

    public void PointDisplay(int point)
    {
        _textPoint.text = point.ToString();
    }
}