using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public int _coin;
    public int _point;
    public bool _phone;

    public static Progress Instance;

    private void Awake()
    {
        if (Instance == null)
        {
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
