using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UiButton : MonoBehaviour
{
    public void start()
    {
        SceneManager.LoadScene("Game");
    }


    public void score()
    {
        SceneManager.LoadScene("High_Score");
    }

    public void over()
    {
        SceneManager.LoadScene("Game_Over");
    }

   public void inicio()
    {
        SceneManager.LoadScene("Start_Game");
    }

}
