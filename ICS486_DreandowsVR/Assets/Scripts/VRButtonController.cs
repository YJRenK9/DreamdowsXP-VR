using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class VRButtonController : MonoBehaviour
{
    public InputActionAsset actionAsset; // reference to the Input Action Asset
    private InputAction PrimaryButtonAction; // the specific action for the X button (used to do an action with the press of the X button) 

    RawImage ri;
    Color opacity;
    public Texture[] glitchBackgrounds;

    private bool toggleGlitchArt = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // get image reference
        ri = GetComponent<RawImage>();
        
        // make the image see through
        //opacity.a = 0.99f;
        //ri.color = opacity;

        // image is invisible b/c the user hasn't pressed the button yet
        ri.enabled = false;
    }

    private void OnEnable() 
    {
        //toggleGlitchArt = true;
        
        // Specify the named action map and the action (needs to use action map to reference VR action)
        PrimaryButtonAction = actionAsset.FindActionMap("VRActionMap").FindAction("VRActionPress");

        // adds an event listener for the A/X buttons
        PrimaryButtonAction.performed += PrimaryButtonPressed;

        // cancels an event listener for the A/X buttons
        PrimaryButtonAction.canceled += PrimaryButtonReleased;

        // enables the action for the primary button
        PrimaryButtonAction.Enable();
    }

    private void OnDisable() 
    {
        // removes an event listener for the x button
        PrimaryButtonAction.performed -= PrimaryButtonPressed;
        // uncancels an event listener for the A/X buttons?
        PrimaryButtonAction.canceled -= PrimaryButtonReleased;
        //disables the action for the primary button
        PrimaryButtonAction.Disable();
    }

    // A and X buttons pressed (function name must contain ButtonPressed, I think?)
    private void PrimaryButtonPressed(InputAction.CallbackContext context) 
    {
        toggleGlitchArt = true;
    }

    private void PrimaryButtonReleased(InputAction.CallbackContext context) 
    {
        toggleGlitchArt = false;
    }

    // Update is called once per frame
    void Update()
    {
        //OnEnable();
        if (toggleGlitchArt) 
        {
            // display the image on screen
            ri.enabled = true;

            // random glitch image being displayed
            int rand = Random.Range(0, glitchBackgrounds.Length);
            ri.texture = glitchBackgrounds[rand];
        }
        else 
        {
            // disable the image after button is no longer pressed
            ri.enabled = false;
        }
    }
}
