// GENERATED AUTOMATICALLY FROM 'Assets/InputSytem/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Player_Map"",
            ""id"": ""e40b20db-aa22-4ce1-9cd7-dbc4d7c72223"",
            ""actions"": [
                {
                    ""name"": ""Verticle"",
                    ""type"": ""Button"",
                    ""id"": ""d55cbd72-4b18-46f4-8df7-06e2d37aebd1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Button"",
                    ""id"": ""9a9b75e3-9b84-40f7-ba0c-8f5a498c65a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Verticle"",
                    ""id"": ""f52119e3-b982-4c18-8372-b734e71ff406"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Verticle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b5fca79e-5ff4-4d40-b1a9-73b6f24b19a0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Verticle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c4ef36a1-1cfd-4759-bb33-d8bc0a13acb1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Verticle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Horizontal"",
                    ""id"": ""81322e02-e299-426a-83d3-116988a42ce7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""977faca5-fe49-4c27-9746-20154ad49746"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""63e24a6e-f8cc-4626-bd7f-de4e1c468f36"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player_Map
        m_Player_Map = asset.FindActionMap("Player_Map", throwIfNotFound: true);
        m_Player_Map_Verticle = m_Player_Map.FindAction("Verticle", throwIfNotFound: true);
        m_Player_Map_Horizontal = m_Player_Map.FindAction("Horizontal", throwIfNotFound: true);
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

    // Player_Map
    private readonly InputActionMap m_Player_Map;
    private IPlayer_MapActions m_Player_MapActionsCallbackInterface;
    private readonly InputAction m_Player_Map_Verticle;
    private readonly InputAction m_Player_Map_Horizontal;
    public struct Player_MapActions
    {
        private @PlayerInputs m_Wrapper;
        public Player_MapActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Verticle => m_Wrapper.m_Player_Map_Verticle;
        public InputAction @Horizontal => m_Wrapper.m_Player_Map_Horizontal;
        public InputActionMap Get() { return m_Wrapper.m_Player_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_MapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_MapActions instance)
        {
            if (m_Wrapper.m_Player_MapActionsCallbackInterface != null)
            {
                @Verticle.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnVerticle;
                @Verticle.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnVerticle;
                @Verticle.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnVerticle;
                @Horizontal.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnHorizontal;
            }
            m_Wrapper.m_Player_MapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Verticle.started += instance.OnVerticle;
                @Verticle.performed += instance.OnVerticle;
                @Verticle.canceled += instance.OnVerticle;
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
            }
        }
    }
    public Player_MapActions @Player_Map => new Player_MapActions(this);
    public interface IPlayer_MapActions
    {
        void OnVerticle(InputAction.CallbackContext context);
        void OnHorizontal(InputAction.CallbackContext context);
    }
}
