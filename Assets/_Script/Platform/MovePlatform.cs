using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Rigidbody _rigidbody;
    private Vector3 _moveInput;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _rigidbody.MovePosition(_rigidbody.position + _moveInput * _speed * Time.deltaTime);
    }

    public void ButtonLeft()
    {
        _moveInput.x = -1;
    }

    public void ButtonRight()
    {
        _moveInput.x = 1;
    }

    public void ButtonUp()
    {
        _moveInput.x = 0;
    }
}