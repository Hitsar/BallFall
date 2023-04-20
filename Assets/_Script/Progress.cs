using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class PlayerInfo
{
    public int Point;
}

public class Progress : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;
    public PlayerInfo PlayerInfo;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);
    [DllImport("__Internal")]
    private static extern void LoadExtern();

    public static Progress Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            LoadExtern();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
    }

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
    }

    public void MuteAudio() => _audioMixer.audioMixer.SetFloat("Master", -80);
    public void PlayAudio() =>  _audioMixer.audioMixer.SetFloat("Master", 0);
}