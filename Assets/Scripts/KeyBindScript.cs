using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

/*
 * This script manages all keybinds and executes the corresponding functions for it.
 * The keybinds are:
 * 1: lets the Player change a Base Bone of the Hand (when pressing q, w, e, r, t)
 * 2: lets the Player change a Middle Bone of the Hand (when pressing q, w, e, r, t)
 * 3: lets the Player change a End Bone of the Hand (when pressing q, w, e, r, t)
 * Q: Changes the selected bone of the thumb (direction changes depending if you press left shift or not)
 * W: Changes the selected bone of the index finger (direction changes depending if you press left shift or not)
 * E: Changes the selected bone of the middle finger (direction changes depending if you press left shift or not)
 * R: Changes the selected bone of the ring finger (direction changes depending if you press left shift or not)
 * T: Changes the selected bone of the pinky finger (direction changes depending if you press left shift or not)
 * Left Shift: If pressed together with Q, W, E, R or T, it moves the bone in the other direction compared to pressing Q, W, E, R or T alone
 * P: Creates a screenshot and stores it in the Assets/Screenshots folder
 * O: Randomizes different values of the Scene. 
 *    Things that can be activated to be randomized: Background, Ambient Sky Color, Directional Light, Shadow, Hand Position, Hand Rotation,
 *        Hand Scaling, Rotation of the Finger Bones
 *        Gesture will not be randomized and rather be set to the Value in Current Gesture Value of the Keybind Manager of the Scene.
 * H: Turns off/on the Hand Object
 * M: Makes multiple screenshots of the Scene and then randomizes the scene equally as the Button O does.
 *    The amount of images wanted can be set in the KeyBindManager Object in the Scene under Image Amount.
 * L: Changes the Gesture of the Hand.
 */

/*
 * All possible Gestures
 */
public enum Gesture
{
    BaseGesture,
    FistGesture,
    ThumbsUpGesture,
    PointGesture,
    RockOnGesture,
    PeaceGesture,
    CountThreeGesture,
    CountFourGesture,
    OkGesture,
    ShootGesture
}

public class KeyBindScript : MonoBehaviour
{
    public int ImageAmount = 100;
    public Gesture currentGesture;
    public bool handEnabled = true;

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    private int[] thumbBoneAngle = { 0, 0, 0 };
    private int[] indexBoneAngle = { 0, 0, 0 };
    private int[] middleBoneAngle = { 0, 0, 0 };
    private int[] ringBoneAngle = { 0, 0, 0 };
    private int[] pinkyBoneAngle = { 0, 0, 0 };

    private int currBoneRow = 0;

    private bool handActive = true;
    private GameObject hand;

    /*
     * Adding all the Keybinds to keys.
     * Setting hand to the Object with the Name FirstPersonHand_L of the Scene.
     * At last it calls changeScene() and SetGesture() to randomize scene and set gesture.
     */
    void Start()
    {
        keys.Add("shift", KeyCode.LeftShift);
        keys.Add("thumbBoneAngleChange", KeyCode.Q);
        keys.Add("indexBoneAngleChange", KeyCode.W);
        keys.Add("middleBoneAngleChange", KeyCode.E);
        keys.Add("ringBoneAngleChange", KeyCode.R);
        keys.Add("pinkyBoneAngleChange", KeyCode.T);
        keys.Add("screenshot", KeyCode.P);
        keys.Add("changeScene", KeyCode.O);
        keys.Add("firstRow", KeyCode.Alpha1);
        keys.Add("secondRow", KeyCode.Alpha2);
        keys.Add("thirdRow", KeyCode.Alpha3);
        keys.Add("hideHand", KeyCode.H);
        keys.Add("multipleImages", KeyCode.M);
        keys.Add("switchGesture", KeyCode.L);

        hand = GameObject.Find("FirstPersonHand_L");
        hand.SetActive(handEnabled);

        GetComponent<RandomizerScript>().changeScene();
        GetComponent<RandomizerScript>().SetGesture();
    }

    /*
     * On getting input (pressing a key), it checks if the Key is in the keys array.
     * If it is, then the corresponding part will be run. Effect of the Keypresses is documented at the beginning of the Script.
     */
    void Update()
    {
        if (Input.GetKeyDown(keys["thumbBoneAngleChange"]))
        {
            GameObject bone;
            if (currBoneRow == 0)
            {
                bone = GameObject.Find("FirstPersonHand_L/Wrist/MetaThumb/ThumbBase");
            } else if (currBoneRow == 1)
            {
                bone = GameObject.Find("FirstPersonHand_L/Wrist/MetaThumb/ThumbBase/ThumbMiddle");
            } else
            {
                bone = GameObject.Find("FirstPersonHand_L/Wrist/MetaThumb/ThumbBase/ThumbMiddle/ThumbEnd");
            }

            if (Input.GetKey(keys["shift"]))
            {
                Debug.Log("Currently at Angle " + thumbBoneAngle[currBoneRow]);
                thumbBoneAngle[currBoneRow]++;
                ChangeAngle(bone, 1);
            } else
            {
                Debug.Log("Currently at Angle " + thumbBoneAngle[currBoneRow]);
                thumbBoneAngle[currBoneRow]--;
                ChangeAngle(bone, -1);
            }
        }
        else if (Input.GetKeyDown(keys["indexBoneAngleChange"]))
        {
            GameObject bone;
            if (currBoneRow == 0)
            {
                bone = GameObject.Find("FirstPersonHand_L/Wrist/metaIndex/IndexBase");
            }
            else if (currBoneRow == 1)
            {
                bone = GameObject.Find("FirstPersonHand_L/Wrist/metaIndex/IndexBase/IndexMiddle");
            }
            else
            {
                bone = GameObject.Find("FirstPersonHand_L/Wrist/metaIndex/IndexBase/IndexMiddle/IndexEnd");
            }

            if (Input.GetKey(keys["shift"]))
            {
                Debug.Log("Currently at Angle " + indexBoneAngle[currBoneRow]);
                indexBoneAngle[currBoneRow]++;
                ChangeAngle(bone, 1);
            }
            else
            {
                Debug.Log("Currently at Angle " + indexBoneAngle[currBoneRow]);
                indexBoneAngle[currBoneRow]--;
                ChangeAngle(bone, -1);
            }
        }
        else if (Input.GetKeyDown(keys["middleBoneAngleChange"]))
        {
            GameObject bone;
            if (currBoneRow == 0)
            {
                bone = GameObject.Find("FirstPersonHand_L/Wrist/metaMiddle/MiddleBase");
            }
            else if (currBoneRow == 1)
            {
                bone = GameObject.Find("FirstPersonHand_L/Wrist/metaMiddle/MiddleBase/MiddleMiddle");
            }
            else
            {
                bone = GameObject.Find("FirstPersonHand_L/Wrist/metaMiddle/MiddleBase/MiddleMiddle/MiddleEnd");
            }

            if (Input.GetKey(keys["shift"]))
            {
                Debug.Log("Currently at Angle " + middleBoneAngle[currBoneRow]);
                middleBoneAngle[currBoneRow]++;
                ChangeAngle(bone, 1);
            }
            else
            {
                Debug.Log("Currently at Angle " + middleBoneAngle[currBoneRow]);
                middleBoneAngle[currBoneRow]--;
                ChangeAngle(bone, -1);
            }
        }
        else if (Input.GetKeyDown(keys["ringBoneAngleChange"]))
        {
            GameObject bone;
            if (currBoneRow == 0)
            {
                bone = GameObject.Find("FirstPersonHand_L/Wrist/metaRing/RingBase");
            }
            else if (currBoneRow == 1)
            {
                bone = GameObject.Find("FirstPersonHand_L/Wrist/metaRing/RingBase/RingMiddle");
            }
            else
            {
                bone = GameObject.Find("FirstPersonHand_L/Wrist/metaRing/RingBase/RingMiddle/RingEnd");
            }

            if (Input.GetKey(keys["shift"]))
            {
                Debug.Log("Currently at Angle " + ringBoneAngle[currBoneRow]);
                ringBoneAngle[currBoneRow]++;
                ChangeAngle(bone, 1);
            }
            else
            {
                Debug.Log("Currently at Angle " + ringBoneAngle[currBoneRow]);
                ringBoneAngle[currBoneRow]--;
                ChangeAngle(bone, -1);
            }
        }
        else if (Input.GetKeyDown(keys["pinkyBoneAngleChange"]))
        {
            GameObject bone;
            if (currBoneRow == 0)
            {
                bone = GameObject.Find("FirstPersonHand_L/Wrist/metaPinky/PinkyBase");
            }
            else if (currBoneRow == 1)
            {
                bone = GameObject.Find("FirstPersonHand_L/Wrist/metaPinky/PinkyBase/PinkyMiddle");
            }
            else
            {
                bone = GameObject.Find("FirstPersonHand_L/Wrist/metaPinky/PinkyBase/PinkyMiddle/PinkyEnd");
            }

            if (Input.GetKey(keys["shift"]))
            {
                Debug.Log("Currently at Angle " + pinkyBoneAngle[currBoneRow]);
                pinkyBoneAngle[currBoneRow]++;
                ChangeAngle(bone, 1);
            }
            else
            {
                Debug.Log("Currently at Angle " + pinkyBoneAngle[currBoneRow]);
                pinkyBoneAngle[currBoneRow]--;
                ChangeAngle(bone, -1);
            }
        }
        else if (Input.GetKeyDown(keys["screenshot"]))
        {
            makeScreenShot(0);
        }
        else if (Input.GetKeyDown(keys["changeScene"]))
        {
            GetComponent<RandomizerScript>().changeScene();
        }
        else if (Input.GetKeyDown(keys["firstRow"]))
        {
            currBoneRow = 0;
            Debug.Log("Now Enabled Bone Row 0: BaseBone");
        }
        else if (Input.GetKeyDown(keys["secondRow"]))
        {
            currBoneRow = 1;
            Debug.Log("Now Enabled Bone Row 1: MiddleBone");
        }
        else if (Input.GetKeyDown(keys["thirdRow"]))
        {
            currBoneRow = 2;
            Debug.Log("Now Enabled Bone Row 2: EndBone");
        }
        else if(Input.GetKeyDown(keys["hideHand"]))
        {
            handActive = !handActive;
            hand.SetActive(handActive);
        }
        else if(Input.GetKeyDown(keys["multipleImages"]))
        {
            StartCoroutine(generateMultipleImages());
        }
        else if(Input.GetKeyDown(keys["switchGesture"]))
        {
            int gestureEnumLength = System.Enum.GetNames(typeof(Gesture)).Length;
            currentGesture = (Gesture)(((int)currentGesture + 1) % gestureEnumLength);
            Debug.Log("current gesture: " + currentGesture.ToString());
        }

        void ChangeAngle(GameObject gameObject, int value)
        {
            Debug.Log(value < 0 ? "Decreasing Angle" : "Increasing Angle");
            Vector3 currRotation = gameObject.transform.eulerAngles;
            gameObject.transform.eulerAngles = currRotation + new Vector3(0, 0, value);
        }
    }

    /*
     * Generates Multiple screenshots, happens when the player presses M.
     * Changes scene, then creates screenshot and then waits 0.1 seconds before next loop.
     */
    IEnumerator generateMultipleImages()
    {
        for(int i = 0; i < ImageAmount; i++)
        {
            GetComponent<RandomizerScript>().changeScene();
            makeScreenShot(i);
            Debug.Log("at Image " + i);
            yield return new WaitForSeconds(0.0f);
        }
    }

    /*
     * Creates a screenshot and stores it in Assets/Screenshots
     */
    private void makeScreenShot(int imageCount)
    {
        System.DateTime currentTime = System.DateTime.Now;
        string year = currentTime.Year.ToString();
        string month = currentTime.Month.ToString();
        string day = currentTime.Day.ToString();
        string hour = currentTime.Hour < 10 ? "0" + currentTime.Hour.ToString() : currentTime.Hour.ToString();
        string minute = currentTime.Minute < 10 ? "0" + currentTime.Minute.ToString() : currentTime.Minute.ToString();
        string second = currentTime.Second < 10 ? "0" + currentTime.Second.ToString() : currentTime.Second.ToString();
        string stringTime = year + month + day + hour + minute + second + currentTime.Millisecond.ToString() + imageCount.ToString();

        ScreenCapture.CaptureScreenshot(Application.dataPath + "/Screenshots/CameraScreenshot" + stringTime + ".png");
        Debug.Log("Saved CameraScreenshot" + stringTime + ".png");
    }
}
