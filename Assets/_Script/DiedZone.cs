using UnityEngine;

public class DiedZone : MonoBehaviour
{
    [SerializeField] private AudioSource _audioHit;

    private HealthPlatform _healthPlatform;

    private void Start()
    {
        _healthPlatform = FindObjectOfType<HealthPlatform>().GetComponent<HealthPlatform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            ball.gameObject.SetActive(false);
            _healthPlatform.TakeDamage(_audioHit);
            _audioHit.Play();
        }
    }
}
