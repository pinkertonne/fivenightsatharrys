using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScroll : MonoBehaviour
{
    public Camera mainCam;
    public float rotationAngle = 0f;

    private Vector3 targetRotation;

    bool rotating = false;
    public GameObject objectToRotate;

    private IEnumerator coroutine;

    public enum position { left, right, middle};

    public position camPosition = position.middle;

    public void RotateLeft()
    {
        if (camPosition == position.middle)
        {
            Quaternion rotation2 = Quaternion.Euler(new Vector3(0, -45, 0));
            StartCoroutine(rotateObject(objectToRotate, rotation2, 0.25f));
        } else if (camPosition == position.right)
        {
            Quaternion rotation2 = Quaternion.Euler(new Vector3(0, 0, 0));
            StartCoroutine(rotateObject(objectToRotate, rotation2, 0.25f));
        } else
        {
            return;
        }

    }

    public void RotateRight()
    {
        if (camPosition == position.middle)
        {
            Quaternion rotation2 = Quaternion.Euler(new Vector3(0, 45, 0));
            StartCoroutine(rotateObject(objectToRotate, rotation2, 0.25f));
        }
        else if (camPosition == position.left)
        {
            Quaternion rotation2 = Quaternion.Euler(new Vector3(0, 0, 0));
            StartCoroutine(rotateObject(objectToRotate, rotation2, 0.25f));
        }
        else
        {
            return;
        }
    }

    IEnumerator rotateObject(GameObject gameObjectToMove, Quaternion newRot, float duration)
    {
        if (rotating)
        {
            yield break;
        }
        rotating = true;

        Quaternion currentRot = gameObjectToMove.transform.rotation;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObjectToMove.transform.rotation = Quaternion.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        rotating = false;
    }
}
