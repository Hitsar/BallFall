using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Platform : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _hp;
    [SerializeField] Rigidbody _rb;
    private int point;

    [SerializeField] GameObject _particle;
    [SerializeField] AudioSource _audio;

    [SerializeField] TextMeshProUGUI _textPoint;
    [SerializeField] TextMeshProUGUI _textHealth;
    [SerializeField] GameObject _diedPanel;

    private void Start()
    {
        _diedPanel.SetActive(false);
    }
    private void Update()
    {
        _rb.velocity = Vector3.left * _speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A))
        {
            _speed = 500;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _speed = -500;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _speed = 0;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            _speed = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            ball.gameObject.SetActive(false);
            Progress.Instance._coin++;
            point++;
            _textPoint.text = point.ToString();
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
            if (Progress.Instance._point < point)
            {
                Progress.Instance._point = point;
            }
            Debug.Log("ÏÐÀÈÃÐÀÀÀÀÀÀÀÀÀÀÀÀÀÀÀÀÀÀÀÀÀÀÀÀÀË!!!!!!!!!!!!");
            _diedPanel.SetActive(true);
        }

    }
}
