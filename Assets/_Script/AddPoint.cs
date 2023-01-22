using TMPro;
using UnityEngine;

public class AddPoint : MonoBehaviour
{
    private int _point;
    [SerializeField] private TextMeshProUGUI _textPoint;

    public void BallAddPoint()
    {
        _point++;
        _textPoint.text = _point.ToString();
    }

    public void SetRecord()
    {
        if (_point > Progress.Instance.PlayerInfo._point)
            Progress.Instance.PlayerInfo._point = _point;
    }
}
