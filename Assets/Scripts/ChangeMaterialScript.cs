using UnityEngine;

/* A simple script, that loads all images which are contained in Assets/Resources/Backgrounds/PlaneBackgrounds at Start
 * and calls the ChangeBackground Method()
 * 
 * Calling the ChangeBackground Method changes the Texture of the Plane in MainScene to a random image contained in the Folder
 */
public class ChangeMaterialScript : MonoBehaviour
{

    public Object[] materials;
    Renderer rend;

    /* Gets called after pressing the Play Button in Unity.
     * Stores all images which are contained in Assets/Resources/Backgrounds/PlaneBackgrounds in the materials array.
     * Stores the Renderer-Component of the GameObject with the name Plane in the variable rend.
     * The Renderer contains the Texture of the Plane. The Texture can be changed.
     * Also executes function ChangeBackground() 
     */

    void Start()
    {
        materials = Resources.LoadAll("Backgrounds/PlaneBackgrounds", typeof(Texture));
        Resources.LoadAll("Backgrounds/PlaneBackgrounds", typeof(Texture));
        rend = GameObject.Find("Plane").GetComponent<Renderer>();
        rend.enabled = true;
        ChangeBackground();
    }

    /* When this function gets called, it gets a random number between 0 and the amount of backgrounds that are stored in materials.
     * It then sets the texture of rend (the renderer component of the Gameobject with the name Plane) 
     * to the Texture that is in the materials array at this position.
     */

    public void ChangeBackground()
    {
        int newBackgroundID = Random.Range(0, materials.Length);
        Debug.Log("Creating new Background with id " + newBackgroundID);
        rend.material.mainTexture = (Texture)materials[newBackgroundID];
    }
}
