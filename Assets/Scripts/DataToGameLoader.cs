using System;
using System.Collections.Generic;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataToGameLoader : MonoBehaviour
{
    #region Public variables
    [Header("Background Image")]
    public Image backgroundImage;
    
    [Header("Buttons")]
    public Button previousButton;
    public TextMeshProUGUI previousButtonText;
    public Button nextButton;
    public TextMeshProUGUI nextButtonText;
    
    [Header("Header Text")]
    public TextMeshProUGUI headerText;

    [Header("Local Time")]
    public Image localTimeBackgroundImage;
    public TextMeshProUGUI localTimeText;
    
    [Header("Footer")]
    public Image footerBackgroundImage;
    public TextMeshProUGUI footerText;
    
    [Header("Timer")]
    public Image timerBackgroundImage;
    public TextMeshProUGUI timerText;

    [Header("Header Image")]
    public Image headerImage;
    #endregion

    private int _selectedThemeIndex;
    private int _selectedLevelIndex;
    private int _currentSlideIndex;
    
    private List<SO_Slide> _currentThemeLevelList = new();

    private SO_Theme _selectedTheme;

    private void Start()
    {
        _selectedTheme = CustomizationWindow.Instance.themeList[_selectedThemeIndex];
    }

    private void Update()
    {
        LocalTimerUpdate();
    }
    
    private void LocalTimerUpdate() => localTimeText.text = DateTime.Now.ToString("HH:mm");

    private void LoadDataFromSo()
    {
        var currentSlide = _currentThemeLevelList[_currentSlideIndex];
        _currentSlideIndex++;
    }

    //nextButton.GetComponentInChildren<TextMeshProUGUI>().text = name;

    //Get the host settings menu selected theme and level
    //Get the list and put it into a list here.
    //Load in the data from the first SO_Slide into the placeholders.
    //When clicked on a next button the next SO_Slide is loaded into the placeholders.
    //Last slide button, go back and load the previous slides data.
    //If the list is out of range/on the last index then put it onto the EndScreen slide.
}
