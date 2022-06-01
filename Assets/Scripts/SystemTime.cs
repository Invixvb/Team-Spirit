using TMPro;
using UnityEngine;

public class SystemTime : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private float _currentTime;

    private void Update()
    {
        timeText.text = System.DateTime.Now.ToString("HH:mm:ss");
    }
}
