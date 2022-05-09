using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterCommands : MonoBehaviour
{

    private CharacterActionAsset characterActionAsset;
    
    [SerializeField] public bool isCommandWindowOpen;

    [SerializeField] public bool isfollowPlayer;
    [SerializeField] public bool isSpreadOut;
    [SerializeField] public bool isFallBack;
    [SerializeField] public bool isEngage;

    public GameObject commandWindow;


    void Awake()
    {
        characterActionAsset = new CharacterActionAsset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        
        characterActionAsset.Commands.CommandWindow.started += OpenCommandWindow;
        characterActionAsset.Commands.Follow.started += DoFollow;
        characterActionAsset.Commands.SpreadOut.started += DoSpreadOut;
        characterActionAsset.Commands.FallBack.started += DoFallBack;
        characterActionAsset.Commands.Engage.started += DoEngage;
        characterActionAsset.Commands.Enable();
    }

    private void OnDisable()
    {
       
        characterActionAsset.Commands.CommandWindow.started -= OpenCommandWindow;
        characterActionAsset.Commands.Follow.started -= DoFollow;
        characterActionAsset.Commands.SpreadOut.started -= DoSpreadOut;
        characterActionAsset.Commands.FallBack.started -= DoFallBack;
        characterActionAsset.Commands.Engage.started -= DoEngage;
        characterActionAsset.Commands.Disable();
    }

    private void OpenCommandWindow(InputAction.CallbackContext obj)
    {
        
        if(!isCommandWindowOpen)
        {
            isCommandWindowOpen = true;
            commandWindow.SetActive(true);
            print("Command Window Opened");
        }
        else
        {
            isCommandWindowOpen = false;
            commandWindow.SetActive(false);
            print("Closed");
        }
    }

    private void DoFollow(InputAction.CallbackContext obj)
    {

        if(isCommandWindowOpen)
        {
            if(!isfollowPlayer)
            {
                isfollowPlayer = true;
                print("Follow");
            }
            else
            {
                isfollowPlayer = false;
            }
        }
        else
        {
            
        }
    }

    private void DoSpreadOut(InputAction.CallbackContext obj)
    {
        if(isCommandWindowOpen)
        {
            if(!isSpreadOut)
            {
                isSpreadOut = true;
                print("Spread");
            }
            else
            {
                isSpreadOut = false;
            }
        }
        else
        {
            
        }
        
    }

    private void DoFallBack(InputAction.CallbackContext obj)
    {
        if(isCommandWindowOpen)
        {
            if(!isFallBack)
            {
                isFallBack = true;
                print("isFallBack");
            }
            else
            {
                isFallBack = false;
            }
        }
        else
        {
            
        }
        
    }

    private void DoEngage(InputAction.CallbackContext obj)
    {
        if(isCommandWindowOpen)
        {
            if(!isEngage)
            {
                isEngage = true;
                print("Engage");
            }
            else
            {
                isEngage = false;
            }
        }
        else
        {
            
        }
    }

}
