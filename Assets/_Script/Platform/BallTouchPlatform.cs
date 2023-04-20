using UnityEngine;

public class BallTouchPlatform : MonoBehaviour
{
    private AddPoint _addPoint;

    private void Start() =>   _addPoint = GetComponent<AddPoint>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            ball.gameObject.SetActive(false);
            _addPoint.BallAddPoint();
        }
    }
}
