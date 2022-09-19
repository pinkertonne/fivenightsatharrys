using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shitheads : MonoBehaviour
{
    public enum ShitheadType { Rain, Isaac, Preston, Harry };
    public ShitheadType shitheadName;
    public Transform[] locations;
    public const float MOVE_TIME = 4.5f;
    public int difficulty;
    public int currentLoc;
    public static int phase = 1;
    public GameObject curtainRight;
    public static bool prestonLocked = false;
    public static bool harryLocked = false;
    public Transform[] rightCurtainLocs;
    int presPenalty = 0;

    // Start is called before the first frame update
    void Start()
    {
        switch (shitheadName)
        {
            case ShitheadType.Rain:
                difficulty = ShitheadManager.rainDiff;
                break;
            case ShitheadType.Isaac:
                difficulty = ShitheadManager.isaacDiff;
                break;
            case ShitheadType.Preston:
                difficulty = ShitheadManager.presDiff;
                break;
            case ShitheadType.Harry:
                difficulty = ShitheadManager.harryDiff;
                break;
            default:
                difficulty = 0;
                break;
        }
        InvokeRepeating("Move", MOVE_TIME, MOVE_TIME);
    }

    // Update is called once per frame
    void Update()
    {
        if (shitheadName == ShitheadType.Preston && currentLoc == 3 && CamViewer.curCam == 9) //look at the end of this in case of issues where the jumpscare doesnt work correctly
        {
            transform.Translate(Vector3.forward * 10 * Time.deltaTime);
            StartCoroutine(PresAttack());
        }

        if (shitheadName == ShitheadType.Preston && prestonLocked && CamViewer.curCam == 0)
        {
            prestonLocked = false;
            StartCoroutine(UnlockPres());
        }
    }

    void Move()
    {
        if (difficulty >= Random.Range(1,21))
        {
            switch (shitheadName)
            {
                case ShitheadType.Rain:
                    if (currentLoc == 0)
                    {
                        currentLoc = 1;
                        gameObject.transform.position = locations[1].position;
                        gameObject.transform.rotation = locations[1].rotation;
                    } 
                    else if (currentLoc == 4)
                    {
                        if (Door.rightIsClosed)
                        {
                            currentLoc = 0;
                            gameObject.transform.position = locations[0].position;
                            gameObject.transform.rotation = locations[0].rotation;
                        }
                        else
                        {
                            Attack();
                        }
                    } 
                    else
                    {
                        int n = Random.Range(currentLoc - 1, currentLoc + 1);
                        if (n > currentLoc - 1) //doing it this way ensures that you dont move to the place you're already at
                        {
                            n += 1;
                        }
                        currentLoc = n; 
                        gameObject.transform.position = locations[currentLoc].position;
                        gameObject.transform.rotation = locations[currentLoc].rotation;

                    }
                    break;
                case ShitheadType.Isaac:

                    if (currentLoc == 5)
                    {
                        if (Door.leftIsClosed)
                        {
                            currentLoc = 0;
                            gameObject.transform.position = locations[0].position;
                            gameObject.transform.rotation = locations[0].rotation;
                        }
                        else
                        {
                            Attack();
                        }
                    }
                    else
                    {
                        int n = Random.Range(0, 6);
                        if (n > currentLoc - 1)
                        {
                            n += 1;
                        }
                        currentLoc = n;
                        gameObject.transform.position = locations[currentLoc].position;
                        gameObject.transform.rotation = locations[currentLoc].rotation;
                    }
                    break;
                case ShitheadType.Preston:
                    if (CamViewer.curCam != 0)
                    {
                        prestonLocked = true;
                        break;
                    }
                    else if (prestonLocked)
                    {
                        break;
                    }

                    switch (phase)
                    {
                        case 1:
                            phase++;
                            curtainRight.transform.position = rightCurtainLocs[1].position;
                            currentLoc = 1;
                            gameObject.transform.position = locations[1].position;
                            gameObject.transform.rotation = locations[1].rotation;
                            break;
                        case 2:
                            phase++;
                            curtainRight.transform.position = rightCurtainLocs[2].position;
                            currentLoc = 2;
                            gameObject.transform.position = locations[2].position;
                            gameObject.transform.rotation = locations[2].rotation;
                            break;
                        case 3:
                            phase = -1;
                            currentLoc = 3;
                            curtainRight.transform.position = rightCurtainLocs[3].position;
                            StartCoroutine(PresAttackDelayed());
                            break;
                    }
                    break;
                case ShitheadType.Harry:
                    if (CamViewer.curCam != 0)
                    {
                        break;
                    }
                    else
                    {
                        StartCoroutine(HarryMove());
                    }
                    break;
            }
            //gameObject.transform.position = locations[0].position;
            //gameObject.transform.rotation = locations[0].rotation;
            //currentLoc = 0;
        }
    }

    void Attack()
    {
        Debug.Log("JUMPSCARE");
    }

    IEnumerator PresAttack()
    {
        yield return new WaitForSeconds(2.5f);
        Attack();
    }

    IEnumerator PresAttackDelayed()
    {
        yield return new WaitForSeconds(25);
        if (Door.rightIsClosed)
        {
            phase = 1;
            currentLoc = 0;
            gameObject.transform.position = locations[0].position;
            gameObject.transform.rotation = locations[0].rotation;
            Power.power -= 1 + presPenalty;
            presPenalty += 6;
        }
        else if (currentLoc != 3) //look for this when troubleshooting as well
        {
            phase = 1;
            currentLoc = 0;
            gameObject.transform.position = locations[0].position;
            gameObject.transform.rotation = locations[0].rotation;
        }
        else
        {
            Attack();
        }
    }

    IEnumerator UnlockPres()
    {
        yield return new WaitForSeconds(Random.Range(0.83f, 16.67f));
        prestonLocked = false;
    }

    IEnumerator HarryMove()
    {
        float n = (1000 - 100 * difficulty) / 60;
        if (n < 0)
        {
            n = 0;
        }
        yield return new WaitForSeconds(n);
        if (currentLoc < 5)
        {
            currentLoc++;
            gameObject.transform.position = locations[currentLoc].position;
            gameObject.transform.rotation = locations[currentLoc].rotation;
        }
        else if (CamViewer.curCam != 10 && CamViewer.curCam != 0 && !Door.rightIsClosed)
        {
            Attack();
        }
    }
}
