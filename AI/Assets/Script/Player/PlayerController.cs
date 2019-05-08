using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeedNormal = 1.0f, moveSpeedCrouching = 0.6f, movementSpeed = 0.0f, moveSpeedSprint = 1.8f;   //Movement Speed Defaults ~SUBJECT TO CHANGE~
    float noiseLevelNormal = 1.0f, noiseLevelCrouching = 0.5f, noiseLevelSprint = 1.6f, noiseLevel = 0.0f;   //Noise Defaults ~SUBJECT TO CHANGE~
    bool Crouch, Sprint; //Crouch & Sprinting Defaults
    float CrouchHeightNormal = 0.4332f, CrouchHeightCrouched = 0.5f, CrouchHeight = 1f; //Crouch Height Defaults  

    Vector3 MovementHorizontal = Vector3.zero, MovementVertical; //Movement Vectors
    float mouseHorizontal = 0.0f, mouseVertical = 0.0f;
    public float MouseSensitivity = 1f;
    CharacterController charController;
    public SphereCollider NoiseSphere;

    public SphereCollider Key1, Key2, Key3;
    

    private void Awake()
    {
        movementSpeed = moveSpeedNormal;
        noiseLevel = noiseLevelNormal;
        charController = GetComponent<CharacterController>();
        NoiseSphere = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        MovementHorizontal = (transform.forward * Input.GetAxis("Horizontal")); //A & D input
        MovementVertical = (transform.right * Input.GetAxis("Verticle")); //W & S input

        mouseHorizontal = Input.GetAxis("Mouse X"); //Mouse X input
        mouseVertical = Input.GetAxis("Mouse Y"); //Mouse Y input

        transform.Rotate(0.0f, (MouseSensitivity * mouseHorizontal), 0.0f); //Mouse Sensitivity

        charController.Move((MovementHorizontal * (movementSpeed * Time.deltaTime))); //Handles all the player movement. Adjusts if the player is sprinting or not. Left & Right Movement
        charController.Move((MovementVertical * (movementSpeed * Time.deltaTime))); //Handles all the player movement. Adjusts if the player is sprinting or not. Forward & Back Movement
        NoiseSphere.radius = noiseLevel;
        transform.localScale = new Vector3(0.4185318f, CrouchHeight, 0.363144f); //Changes the player height when the player crouches

        

    }

    void Crouching(bool Crouching) //Handles all the Crouching Code
    {
        if (Input.GetKeyDown("left ctrl")) //Checks if 'Left CTRL' has been pressed | Enables Crouching | Cancels Sprinting | Sets Player Movement to 'Slow' | Sets Player noise Level to 'Quiet'
        {
            Crouch = true;
            Sprint = false;
            movementSpeed = moveSpeedCrouching;
            noiseLevel = noiseLevelCrouching;
            CrouchHeight = CrouchHeightCrouched;
        }
        if (Input.GetKeyDown("left ctrl") && Crouching) //Checks if 'Left CTRL' and Crouching are true | Cancels Crouching | Sets player Movement Speed to 'Normal' | Set Noise Level to 'Normal'
        {
            Crouch = false;
            movementSpeed = moveSpeedNormal;
            noiseLevel = noiseLevelNormal;
            CrouchHeight = CrouchHeightNormal;
        }
        if (Input.GetKeyDown("left shift") && Crouching) //Checks if 'Left Shift' and Crouching is true | Enables Sprint | Cancels Crouching | Sets PLayer Movement Speed to 'Fast' | Sets Noise Level to 'Loud'
        {
            Crouch = false;
            Sprint = true;
            movementSpeed = moveSpeedSprint;
            noiseLevel = noiseLevelSprint;
            CrouchHeight = CrouchHeightNormal;
        }
    }
    void Sprinting(bool Sprinting) //Handles all the Sprinting Code
    {
        if (Input.GetKeyDown("left shift")) //Checks if 'Left Shift' is pressed | Enable Sprint | Cancel Crouch | Set Movement Speed to 'Fast' | Sets Noise Level to 'Loud'
        {
            Sprint = true;
            Crouch = false;
            movementSpeed = moveSpeedSprint;
            noiseLevel = noiseLevelSprint;
            CrouchHeight = CrouchHeightNormal;
        }
        if (Input.GetKeyDown("left shift") && Sprinting) //Checks if 'Left Shift' and Sprinting is true | Cancel Sprint | Set Movement Speed to 'Normal' | Set Noise level to 'Normal'
        {
            Sprint = false;
            movementSpeed = moveSpeedNormal;
            noiseLevel = noiseLevelNormal;
        }
        if (Input.GetKeyDown("left ctrl") && Sprinting) //Checks if 'Left CTRL' and Sprinting is true | Cancel Sprint | Enable Crouch | Set Movement Speed to 'Slow' | Set Noise Level to 'Quiet'
        {
            Sprint = false;
            Crouch = true;
            movementSpeed = moveSpeedCrouching;
            noiseLevel = noiseLevelCrouching;
            CrouchHeight = CrouchHeightCrouched;
        }
    }
}
