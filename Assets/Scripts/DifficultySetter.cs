using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySetter : MonoBehaviour
{
    public void SetDifficulty(int index)
    {
        PlayerPrefs.SetInt("Difficulty", index);
    }
}
