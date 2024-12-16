using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private bool submitPressed = false;

    private static InputManager instance;

    private void Awake(){
        if(instance != null){
            Debug.LogError("Found more than one Input Manager");
        }
        instance = this;
    }

    public static InputManager GetInstance(){
        return instance;
    }

     public void SubmitPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitPressed = true;
        }
        else if (context.canceled)
        {
            submitPressed = false;
        } 
    }

    public bool GetSubmitPressed() 
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }
}
