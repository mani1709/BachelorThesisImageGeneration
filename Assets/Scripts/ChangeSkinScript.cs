using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script changes the hand skin of the FirstPersonHand_L object in the MainScene.
 * It is attached to the FirstPersonHand_L
 */

public class ChangeSkinScript : MonoBehaviour
{
    Object[] materials;
    SkinnedMeshRenderer rend;

    /* Gets called after pressing the Play Button in Unity.
     * Stores all images which are contained in Assets/Resources/HandSkins in the materials array.
     * Stores the SkinnedMeshRenderer-Component of the GameObject with the name Hand_Mesh in the variable rend.
     * This is the Mesh of the FirstPersonHand_L object.
     * The Renderer contains the Texture of the Hand. The Texture can be changed.
     * Also executes function ChangeSkin() 
     */
    void Start()
    {
        materials = Resources.LoadAll("HandSkins", typeof(Material));
        Debug.Log(materials.Length);
        rend = GameObject.Find("Hand_Mesh").GetComponent<SkinnedMeshRenderer>();
        rend.enabled = true;
        ChangeSkin();
    }

    /* When this function gets called, it gets a random number between 0 and the amount of skins that are stored in materials.
     * It then sets the texture of rend (the SkinnedMeshRenderer component of the Gameobject with the name Hand_Mesh) 
     * to the Texture that is in the materials array at this position.
     */
    public void ChangeSkin()
    {
        int newSkinID = Random.Range(0, materials.Length);
        Debug.Log("Creating new Skin with id " + newSkinID);
        rend.material = (Material)materials[newSkinID];
    }
}
