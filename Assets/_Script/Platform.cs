using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    [Header("Logic")]
    private int _point;
    [SerializeField] float _speed;
    [SerializeField] int _hp;
    [SerializeField] Rigidbody _rb;

    [Header("Effect")]
    [SerializeField] GameObject _particle;
    [SerializeField] AudioSource _audio;

    [Header("UI")]
    [SerializeField] Button _buttonLeft;
    [SerializeField] Button _buttonRight;
    [SerializeField] TextMeshProUGUI _textPoint;
    [SerializeField] TextMeshProUGUI _textHealth;
    [SerializeField] GameObject _diedPanel;

    private void Start()
    {
        _diedPanel.SetActive(false);
        if (Progress.Instance.PlayerInfo._phone)
            _buttonLeft.gameObject.SetActive(true);
            _buttonRight.gameObject.SetActive(true);
    }

    private void Update()
    {
        _rb.velocity = Vector3.left * _speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A))
        {
            Left();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Right();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            Up();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Up();
        }
    }
    public void Left()
    {
        _speed = 500;
    }
    public void Right()
    {
        _speed = -500;
    }
    public void Up()
    {
        _speed = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            ball.gameObject.SetActive(false);
            _point++;
            _textPoint.text = _point.ToString();
            Instantiate(_particle, transform.position, Quaternion.identity);
            _audio.Play();
        }
    }

    public void Die()
    {
        _hp--;
        _textHealth.text = _hp.ToString();
        if (_hp <= 0)
        {
            if (Progress.Instance.PlayerInfo._point < _point)
            {
                Progress.Instance.PlayerInfo._point = _point;
                Progress.Instance.Save();
            }
            Time.timeScale = 0;
            _diedPanel.SetActive(true);
        }

    }
}
