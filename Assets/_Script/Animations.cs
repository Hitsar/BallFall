using DG.Tweening;
using TMPro;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private GameObject _healthText, _pointText, _restartButton, _exitButton;
    [SerializeField] private TextMeshProUGUI _healthTextColor, _pointTextColor;

    [SerializeField] private GameObject _bar;

    public void HealthAnimation()
    {
        _healthText.transform.DOScale(Vector3.one, 0.7f).SetEase(Ease.OutBack);
        _healthTextColor.DOColor(Color.yellow, 0.3f).OnComplete(() =>
        {
            _healthTextColor.DOColor(Color.red, 0.3f);
        });
        _healthText.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void PointAnimation()
    {
        _pointText.transform.DOScale(Vector3.one, 0.7f).SetEase(Ease.OutBack);
        _pointTextColor.DOColor(Color.green, 0.3f).OnComplete(() =>
        {
            _pointTextColor.DOColor(Color.white, 0.3f);
        });
        _pointText.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void DiedMenuAnimation()
    {
        _bar.SetActive(true);
        _restartButton.transform.DOLocalMoveY(45, 0.7f).SetEase(Ease.OutQuint).OnComplete(() =>
        {
            _restartButton.transform.DOScale(Vector3.one, 0.6f).SetEase(Ease.OutBack);
        });

        _exitButton.transform.DOLocalMoveY(-110, 0.7f).SetDelay(0.3f).SetEase(Ease.OutQuint).OnComplete(() =>
        {
            _exitButton.transform.DOScale(Vector3.one, 0.6f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                Time.timeScale = 0;
            });
        });
    }
}
