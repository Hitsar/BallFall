using UnityEngine;

public class HealthPlatform : MonoBehaviour
{
    [SerializeField] private int _health;

    private DiedMenu _diedMenu;
    private AddPoint _addPoint;
    private TextDisplay _textDisplay;

    private void Start()
    {
        _diedMenu = FindObjectOfType<DiedMenu>().GetComponent<DiedMenu>();
        _addPoint = GetComponent<AddPoint>();
        _textDisplay = FindObjectOfType<TextDisplay>().GetComponent<TextDisplay>();
    }
    public void TakeDamage(AudioSource audio)
    {
        _health--;
        _textDisplay.HealthDisplay(_health);

        if (_health <= 0)
        {
            _diedMenu.Enabling();
            audio.Play();
            _addPoint.SetRecord();
        }
    }
}