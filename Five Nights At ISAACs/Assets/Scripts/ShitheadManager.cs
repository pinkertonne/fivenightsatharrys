using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitheadManager : MonoBehaviour
{
    public static int rainDiff;
    public static int isaacDiff;
    public static int presDiff;
    public static int harryDiff;
    public static int rainLoc;
    public static int isaacLoc;
    public static int presLoc;
    public static int harryLoc;

    public void Awake()
    {
        rainLoc = 1;
        isaacLoc = 1;
        presLoc = 1;
        harryLoc = 1;
        switch (NightManager.night)
        {
            case 1:
                harryDiff = 0;
                isaacDiff = 0;
                rainDiff = 0;
                presDiff = 0;
                break;
            case 2:
                harryDiff = 0;
                isaacDiff = 3;
                rainDiff = 1;
                presDiff = 1;
                break;
            case 3:
                harryDiff = 1;
                isaacDiff = 0;
                rainDiff = 5;
                presDiff = 2;
                break;
            case 4:
                harryDiff = Random.Range(1, 3);
                isaacDiff = 2;
                rainDiff = 4;
                presDiff = 6;
                break;
            case 5:
                harryDiff = 3;
                isaacDiff = 5;
                rainDiff = 7;
                presDiff = 5;
                break;
            default:
                break;
        }
    }
}