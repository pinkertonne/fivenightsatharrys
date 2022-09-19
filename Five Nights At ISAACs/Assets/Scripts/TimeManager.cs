using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public int hour;
    public GameObject timeText;
    // Start is called before the first frame update
    public Shitheads rain, isaac, preston, harry;
    void Start()
    {
        timeText = GameObject.Find("UI/Panel/GameUI/TimeText");
        InvokeRepeating("UpdateHour", 60f, 60f);
    }

    // Update is called once per frame
    void UpdateHour()
    {
        if (hour < 5)
        {
            hour++;
            timeText.GetComponent<Text>().text = hour + " AM";
            Debug.Log("UPDATE");
            switch (hour)
            {
                case 2:
                    isaac.difficulty += 1;
                    break;
                case 3:
                    isaac.difficulty += 1;
                    rain.difficulty += 1;
                    preston.difficulty += 1;
                    break;
                case 4:
                    isaac.difficulty += 1;
                    rain.difficulty += 1;
                    preston.difficulty += 1;
                    break;
            }
        } 
        else
        {
            NightManager.nextNight();
            Debug.Log("YOU SURVIVED THE NIGHT");
        }
    }
}
