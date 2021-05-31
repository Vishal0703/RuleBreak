// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""d7cd0879-925b-44ec-af73-de63b399c4de"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9ebdbdea-a864-470e-976e-2ec60e5e2083"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6181b082-cdf8-416a-b69f-61c7b96878a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""0716c6fd-e171-4fe7-b48b-e749ed79506b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grapple"",
                    ""type"": ""Button"",
                    ""id"": ""eb15e4e5-3f3f-4323-9fdc-3b7a17376f6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MeleeAttack"",
                    ""type"": ""Button"",
                    ""id"": ""644aa817-af81-4ec6-99f3-b203f73e23ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RangeAttackStart"",
                    ""type"": ""Button"",
                    ""id"": ""3689ffe0-59f9-4e40-a67d-7261d9e841ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RangeAttackPowerup"",
                    ""type"": ""PassThrough"",
                    ""id"": ""49c46cb7-277f-415e-8604-f6e5292995e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RangeAttackAim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0e9aa180-cb89-4983-8e49-5439767ca1f3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RangeAttackShoot"",
                    ""type"": ""Button"",
                    ""id"": ""dbf87ac0-fa12-446f-8877-0efd57971da4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WA"",
                    ""id"": ""e1320bda-76dd-42da-b433-5b2844598fd0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6501ccab-2d87-479e-a8f4-e523eb63cc78"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1c127dd7-2127-4891-9cf1-d153c7ebd356"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""a4aa22ff-e350-4cf7-b31d-2fbfcd4cbfe8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6e0823f4-ca4a-4ad0-900b-9c56fc258244"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1050b70b-70b6-4c1a-b560-343aff507fa9"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""702824c4-4ac8-4844-887a-6340386e0c7a"",
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
                    ""id"": ""5363a4a8-1634-4721-b180-54e205e3cbb2"",
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
                    ""id"": ""f2f4f5a9-3796-4a74-823c-33ad0bdfb82a"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d6b22ad-6466-4d73-9deb-d7cdae8c242c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""786c4fdd-0c86-4261-98e1-36797e8a8bc3"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grapple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4df8cb1-9e2a-491a-a3c7-c4c0d512a61a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grapple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67c0d25c-49fe-4f92-a19a-7cca0d537b15"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MeleeAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2afc25f5-75ff-4f99-b43b-88d9bed42f9e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MeleeAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7ac324e-10a8-417f-b495-58af8602bbc3"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MeleeAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2fbfa24-ea22-415a-9c71-63e2fdd360dc"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f72c1d02-faa4-44c1-ac52-a74c643b8c8e"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""16fe71b3-7269-4703-a1ad-1c033f93c78b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackAim"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""325ca929-a127-4be4-8524-a3a461b2abc8"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5d349108-da3c-4662-8224-fa074ad32027"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1163bec4-4724-4075-b9ec-b69e4ff6911e"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6aa5c10-0bb0-485e-9b69-4b570943b385"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackPowerup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd1819a6-b8ec-483e-b3e9-1999cea3612b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackPowerup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""749132a1-cdea-4c2a-9d72-913d73566467"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f297e80-2675-402a-85a5-4bfd7388f94f"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RangeAttackShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
        m_Player_Grapple = m_Player.FindAction("Grapple", throwIfNotFound: true);
        m_Player_MeleeAttack = m_Player.FindAction("MeleeAttack", throwIfNotFound: true);
        m_Player_RangeAttackStart = m_Player.FindAction("RangeAttackStart", throwIfNotFound: true);
        m_Player_RangeAttackPowerup = m_Player.FindAction("RangeAttackPowerup", throwIfNotFound: true);
        m_Player_RangeAttackAim = m_Player.FindAction("RangeAttackAim", throwIfNotFound: true);
        m_Player_RangeAttackShoot = m_Player.FindAction("RangeAttackShoot", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Crouch;
    private readonly InputAction m_Player_Grapple;
    private readonly InputAction m_Player_MeleeAttack;
    private readonly InputAction m_Player_RangeAttackStart;
    private readonly InputAction m_Player_RangeAttackPowerup;
    private readonly InputAction m_Player_RangeAttackAim;
    private readonly InputAction m_Player_RangeAttackShoot;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
        public InputAction @Grapple => m_Wrapper.m_Player_Grapple;
        public InputAction @MeleeAttack => m_Wrapper.m_Player_MeleeAttack;
        public InputAction @RangeAttackStart => m_Wrapper.m_Player_RangeAttackStart;
        public InputAction @RangeAttackPowerup => m_Wrapper.m_Player_RangeAttackPowerup;
        public InputAction @RangeAttackAim => m_Wrapper.m_Player_RangeAttackAim;
        public InputAction @RangeAttackShoot => m_Wrapper.m_Player_RangeAttackShoot;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Grapple.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrapple;
                @Grapple.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrapple;
                @Grapple.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrapple;
                @MeleeAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMeleeAttack;
                @MeleeAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMeleeAttack;
                @MeleeAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMeleeAttack;
                @RangeAttackStart.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRangeAttackStart;
                @RangeAttackStart.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRangeAttackStart;
                @RangeAttackStart.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRangeAttackStart;
                @RangeAttackPowerup.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRangeAttackPowerup;
                @RangeAttackPowerup.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRangeAttackPowerup;
                @RangeAttackPowerup.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRangeAttackPowerup;
                @RangeAttackAim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRangeAttackAim;
                @RangeAttackAim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRangeAttackAim;
                @RangeAttackAim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRangeAttackAim;
                @RangeAttackShoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRangeAttackShoot;
                @RangeAttackShoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRangeAttackShoot;
                @RangeAttackShoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRangeAttackShoot;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Grapple.started += instance.OnGrapple;
                @Grapple.performed += instance.OnGrapple;
                @Grapple.canceled += instance.OnGrapple;
                @MeleeAttack.started += instance.OnMeleeAttack;
                @MeleeAttack.performed += instance.OnMeleeAttack;
                @MeleeAttack.canceled += instance.OnMeleeAttack;
                @RangeAttackStart.started += instance.OnRangeAttackStart;
                @RangeAttackStart.performed += instance.OnRangeAttackStart;
                @RangeAttackStart.canceled += instance.OnRangeAttackStart;
                @RangeAttackPowerup.started += instance.OnRangeAttackPowerup;
                @RangeAttackPowerup.performed += instance.OnRangeAttackPowerup;
                @RangeAttackPowerup.canceled += instance.OnRangeAttackPowerup;
                @RangeAttackAim.started += instance.OnRangeAttackAim;
                @RangeAttackAim.performed += instance.OnRangeAttackAim;
                @RangeAttackAim.canceled += instance.OnRangeAttackAim;
                @RangeAttackShoot.started += instance.OnRangeAttackShoot;
                @RangeAttackShoot.performed += instance.OnRangeAttackShoot;
                @RangeAttackShoot.canceled += instance.OnRangeAttackShoot;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnGrapple(InputAction.CallbackContext context);
        void OnMeleeAttack(InputAction.CallbackContext context);
        void OnRangeAttackStart(InputAction.CallbackContext context);
        void OnRangeAttackPowerup(InputAction.CallbackContext context);
        void OnRangeAttackAim(InputAction.CallbackContext context);
        void OnRangeAttackShoot(InputAction.CallbackContext context);
    }
}
