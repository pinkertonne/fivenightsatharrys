using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    private IEnumerator routine;
    public AudioSource night1, night2, night3, night4, night5;
    // Start is called before the first frame update
    private void Awake()
    {
        routine = playPhone(NightManager.night);
        StartCoroutine(routine);
    }

    IEnumerator playPhone(int night)
    {
        yield return new WaitForSeconds(3);

        switch (night)
        {
            case 1:
                night1.Play();
                break;
            case 2:
                night2.Play();
                break;
            case 3:
                night3.Play();
                break;
            case 4:
                night4.Play();
                break;
            case 5:
                night5.Play();
                break;
        }

    }
}
