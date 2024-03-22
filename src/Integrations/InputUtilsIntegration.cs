using LessBright.Utils;
using LethalCompanyInputUtils.Api;
using UnityEngine.InputSystem;

namespace LessBright.Integrations;

internal class InputUtilsIntegration : LcInputActions
{
    public static readonly InputUtilsIntegration Instance = new();

    public InputAction NightVisionToggleKey => Asset["toggleNightVision"];

    public override void CreateInputActions(in InputActionMapBuilder builder)
    {
        Log.Info("Detected InputUtils, integrating...");
        builder.NewActionBinding()
            .WithActionId("toggleNightVision")
            .WithActionType(InputActionType.Button)
            .WithKbmPath("<Keyboard>/f")
            .WithBindingName("Toggle Night Vision")
            .Finish();
    }
}
