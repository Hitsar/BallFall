using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();
    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);

    [SerializeField] private TextMeshProUGUI _textRecord;

    private void Start()
    {
        ShowAdv();
        _textRecord.text = Progress.Instance.PlayerInfo.Point.ToString();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
