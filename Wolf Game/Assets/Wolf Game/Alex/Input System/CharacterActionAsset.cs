// GENERATED AUTOMATICALLY FROM 'Assets/Wolf Game/Alex/Input System/CharacterActionAsset.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CharacterActionAsset : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterActionAsset()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterActionAsset"",
    ""maps"": [
        {
            ""name"": ""Basic Movement"",
            ""id"": ""66ce3539-34a4-4487-b4f7-7145efcfa6c4"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""ca482987-b039-4d6e-a56e-d91e85b465dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""230f4d9a-9279-4cea-b315-bce7d26fad0f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""b1c898d1-557b-4926-8610-c967ace7b432"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""46e25f91-3822-45b8-97a7-6da276fe8ee9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""6fe3f815-8aa6-4c76-b731-e7909cb00f1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""f9fc387f-8f84-4627-a35a-18e0210a9d74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f1e818cc-eac8-41c9-a424-559c9de476f4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""ab8baf7f-eb22-44a0-a40e-c23c2adb3a6a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""71ab56e6-c157-419a-9899-c7573269b518"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3d91c924-2015-44bb-9715-0100bff45f5c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d1e42fef-4fb9-46c7-a7f4-baaa55734286"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""840401c9-7d2c-43c9-8608-481866a17c5e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""2cfd5d1c-685a-4f5d-af32-7f4f8348f6d2"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8bb2ce2a-d92d-460c-9f5c-ac399095b3d1"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4a5fe31a-7852-4388-ad5a-d7483f7f557f"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d6059cb4-7f37-4077-ab09-ab5aabb42f70"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4ce4b719-e7ba-4fe3-9e9e-11a6c7d5bac0"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""917a7363-9831-4f3f-af4d-5cd2d2a7fe02"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b7933a9-7c10-4009-8351-bd75c0c0a67a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""753f2043-434e-4452-bb1a-d6e7a4ed624e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61d7f0f8-b326-41c5-b566-920f1a4d3654"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6cdd50a-53e4-4b61-9945-5f9742e91afc"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eee5501f-6790-4f09-a746-8b87e62557ca"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ef35494-5efe-4703-a284-4aaeb12ecb2c"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce480887-15d1-4c3f-99fe-ab89b143e4da"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1b6b112-669b-47be-9142-9f54f3e17fb9"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d09eef7c-f469-4478-a5ed-1fc2f7dd660d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62c122b2-f2b8-47e1-a698-ebc7061b4ddf"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fbe9433-0df9-4ab8-be6a-e98598a0e37b"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Commands"",
            ""id"": ""91fe3e46-a933-4064-a969-7c18d1d1175f"",
            ""actions"": [
                {
                    ""name"": ""CommandWindow"",
                    ""type"": ""Button"",
                    ""id"": ""95d3efc8-36b1-490a-8d27-8fb4e6a35107"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Follow"",
                    ""type"": ""Button"",
                    ""id"": ""c3566413-f5e0-47a3-bbfc-be8fffcbbc15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpreadOut"",
                    ""type"": ""Button"",
                    ""id"": ""ffe55716-ab04-4c3d-b2b0-724f0a28371c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FallBack"",
                    ""type"": ""Button"",
                    ""id"": ""e62f01a3-62eb-4248-9ec2-41f61429ec0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Engage"",
                    ""type"": ""Button"",
                    ""id"": ""162cd03e-eb97-4a97-bdb6-cef28f8a2515"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AddAlly"",
                    ""type"": ""Button"",
                    ""id"": ""0c247c4c-722b-420d-9e92-f1b53b5c8ea7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""RemoveAlly"",
                    ""type"": ""Button"",
                    ""id"": ""703a8725-1f70-495e-a887-2dbaf14a4a4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5655990d-d56e-4569-825d-37b01e16bc72"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CommandWindow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d4cf40c-c35b-4e1f-a181-b60f23b008c9"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CommandWindow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""594c1440-d5c6-4098-91d0-400139a812df"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Follow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdf85662-be7e-41d8-8990-f6f1cf10344b"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Follow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52149041-98e6-44cf-8069-31ad60edf869"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpreadOut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e126e4b-2c89-4465-8468-819f8e8e423d"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpreadOut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49737f0c-575a-4c6d-95e8-a84d9fb21a05"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FallBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8710231-dc63-4b6d-86c8-b47bc7384f59"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FallBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f11d122e-5c96-4a1f-ab3c-7a136a732e98"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Engage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7509cc9a-bbfc-47d6-878c-f78ac3bb2436"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Engage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e545a6a-30a2-4cb2-87d2-27a8bb3062b6"",
                    ""path"": ""<Keyboard>/numpadPlus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AddAlly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2a85b05-6751-4c35-a5da-36484067bc69"",
                    ""path"": ""<Keyboard>/minus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RemoveAlly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Basic Movement
        m_BasicMovement = asset.FindActionMap("Basic Movement", throwIfNotFound: true);
        m_BasicMovement_Movement = m_BasicMovement.FindAction("Movement", throwIfNotFound: true);
        m_BasicMovement_Jump = m_BasicMovement.FindAction("Jump", throwIfNotFound: true);
        m_BasicMovement_Sprint = m_BasicMovement.FindAction("Sprint", throwIfNotFound: true);
        m_BasicMovement_Attack = m_BasicMovement.FindAction("Attack", throwIfNotFound: true);
        m_BasicMovement_Dodge = m_BasicMovement.FindAction("Dodge", throwIfNotFound: true);
        m_BasicMovement_Interact = m_BasicMovement.FindAction("Interact", throwIfNotFound: true);
        m_BasicMovement_Look = m_BasicMovement.FindAction("Look", throwIfNotFound: true);
        // Commands
        m_Commands = asset.FindActionMap("Commands", throwIfNotFound: true);
        m_Commands_CommandWindow = m_Commands.FindAction("CommandWindow", throwIfNotFound: true);
        m_Commands_Follow = m_Commands.FindAction("Follow", throwIfNotFound: true);
        m_Commands_SpreadOut = m_Commands.FindAction("SpreadOut", throwIfNotFound: true);
        m_Commands_FallBack = m_Commands.FindAction("FallBack", throwIfNotFound: true);
        m_Commands_Engage = m_Commands.FindAction("Engage", throwIfNotFound: true);
        m_Commands_AddAlly = m_Commands.FindAction("AddAlly", throwIfNotFound: true);
        m_Commands_RemoveAlly = m_Commands.FindAction("RemoveAlly", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Basic Movement
    private readonly InputActionMap m_BasicMovement;
    private IBasicMovementActions m_BasicMovementActionsCallbackInterface;
    private readonly InputAction m_BasicMovement_Movement;
    private readonly InputAction m_BasicMovement_Jump;
    private readonly InputAction m_BasicMovement_Sprint;
    private readonly InputAction m_BasicMovement_Attack;
    private readonly InputAction m_BasicMovement_Dodge;
    private readonly InputAction m_BasicMovement_Interact;
    private readonly InputAction m_BasicMovement_Look;
    public struct BasicMovementActions
    {
        private @CharacterActionAsset m_Wrapper;
        public BasicMovementActions(@CharacterActionAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_BasicMovement_Movement;
        public InputAction @Jump => m_Wrapper.m_BasicMovement_Jump;
        public InputAction @Sprint => m_Wrapper.m_BasicMovement_Sprint;
        public InputAction @Attack => m_Wrapper.m_BasicMovement_Attack;
        public InputAction @Dodge => m_Wrapper.m_BasicMovement_Dodge;
        public InputAction @Interact => m_Wrapper.m_BasicMovement_Interact;
        public InputAction @Look => m_Wrapper.m_BasicMovement_Look;
        public InputActionMap Get() { return m_Wrapper.m_BasicMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BasicMovementActions set) { return set.Get(); }
        public void SetCallbacks(IBasicMovementActions instance)
        {
            if (m_Wrapper.m_BasicMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnJump;
                @Sprint.started -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnSprint;
                @Attack.started -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnAttack;
                @Dodge.started -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnDodge;
                @Interact.started -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnInteract;
                @Look.started -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_BasicMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public BasicMovementActions @BasicMovement => new BasicMovementActions(this);

    // Commands
    private readonly InputActionMap m_Commands;
    private ICommandsActions m_CommandsActionsCallbackInterface;
    private readonly InputAction m_Commands_CommandWindow;
    private readonly InputAction m_Commands_Follow;
    private readonly InputAction m_Commands_SpreadOut;
    private readonly InputAction m_Commands_FallBack;
    private readonly InputAction m_Commands_Engage;
    private readonly InputAction m_Commands_AddAlly;
    private readonly InputAction m_Commands_RemoveAlly;
    public struct CommandsActions
    {
        private @CharacterActionAsset m_Wrapper;
        public CommandsActions(@CharacterActionAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @CommandWindow => m_Wrapper.m_Commands_CommandWindow;
        public InputAction @Follow => m_Wrapper.m_Commands_Follow;
        public InputAction @SpreadOut => m_Wrapper.m_Commands_SpreadOut;
        public InputAction @FallBack => m_Wrapper.m_Commands_FallBack;
        public InputAction @Engage => m_Wrapper.m_Commands_Engage;
        public InputAction @AddAlly => m_Wrapper.m_Commands_AddAlly;
        public InputAction @RemoveAlly => m_Wrapper.m_Commands_RemoveAlly;
        public InputActionMap Get() { return m_Wrapper.m_Commands; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CommandsActions set) { return set.Get(); }
        public void SetCallbacks(ICommandsActions instance)
        {
            if (m_Wrapper.m_CommandsActionsCallbackInterface != null)
            {
                @CommandWindow.started -= m_Wrapper.m_CommandsActionsCallbackInterface.OnCommandWindow;
                @CommandWindow.performed -= m_Wrapper.m_CommandsActionsCallbackInterface.OnCommandWindow;
                @CommandWindow.canceled -= m_Wrapper.m_CommandsActionsCallbackInterface.OnCommandWindow;
                @Follow.started -= m_Wrapper.m_CommandsActionsCallbackInterface.OnFollow;
                @Follow.performed -= m_Wrapper.m_CommandsActionsCallbackInterface.OnFollow;
                @Follow.canceled -= m_Wrapper.m_CommandsActionsCallbackInterface.OnFollow;
                @SpreadOut.started -= m_Wrapper.m_CommandsActionsCallbackInterface.OnSpreadOut;
                @SpreadOut.performed -= m_Wrapper.m_CommandsActionsCallbackInterface.OnSpreadOut;
                @SpreadOut.canceled -= m_Wrapper.m_CommandsActionsCallbackInterface.OnSpreadOut;
                @FallBack.started -= m_Wrapper.m_CommandsActionsCallbackInterface.OnFallBack;
                @FallBack.performed -= m_Wrapper.m_CommandsActionsCallbackInterface.OnFallBack;
                @FallBack.canceled -= m_Wrapper.m_CommandsActionsCallbackInterface.OnFallBack;
                @Engage.started -= m_Wrapper.m_CommandsActionsCallbackInterface.OnEngage;
                @Engage.performed -= m_Wrapper.m_CommandsActionsCallbackInterface.OnEngage;
                @Engage.canceled -= m_Wrapper.m_CommandsActionsCallbackInterface.OnEngage;
                @AddAlly.started -= m_Wrapper.m_CommandsActionsCallbackInterface.OnAddAlly;
                @AddAlly.performed -= m_Wrapper.m_CommandsActionsCallbackInterface.OnAddAlly;
                @AddAlly.canceled -= m_Wrapper.m_CommandsActionsCallbackInterface.OnAddAlly;
                @RemoveAlly.started -= m_Wrapper.m_CommandsActionsCallbackInterface.OnRemoveAlly;
                @RemoveAlly.performed -= m_Wrapper.m_CommandsActionsCallbackInterface.OnRemoveAlly;
                @RemoveAlly.canceled -= m_Wrapper.m_CommandsActionsCallbackInterface.OnRemoveAlly;
            }
            m_Wrapper.m_CommandsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CommandWindow.started += instance.OnCommandWindow;
                @CommandWindow.performed += instance.OnCommandWindow;
                @CommandWindow.canceled += instance.OnCommandWindow;
                @Follow.started += instance.OnFollow;
                @Follow.performed += instance.OnFollow;
                @Follow.canceled += instance.OnFollow;
                @SpreadOut.started += instance.OnSpreadOut;
                @SpreadOut.performed += instance.OnSpreadOut;
                @SpreadOut.canceled += instance.OnSpreadOut;
                @FallBack.started += instance.OnFallBack;
                @FallBack.performed += instance.OnFallBack;
                @FallBack.canceled += instance.OnFallBack;
                @Engage.started += instance.OnEngage;
                @Engage.performed += instance.OnEngage;
                @Engage.canceled += instance.OnEngage;
                @AddAlly.started += instance.OnAddAlly;
                @AddAlly.performed += instance.OnAddAlly;
                @AddAlly.canceled += instance.OnAddAlly;
                @RemoveAlly.started += instance.OnRemoveAlly;
                @RemoveAlly.performed += instance.OnRemoveAlly;
                @RemoveAlly.canceled += instance.OnRemoveAlly;
            }
        }
    }
    public CommandsActions @Commands => new CommandsActions(this);
    public interface IBasicMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
    public interface ICommandsActions
    {
        void OnCommandWindow(InputAction.CallbackContext context);
        void OnFollow(InputAction.CallbackContext context);
        void OnSpreadOut(InputAction.CallbackContext context);
        void OnFallBack(InputAction.CallbackContext context);
        void OnEngage(InputAction.CallbackContext context);
        void OnAddAlly(InputAction.CallbackContext context);
        void OnRemoveAlly(InputAction.CallbackContext context);
    }
}
