using DG.Tweening;
using UnityEngine;

public class MenuAnimations : MonoBehaviour
{
    [SerializeField] private GameObject _startButton, _recordText;
    public void Start()
    {
        _startButton.transform.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutElastic).OnComplete(() =>
        {
            _startButton.transform.DOScale(new Vector3(1.15f, 1.15f, 1.15f), 0.7f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        });
        _recordText.transform.DOLocalMoveY(-110, 1f).SetEase(Ease.OutBack);
    }
}
