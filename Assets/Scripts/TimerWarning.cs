using TMPro;
using UnityEngine;

public class TimerWarning : MonoBehaviour
{
    private float _timeLeft;
    private bool _gameStarted, _gameIsOver, _firstMark, _checkTwice, _noTimeLeft;
    public float timeInMinutes;
    private float _timeAmount;
    [SerializeField] private TextMeshProUGUI text;
    public GameObject textObj;
    public GameObject popUpPanel;

    private void Start()
    {
        _timeAmount = timeInMinutes * 60;
        _timeLeft = _timeAmount;
        _gameStarted = true;
        
        if (timeInMinutes > 5)
        {
            _checkTwice = true;
        }
    }

    private void Update()
    {
        if (_gameStarted && !_gameIsOver && _timeLeft > 0)
        {
            _timeLeft -= 1 * Time.deltaTime;
        }

        if (_timeLeft <= 5 * 60 && !_firstMark)
        {
            if (_checkTwice)
            {
                PopUp("5 MINUTES LEFT");
            }

            _firstMark = true;
        }

        if (_timeLeft <= 1 * 60 && _firstMark && !_noTimeLeft)
        {
            PopUp("1 MINUTES LEFT");
            _noTimeLeft = true;
        }
    }

    public void PopUp(string timeAmount)
    {
        text.SetText(timeAmount);
        popUpPanel.SetActive(true);
    }

    public void ResumeWarning()
    {
        Debug.Log("IT be working tho");
        popUpPanel.SetActive(false);
    }
}
