using System.Runtime.InteropServices;
using UnityEngine;

public class AddPoint : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);
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
        if (_point > Progress.Instance.PlayerInfo.Point)
        {
            Progress.Instance.PlayerInfo.Point = _point;
            SetToLeaderboard(_point);
        }
    }
}
