using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SystemTime : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = System.DateTime.Now.ToString("HH:mm:ss");
    }
}
