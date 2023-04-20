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
        _diedMenu = FindObjectOfType<DiedMenu>();
        _addPoint = GetComponent<AddPoint>();
        _textDisplay = FindObjectOfType<TextDisplay>();
        _animations = FindObjectOfType<Animations>();
    }
    public void TakeDamage(AudioSource audio)
    {
        _health--;
        _textDisplay.HealthDisplay(_health);
        _animations.HealthAnimation();

        if (_health <= 0)
        {
            _diedMenu.gameObject.SetActive(true);
            audio.Play();
            _addPoint.SetRecord();
            ShowAdv();
        }
    }
}