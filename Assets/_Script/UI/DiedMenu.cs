using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    public void Enabling()
    {
        Time.timeScale = 0;
        _panel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
