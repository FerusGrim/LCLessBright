using System.Diagnostics.CodeAnalysis;
using GameNetcodeStuff;
using HarmonyLib;
using LessBright.Integrations;
using LessBright.Utils;
using UnityEngine;

namespace LessBright.Patches;

[HarmonyPatch(typeof(PlayerControllerB))]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class PlayerControllerBPatches
{
    private const string FlashlightKey = "LessBright_Flashlight";

    [HarmonyPatch("Start")]
    [HarmonyPostfix]
    private static void PostFixStart(PlayerControllerB __instance)
    {
        InitializeFlashLight(__instance.playerEye.gameObject);
    }

    [HarmonyPatch("Update")]
    [HarmonyPostfix]
    private static void PostFixUpdate(ref Transform ___playerEye)
    {
        var flashlight = ___playerEye.Find(FlashlightKey).GetComponent<Light>();
        if (Compat.IsToggleNightVisionTriggered())
        {
            var nextState = !flashlight.gameObject.activeSelf;
            Log.Info($"Flashlight toggled: {(nextState ? "ON" : "OFF")}");
            flashlight.gameObject.SetActive(nextState);
        }

        UpdateFlashLight(flashlight);
    }

    private static void InitializeFlashLight(GameObject gameObject)
    {
        var flashlightObject = new GameObject(FlashlightKey);
        flashlightObject.SetActive(true);

        var flashlight = flashlightObject.AddComponent<Light>();
        var flashlightTransform = flashlight.transform;
        flashlightTransform.SetParent(gameObject.transform);

        flashlightTransform.rotation = Quaternion.LookRotation(gameObject.transform.forward);

        flashlight.type = LightType.Spot;
        flashlight.range = 100_000F;
        flashlight.enabled = true;

        UpdateFlashLight(flashlight);
    }

    private static void UpdateFlashLight(Light flashlight)
    {
        flashlight.intensity = Configs.Intensity!.GetValue();
        flashlight.spotAngle = Configs.SpotAngle!.GetValue();
        flashlight.innerSpotAngle = Configs.InnerSpotAngle!.GetValue();
        flashlight.bounceIntensity = Configs.BounceIntensity!.GetValue();
        flashlight.shadows = Configs.ShadowType!.GetValue();
        flashlight.shadowStrength = Configs.ShadowStrength!.GetValue();
        flashlight.color = Configs.TranslateColor();

        flashlight.transform.localPosition = new Vector3(Configs.OffsetX!.GetValue(), Configs.OffsetY!.GetValue(),
            Configs.OffsetZ!.GetValue());
    }
}
