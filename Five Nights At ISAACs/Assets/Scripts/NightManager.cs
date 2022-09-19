using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NightManager : MonoBehaviour
{
    public static int night = 1;

    public static void nextNight()
    {
        if (night < 5)
        {
            night++;
            SceneManager.LoadScene("SurvivedScreen");
        }
        else
        {
            SceneManager.LoadScene("Win");
            //win the game
        }
    }
}