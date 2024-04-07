using UnityEngine.InputSystem;

namespace LessBright.Integrations.Input;

internal class UnityInput : IKeyInput
{
    bool IKeyInput.ToggleFlashlight()
    {
        return Keyboard.current[Key.F].wasPressedThisFrame;
    }

    bool IKeyInput.ToggleSunInside()
    {
        return Keyboard.current[Key.T].wasPressedThisFrame;
    }
}
