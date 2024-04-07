using LethalCompanyInputUtils.Api;
using UnityEngine.InputSystem;

namespace LessBright.Integrations.Input;

internal class InputUtilsInput : LcInputActions, IKeyInput
{
    private InputAction ToggleFlashlightInputAction => Asset["toggleFlashlight"];
    private InputAction ToggleSunInsideInputAction => Asset["toggleSunInside"];

    public bool ToggleFlashlight()
    {
        return ToggleFlashlightInputAction.triggered;
    }

    public bool ToggleSunInside()
    {
        return ToggleSunInsideInputAction.triggered;
    }

    public override void CreateInputActions(in InputActionMapBuilder builder)
    {
        builder.NewActionBinding()
            .WithActionId("toggleFlashlight")
            .WithActionType(InputActionType.Button)
            .WithKbmPath("<Keyboard>/f")
            .WithBindingName("Toggle \"hands-free\" Flashlight")
            .Finish();

        builder.NewActionBinding()
            .WithActionId("toggleSunInside")
            .WithActionType(InputActionType.Button)
            .WithKbmPath("<keyboard>/t")
            .WithBindingName("Toggle sun visibility within Facility.")
            .Finish();
    }
}
