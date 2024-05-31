using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicController : MonoBehaviour
{
    public void StopGameMusic()
    {
        GameMusic.Instance.StopMusic();
    }

    public void StartGameMusic()
    {
        GameMusic.Instance.StartMusic();
    }
}
