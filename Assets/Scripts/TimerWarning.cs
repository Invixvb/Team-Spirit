using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TimerWarning : MonoBehaviour
{
    private float _timeLeft;
    private bool _gameStarted, _gameIsOver, FirstMark, checkTwice, NoTimeLeft;
    public float timeInMinutes;
    private float _timeAmount; 
    [SerializeField] TextMeshProUGUI _text;
   public GameObject TextObj;
    public GameObject PopUpPanel;
    private void Start()
    {
        _timeAmount = timeInMinutes * 60;
        _timeLeft = _timeAmount;
        _gameStarted = true;
        if (timeInMinutes > 5)
        {
            checkTwice = true;
        }
    }

    private void Update()
    {
        if (_gameStarted && !_gameIsOver && _timeLeft > 0 )
        {
            _timeLeft -= 1 * Time.deltaTime;
        }

        if (_timeLeft <= 5 * 60 && !FirstMark)
        {
            if (checkTwice)
            {
                PopUP("5 MINUTES LEFT");
            }

            FirstMark = true;
        }

        if (_timeLeft <= 1 * 60 && FirstMark && !NoTimeLeft)
        {
            PopUP("1 MINUTES LEFT");
            NoTimeLeft = true;
        }
    }

   public void PopUP(string timeAmount)
    {
        _text.SetText(timeAmount);
        PopUpPanel.SetActive(true);
       
    }

   public void ResumeWarning()
   {
       Debug.Log("IT be working tho");
       PopUpPanel.SetActive(false);
   }
}
