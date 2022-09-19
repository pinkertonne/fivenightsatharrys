using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLight : MonoBehaviour
{
    public static bool leftLightOn = false;
    public static bool rightLightOn = false;

    public GameObject light;

    public void OnMouseDown()
    {
        if (light.activeSelf == false)
        {
            light.SetActive(true);
        }
        else
        {
            light.SetActive(false);
        }

    }
}
