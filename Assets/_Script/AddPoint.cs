using UnityEngine;

public class AddPoint : MonoBehaviour
{
    private TextDisplay _textDisplay;
    private int _point;

    private void Start()
    {
        _textDisplay = FindObjectOfType<TextDisplay>().GetComponent<TextDisplay>();
    }

    public void BallAddPoint()
    {
        _point++;
        _textDisplay.PointDisplay(_point);
    }

    public void SetRecord()
    {
        if (_point > Progress.Instance.PlayerInfo._point)
        {
            Progress.Instance.PlayerInfo._point = _point;
        }
    }
}
