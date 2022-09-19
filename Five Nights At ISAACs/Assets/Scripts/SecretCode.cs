using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCode : MonoBehaviour
{
    private string[] cheatCode;
    private int index;
    public AudioSource cheatsong;

    void Start()
    {
        cheatCode = new string[] { "b", "o", "o", "b", "s" };
        index = 0;
    }

    void Update()
    {
        // Check if any key is pressed
        if (Input.anyKeyDown)
        {
            Debug.Log("key found");
            // Check if the next key in the code is pressed
            if (Input.GetKeyDown(cheatCode[index]))
            {
                // Add 1 to index to check the next key in the code
                Debug.Log("Correct key");
                index++;
            }
            // Wrong key entered, we reset code typing
            else
            {
                index = 0;
            }
        }

        if (index == cheatCode.Length)
        {
            Debug.Log("Correct code");
            cheatsong.Play();
            index = 0;
        }
    }
}
