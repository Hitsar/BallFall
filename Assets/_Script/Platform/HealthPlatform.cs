using TMPro;
using UnityEngine;

public class HealthPlatform : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private TextMeshProUGUI _textHealth;

    private DiedMenu _diedMenu;
    private AddPoint _addPoint;

    private void Start()
    {
        _diedMenu = FindObjectOfType<DiedMenu>().GetComponent<DiedMenu>();
        _addPoint = GetComponent<AddPoint>();
    }
    public void TakeDamage(AudioSource audio)
    {
        _health--;
        _textHealth.text = _health.ToString();

        if (_health <= 0)
        {
            _diedMenu.Enabling();
            audio.Play();
            _addPoint.SetRecord();
        }
    }
}