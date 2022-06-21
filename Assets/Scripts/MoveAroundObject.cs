using UnityEngine;

/* 
 * This script allows the player to press the CTRL-Key ingame and rotate the camera around the hand object.
 * It is attached to the Main Camera. The basic idea is from https://www.youtube.com/watch?v=zVX9-c_aZVg
 * There are several parameters that can be changed in the Main Camera:
 * Mouse Sensitivity: Decides, how moving the mouse moves the camera. The higher, the stronger this will be. Default Value = 3.0f
 * Target: The Object, around which the camera should rotate. Default: FirstPersonHand_L
 * Distance: The distance that should be between the camera and the target object. Default Value = 3.0f
 */

public class MoveAroundObject : MonoBehaviour
{
    public float mouseSensitivity = 3.0f;
    public Transform target;
    public float distance = 3.0f;

    private float rotationY;
    private float rotationX;

    /* 
     * Sets the camera to the correct position
     */
    void Start()
    {
        Vector3 centerPosition = target.position + new Vector3(0, 1, 0);
        transform.position = centerPosition - transform.forward * distance;
    }

    /*
     * If the left CTRL is pressed, it will rotate the camera around the target object
     * in the correct direction.
     */
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) == true)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            rotationY += mouseX;
            rotationX += mouseY;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

            Vector3 centerPosition = target.position + new Vector3(0, 1, 0);

            transform.position = centerPosition - transform.forward * distance;
        }
    }
}
