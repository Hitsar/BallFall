using System.Runtime.InteropServices;
using UnityEngine;

public class AddPoint : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);
    private TextDisplay _textDisplay;
    private int _point;
    private Animations _animations;

    private void Start()
    {
        _textDisplay = FindObjectOfType<TextDisplay>().GetComponent<TextDisplay>();
        _animations = FindObjectOfType<Animations>().GetComponent<Animations>();
    }

    public void BallAddPoint()
    {
        _point++;
        _textDisplay.PointDisplay(_point);
        _animations.PointAnimation();
    }

    public void SetRecord()
    {
        if (_point > Progress.Instance.PlayerInfo.Point)
        {
            Progress.Instance.PlayerInfo.Point = _point;
          //  SetToLeaderboard(_point);
        }
    }
}
