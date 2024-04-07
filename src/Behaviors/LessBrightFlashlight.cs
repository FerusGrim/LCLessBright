using LessBright.Config;
using UnityEngine;

namespace LessBright.Behaviors;

public class LessBrightFlashlight : MonoBehaviour
{
    private Light _light = null!;

    public void Awake()
    {
        _light = gameObject.AddComponent<Light>();
        _light.type = LightType.Spot;
        _light.enabled = true;
    }

    public void Update()
    {
        _light.enabled = LessBright.PlayerState.FlashlightEnabled;
        _light.intensity = Configs.Flashlight.Intensity.Clamped(Ranges.Flashlight.Intensity);
        _light.range = Configs.Flashlight.Range.Clamped(Ranges.Flashlight.Range);
        _light.spotAngle = Configs.Flashlight.Spread.Clamped(Ranges.Flashlight.Spread);
        _light.color = Configs.Flashlight.Color;

        var relativePosition = new Vector3(
            Configs.Flashlight.OffsetX.Clamped(Ranges.Flashlight.OffsetX),
            Configs.Flashlight.OffsetY.Clamped(Ranges.Flashlight.OffsetY),
            Configs.Flashlight.OffsetZ.Clamped(Ranges.Flashlight.OffsetZ)
        );
        var relativeRotation = Quaternion.Euler(
            Configs.Flashlight.Yaw.Clamped(Ranges.Flashlight.Yaw) * -1,
            Configs.Flashlight.Pitch.Clamped(Ranges.Flashlight.Pitch),
            0
        );
        _light.transform.SetLocalPositionAndRotation(relativePosition, relativeRotation);
    }
}
