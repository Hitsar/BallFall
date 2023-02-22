using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    private Animations _animations;

    private void Start()
    {
        _animations = FindObjectOfType<Animations>().GetComponent<Animations>();
    }

    public void Enabling()
    {
        _panel.SetActive(true);
        _animations.DiedMenuAnimation();
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
