using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public static int power = 100;
    public Text powerText;

    private void Awake()
    {
        switch (NightManager.night)
        {
            case 2:
                InvokeRepeating("decreasePower", 6f, 6f);
                break;
            case 3:
                InvokeRepeating("decreasePower", 5f, 5f);
                break;
            case 4:
                InvokeRepeating("decreasePower", 4f, 4f);
                break;
            case 5:
                InvokeRepeating("decreasePower", 3f, 3f);
                break;
            default:
                break;
        }
    }

    public void decreasePower()
    {
        if (power > 0)
        {
            power -= 1;
            powerText.text = "Power: " + power + "%";
        }
        else
        {
            PowerDown();
        }
    }

    public void PowerDown()
    {
        Debug.Log("No power");
    }
}
