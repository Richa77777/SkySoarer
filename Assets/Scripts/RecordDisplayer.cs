using TMPro;
using UnityEngine;

public class RecordDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _recordText;

    private void Awake()
    {
        _recordText.text = "Your Record: " + PlayerPrefs.GetInt("Record", 0);
    }
}
