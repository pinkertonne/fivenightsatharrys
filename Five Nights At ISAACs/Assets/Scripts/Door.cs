using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static bool rightIsClosed = false;
    public static bool leftIsClosed = false;

    public GameObject door;

    public bool closing;
    public bool opening;
    public bool isRightDoor;

    public Transform rightOpen;
    public Transform leftOpen;
    public Transform rightClosed;
    public Transform leftClosed;

    public void OnMouseDown()
    {
        if (isRightDoor)
        {
            if (rightIsClosed && !opening)
            {
                StartCoroutine(OpenDoor(door, rightOpen.position, 0.15f));
                gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
            else if (!opening)
            {
                StartCoroutine(OpenDoor(door, rightClosed.position, 0.15f));
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        else
        {
            if (leftIsClosed && !opening)
            {
                StartCoroutine(OpenDoor(door, leftOpen.position, 0.15f));
                gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
            else if (!opening)
            {
                StartCoroutine(OpenDoor(door, leftClosed.position, 0.15f));
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    IEnumerator OpenDoor(GameObject gameObjectToMove, Vector3 newLoc, float duration)
    {
        if(opening)
        {
            yield break;
        }
        opening = true;

        Vector3 currentLoc = gameObjectToMove.transform.position;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;

            gameObjectToMove.transform.position = Vector3.Lerp(currentLoc, newLoc, counter / duration);

            yield return null;

        }

        opening = false;
        if (isRightDoor)
        {
            if (!rightIsClosed)
            {
                rightIsClosed = true;
            }
            else
            {
                rightIsClosed = false;
            }
        }
        else
        {
            if (!leftIsClosed)
            {
                leftIsClosed = true;
            }
            else
            {
                leftIsClosed = false;
            }
        }

    }
}
