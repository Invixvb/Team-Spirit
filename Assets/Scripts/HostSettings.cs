using UnityEngine;

public class HostSettings : MonoBehaviour
{
    private int _timePerGame, _playerAmount, _themeAmount;
    private bool _advancedSetting;

    private void Start()
    {
        GameTime(30);
        SetPlayerAmount(4);
        SetThemeAmount(5);
        SetDifficulty(false);
    }

    public void GameTime(int timeAmount)
    {
        _timePerGame = timeAmount;
    }

    public void SetPlayerAmount(int players)
    {
        _playerAmount = players;
    }

    public void SetThemeAmount(int themes)
    {
        _themeAmount = themes;
    }

    public void SetDifficulty(bool isAdvanced)
    {
        _advancedSetting = isAdvanced;
    }
}
