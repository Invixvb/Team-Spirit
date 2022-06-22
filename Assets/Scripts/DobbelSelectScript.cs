using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class DobbelSelectScript : MonoBehaviour
{
  [HideInInspector]  public int themeSelected;


    public void selectTheme(int themeIndex)
    {
        if (themeIndex == 5)
        {
            themeIndex = Random.Range(0, 5);
        }

        themeSelected = themeIndex;
        print(themeSelected);

    }
}