using BepInEx.Bootstrap;
using LessBright.Integrations.Input;
using LessBright.Utils;
using UnityEngine;

namespace LessBright.Behaviors;

public class PlayerState : MonoBehaviour
{
    private IKeyInput? _input;
    public bool FlashlightEnabled { get; private set; }
    public bool SunInsideEnabled { get; private set; }

    public void Update()
    {
        if (LessBright.PlayerController.inTerminalMenu) return;

        var input = ProvideInput();
        if (input.ToggleFlashlight()) FlashlightEnabled = !FlashlightEnabled;
        if (input.ToggleSunInside()) SunInsideEnabled = !SunInsideEnabled;
    }

    private IKeyInput ProvideInput()
    {
        if (_input != null) return _input;
        _input = Chainloader.PluginInfos.ContainsKey(Metadata.Dependencies.InputUtils)
            ? new InputUtilsInput()
            : new UnityInput();
        return _input;
    }
}
