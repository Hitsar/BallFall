using System.Runtime.InteropServices;
using UnityEngine;

public class HealthPlatform : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();

    [SerializeField] private int _health;

    private DiedMenu _diedMenu;
    private AddPoint _addPoint;
    private TextDisplay _textDisplay;
    private Animations _animations;

    private void Start()
    {
        _diedMenu = FindObjectOfType<DiedMenu>().GetComponent<DiedMenu>();
        _addPoint = GetComponent<AddPoint>();
        _textDisplay = FindObjectOfType<TextDisplay>().GetComponent<TextDisplay>();
        _animations = FindObjectOfType<Animations>().GetComponent<Animations>();
    }
    public void TakeDamage(AudioSource audio)
    {
        _health--;
        _textDisplay.HealthDisplay(_health);
        _animations.HealthAnimation();

        if (_health <= 0)
        {
            _diedMenu.Enabling();
            audio.Play();
            _addPoint.SetRecord();
            ShowAdv();
        }
    }
}