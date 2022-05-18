using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Keycode : MonoBehaviour
{
    private string currentPass = "123"; 
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("keycode") == 1)
        {
            
            NextScene();
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void Checkpass(string pass)
    {
        if (pass == currentPass)
        {
           print("" + "Correct");
         PlayerPrefs.SetFloat("keycode", 1);
         NextScene();
        }
        else
        {
           print("Try again");

        }

    }

    private void NextScene()
    {

        SceneManager.LoadScene(1);

    }

  
}
