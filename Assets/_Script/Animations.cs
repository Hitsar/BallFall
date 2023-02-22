using DG.Tweening;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private GameObject _healthText, _pointText, _restartButton, _exitButton;


    public void HealthAnimation()
    {
        _healthText.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutElastic);
        _healthText.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }

    public void PointAnimation()
    {
        _pointText.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutElastic);
        _pointText.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }

    public void DiedMenuAnimation()
    {
        _restartButton.transform.DOLocalMoveY(45, 0.8f).SetEase(Ease.OutQuint).OnComplete(() =>
        {
            _restartButton.transform.DOScale(Vector3.one, 0.6f).SetEase(Ease.OutBack);
        });

        _exitButton.transform.DOLocalMoveY(-110, 0.8f).SetDelay(0.3f).SetEase(Ease.OutQuint).OnComplete(() =>
        {
            _exitButton.transform.DOScale(Vector3.one, 0.6f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                Time.timeScale = 0;
            });
        });
    }
}
