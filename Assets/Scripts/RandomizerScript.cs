using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Randomizes the scene depending on the parameters enabled in the KeyBindManager Object
 * It can randomize the Background, the Ambient Sky Color, the Directional Light, the Shadow, the Hand Position, Rotation and Scaling and the Rotation of the Bones of the Finger
 */
public class RandomizerScript : MonoBehaviour
{
    public bool enableRandomBackground = true;
    public bool enableRandomAmbientSkyColor = true;
    public bool enableRandomDirectionalLight = true;
    public bool enableRandomShadow = true;
    public bool enableRandomHandPositionRotationScale = true;
    public bool enableRandomFingerBonesRotation = true;

    /*
     * Changes Scene according to which changes are enabled in Randomizer.
     */
    public void changeScene()
    {
        if (enableRandomBackground)
        {
            GameObject.Find("Plane").GetComponent<ChangeMaterialScript>().ChangeBackground();
        }

        if (enableRandomAmbientSkyColor)
        {
            RenderSettings.ambientSkyColor = new Color(UnityEngine.Random.Range(0.8f, 1.0f), UnityEngine.Random.Range(0.8f, 1.0f), UnityEngine.Random.Range(0.8f, 1.0f));
        }

        if (enableRandomDirectionalLight)
        {
            GameObject.Find("Directional Light").GetComponent<Light>().intensity = UnityEngine.Random.Range(0.05f, 1.0f);
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                GameObject.Find("Directional Light").GetComponent<Light>().shadows = LightShadows.Hard;
            }
            else
            {
                GameObject.Find("Directional Light").GetComponent<Light>().shadows = LightShadows.Soft;
            }
            GameObject.Find("Directional Light").GetComponent<Light>().shadowStrength = UnityEngine.Random.Range(0.5f, 1.0f);
            GameObject.Find("Directional Light").GetComponent<Transform>().rotation = new Quaternion(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f));
        }

        if (enableRandomShadow)
        {
            GameObject.Find("ShadowCube0").GetComponent<Transform>().position = new Vector3(UnityEngine.Random.Range(-5.0f, 5.0f), 7, UnityEngine.Random.Range(-12.0f, -2.0f));
            GameObject.Find("ShadowCube0").GetComponent<Transform>().localScale = new Vector3(UnityEngine.Random.Range(1.0f, 5.0f), 1, UnityEngine.Random.Range(1.0f, 5.0f));

        }

        if (enableRandomHandPositionRotationScale)
        {
            if (GetComponent<KeyBindScript>().handEnabled)
            {
                GameObject.Find("FirstPersonHand_L").GetComponent<Transform>().position = new Vector3(UnityEngine.Random.Range(-0.25f, 0.25f), UnityEngine.Random.Range(1.0f, 1.5f), UnityEngine.Random.Range(-7.5f, -8.0f));
                GameObject.Find("FirstPersonHand_L").GetComponent<Transform>().rotation = Quaternion.Euler(UnityEngine.Random.Range(-70, -110), 90, 90);
                GameObject.Find("FirstPersonHand_L").GetComponent<Transform>().localScale = new Vector3(UnityEngine.Random.Range(9, 11), UnityEngine.Random.Range(9, 11), UnityEngine.Random.Range(9, 11));
                GameObject.Find("FirstPersonHand_L").GetComponent<ChangeSkinScript>().ChangeSkin();
            }
        }
        if (enableRandomFingerBonesRotation)
        {
            if (GetComponent<KeyBindScript>().handEnabled)
            {
                GameObject.Find("FirstPersonHand_L/Wrist/metaIndex/IndexBase").GetComponent<Transform>().localRotation = Quaternion.Euler(UnityEngine.Random.Range(271.499847f, 289.699982f), 267.02179f, 69.0179672f);
                GameObject.Find("FirstPersonHand_L/Wrist/metaMiddle/MiddleBase").GetComponent<Transform>().localRotation = Quaternion.Euler(UnityEngine.Random.Range(265.0f, 275.0f), 86.2079849f, 244.367996f);
                GameObject.Find("FirstPersonHand_L/Wrist/metaRing/RingBase").GetComponent<Transform>().localRotation = Quaternion.Euler(UnityEngine.Random.Range(270.0f, 275.0f), 97.3600311f, 241.058975f);
                GameObject.Find("FirstPersonHand_L/Wrist/metaPinky/PinkyBase").GetComponent<Transform>().localRotation = Quaternion.Euler(UnityEngine.Random.Range(276.499939f, 288.599976f), 122.299988f, 222.286026f);
            }
        }

        SetGesture();
    }

    /*
     * Sets the FirstPersonHand to the Gesture specified in CurrentGesture of the KeyBindScript
     */
    public void SetGesture()
    {
        switch (GetComponent<KeyBindScript>().currentGesture)
        {
            case Gesture.BaseGesture:
                break;
            case Gesture.FistGesture:
                GameObject.Find("FirstPersonHand_L").GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/SetFistGesture", typeof(RuntimeAnimatorController));
                break;
            case Gesture.ThumbsUpGesture:
                GameObject.Find("FirstPersonHand_L").GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/SetThumbsUpGesture", typeof(RuntimeAnimatorController));
                break;
            case Gesture.PointGesture:
                GameObject.Find("FirstPersonHand_L").GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/SetPointGesture", typeof(RuntimeAnimatorController));
                break;
            case Gesture.RockOnGesture:
                GameObject.Find("FirstPersonHand_L").GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/SetRockOnGesture", typeof(RuntimeAnimatorController));
                break;
            case Gesture.PeaceGesture:
                GameObject.Find("FirstPersonHand_L").GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/SetPeaceGesture", typeof(RuntimeAnimatorController));
                break;
            case Gesture.CountThreeGesture:
                GameObject.Find("FirstPersonHand_L").GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/SetCountThreeGesture", typeof(RuntimeAnimatorController));
                break;
            case Gesture.CountFourGesture:
                GameObject.Find("FirstPersonHand_L").GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/SetCountFourGesture", typeof(RuntimeAnimatorController));
                break;
            case Gesture.OkGesture:
                GameObject.Find("FirstPersonHand_L").GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/SetOkGesture", typeof(RuntimeAnimatorController));
                break;
            case Gesture.ShootGesture:
                GameObject.Find("FirstPersonHand_L").GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animations/SetShootGesture", typeof(RuntimeAnimatorController));
                break;
        }
    }
}
