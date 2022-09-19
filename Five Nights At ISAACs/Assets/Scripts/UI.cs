using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text nightText;

    private void Awake()
    {
        nightText.text = "Night " + NightManager.night;
    }
}
