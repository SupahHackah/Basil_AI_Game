using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class Camera_Re_Centre : MonoBehaviour
{
    private CinemachineFreeLook _camera;

    bool _reset;


    Fox_Input input;

    void Awake()
    {
        
        input = new Fox_Input();
        input.CharacterControls.Re_Centre.performed += ctx => _reset = ctx.ReadValueAsButton();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_reset)
        {
            _camera.m_RecenterToTargetHeading.m_enabled = true;
        }
        else
        {
            _camera.m_RecenterToTargetHeading.m_enabled = false;
        }
        
    }

    void OnEnable()
    {
        //input.Movement.Enable();
        input.CharacterControls.Enable();
    }

    void OnDisable()
    {
        //input.Movement.Disable();
        input.CharacterControls.Disable();
    }
}
