using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public static GameMusic Instance;

    private AudioSource _as;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _as = GetComponent<AudioSource>();
    }

    public void StopMusic()
    {
        _as.Stop();
    }

    public void StartMusic()
    {
        _as.Play();
    }
}
