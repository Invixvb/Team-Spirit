using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HostSettings : MonoBehaviour
{
    private int TimePerGame,playerAmount,ThemeAmount;
    private bool advancedSetting;
    
    // Start is called before the first frame update
    void Start()
    {
        GameTime(30);
        setPlayerAmount(4);
        setThemeAmount(5);
        setDifficulty(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void GameTime(int timeAmount)
   {

       TimePerGame = timeAmount;
   }

   public void setPlayerAmount(int players)
   {
       playerAmount = players;

   }

   public void setThemeAmount(int Themes)
   {

       ThemeAmount = Themes;
   }

   public void setDifficulty(bool isAdvanced)
   {
       advancedSetting = isAdvanced;

   }
}
