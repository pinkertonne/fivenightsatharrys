using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamViewer : MonoBehaviour
{
    public Camera[] cams;
    public Canvas camerasCanvas;
    public Text camText;
    //public Canvas gameCanvas;
    public static int curCam = 0;
    private int savedCam = 1;
    public GameObject leftScroll;
    public GameObject rightScroll;

    public void OpenCams()
    {
        //Come back to this to add a way to remember what the last cam was before the player drops the cam screen.
        if (curCam == 0)
        {
            cams[0].gameObject.SetActive(false);
            cams[savedCam].gameObject.SetActive(true);
            camerasCanvas.gameObject.SetActive(true);
            leftScroll.SetActive(false);
            rightScroll.SetActive(false);
            curCam = savedCam;
            camText.text = "Camera " + curCam;
        }
        else
        {
            cams[curCam].gameObject.SetActive(false);
            cams[0].gameObject.SetActive(true);
            camerasCanvas.gameObject.SetActive(false);
            leftScroll.SetActive(true);
            rightScroll.SetActive(true);
            savedCam = curCam;
            curCam = 0;
        }
        //if (curCam == 0 || !unchanged)
        //{
        //  cams[curCam].gameObject.SetActive(false);
        // cams[prevCam].gameObject.SetActive(true);
        ////gameCanvas.gameObject.SetActive(false);
        //camerasCanvas.gameObject.SetActive(true);
        //camText.text = "Camera " + prevCam;
        //if (unchanged)
        //{
        //   prevCam = curCam;
        // curCam = 1;
        //}

        //} 
        //else
        //{
        //   cams[curCam].gameObject.SetActive(false);
        // cams[0].gameObject.SetActive(true);
        ////gameCanvas.gameObject.SetActive(true);
        //camerasCanvas.gameObject.SetActive(false);
        //prevCam = curCam;
        //curCam = 0;
        //unchanged = false;
        //}
    }

    public void SwitchCam(int camNo)
    {
        if (camNo == curCam)
        {
            return;
        } 
        else
        {
            cams[camNo].gameObject.SetActive(true);
            cams[curCam].gameObject.SetActive(false);
            curCam = camNo;
            camText.text = "Camera " + curCam;
        }
    }
}
