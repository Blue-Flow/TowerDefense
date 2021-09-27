// GENERATED AUTOMATICALLY FROM 'Assets/Controls/DefenderSeat.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DefenderSeat : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DefenderSeat()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DefenderSeat"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""2f951e4b-de55-4f16-821f-ae81d2cc21ae"",
            ""actions"": [
                {
                    ""name"": ""SelectDefender1"",
                    ""type"": ""Button"",
                    ""id"": ""8e69fe2d-c7fc-4707-bb7d-8019ee3084ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectDefender2"",
                    ""type"": ""Button"",
                    ""id"": ""312e2180-06ae-41ff-b0c6-da38e9083c9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectDefender3"",
                    ""type"": ""Button"",
                    ""id"": ""cd5bcb37-2d45-4dc2-bd89-12a17029b194"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectDefender4"",
                    ""type"": ""Button"",
                    ""id"": ""72d367e9-dfb4-4d19-90ed-3e234e1bab96"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""484bb549-f068-4a52-af3a-755de8eaff91"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""SelectDefender1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e6079b0-c7b7-4749-8a82-b3a38915289c"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""SelectDefender1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""984620ba-ae67-49a9-a7df-23869b8b8a39"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""SelectDefender2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c378fe4c-b8f3-44f2-b4e3-288dcdb4f18f"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""SelectDefender2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7758217-583c-4afb-8c48-24e9dda66087"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""SelectDefender3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff7b7bd6-07cc-4192-9af4-f4468c13c997"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""SelectDefender3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9d9cd3c-252b-4de1-81e7-425565efbbcf"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""SelectDefender4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6efce0be-652d-4dfe-a272-80247020e9bb"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""SelectDefender4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_SelectDefender1 = m_Player1.FindAction("SelectDefender1", throwIfNotFound: true);
        m_Player1_SelectDefender2 = m_Player1.FindAction("SelectDefender2", throwIfNotFound: true);
        m_Player1_SelectDefender3 = m_Player1.FindAction("SelectDefender3", throwIfNotFound: true);
        m_Player1_SelectDefender4 = m_Player1.FindAction("SelectDefender4", throwIfNotFound: true);
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

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_SelectDefender1;
    private readonly InputAction m_Player1_SelectDefender2;
    private readonly InputAction m_Player1_SelectDefender3;
    private readonly InputAction m_Player1_SelectDefender4;
    public struct Player1Actions
    {
        private @DefenderSeat m_Wrapper;
        public Player1Actions(@DefenderSeat wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectDefender1 => m_Wrapper.m_Player1_SelectDefender1;
        public InputAction @SelectDefender2 => m_Wrapper.m_Player1_SelectDefender2;
        public InputAction @SelectDefender3 => m_Wrapper.m_Player1_SelectDefender3;
        public InputAction @SelectDefender4 => m_Wrapper.m_Player1_SelectDefender4;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @SelectDefender1.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectDefender1;
                @SelectDefender1.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectDefender1;
                @SelectDefender1.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectDefender1;
                @SelectDefender2.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectDefender2;
                @SelectDefender2.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectDefender2;
                @SelectDefender2.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectDefender2;
                @SelectDefender3.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectDefender3;
                @SelectDefender3.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectDefender3;
                @SelectDefender3.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectDefender3;
                @SelectDefender4.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectDefender4;
                @SelectDefender4.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectDefender4;
                @SelectDefender4.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSelectDefender4;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SelectDefender1.started += instance.OnSelectDefender1;
                @SelectDefender1.performed += instance.OnSelectDefender1;
                @SelectDefender1.canceled += instance.OnSelectDefender1;
                @SelectDefender2.started += instance.OnSelectDefender2;
                @SelectDefender2.performed += instance.OnSelectDefender2;
                @SelectDefender2.canceled += instance.OnSelectDefender2;
                @SelectDefender3.started += instance.OnSelectDefender3;
                @SelectDefender3.performed += instance.OnSelectDefender3;
                @SelectDefender3.canceled += instance.OnSelectDefender3;
                @SelectDefender4.started += instance.OnSelectDefender4;
                @SelectDefender4.performed += instance.OnSelectDefender4;
                @SelectDefender4.canceled += instance.OnSelectDefender4;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IPlayer1Actions
    {
        void OnSelectDefender1(InputAction.CallbackContext context);
        void OnSelectDefender2(InputAction.CallbackContext context);
        void OnSelectDefender3(InputAction.CallbackContext context);
        void OnSelectDefender4(InputAction.CallbackContext context);
    }
}
