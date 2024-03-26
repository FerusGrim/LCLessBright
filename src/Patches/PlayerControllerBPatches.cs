using System.Diagnostics.CodeAnalysis;
using GameNetcodeStuff;
using HarmonyLib;
using LessBright.Config;
using LessBright.Integrations;
using LessBright.Utils;
using UnityEngine;

namespace LessBright.Patches;

[HarmonyPatch(typeof(PlayerControllerB))]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class PlayerControllerBPatches
{
    private const string FlashlightKey = "LessBright_Flashlight";

    private static Light? flashlight;

    [HarmonyPatch("Start")]
    [HarmonyPostfix]
    private static void PostFixStart(ref PlayerControllerB __instance)
    {
        if (Checks.IsNotLocalPlayer(__instance)) return;
        if (flashlight) throw new Exception("Flashlight already exists");
        if (!GetFlashlightComponent(__instance)) throw new Exception("Failed to create flashlight component");
    }

    [HarmonyPatch("Update")]
    [HarmonyPostfix]
    private static void PostFixUpdate(ref PlayerControllerB __instance)
    {
        if (Checks.IsNotLocalPlayer(__instance)) return;

        var localFlashlight = GetFlashlightComponent(__instance);
        if (!localFlashlight) throw new Exception("Failed to create flashlight component");

        if (Compat.IsToggleNightVisionTriggered())
        {
            var nextState = !localFlashlight.gameObject.activeSelf;
            localFlashlight.gameObject.SetActive(nextState);
            localFlashlight.enabled = nextState;
        }

        // Basic
        localFlashlight.intensity = Configs.Intensity;
        localFlashlight.range = Configs.Range;
        localFlashlight.spotAngle = Configs.SpotAngle;
        localFlashlight.color = Configs.Color;

        // Position
        var transform = localFlashlight.transform;
        var localPosition = new Vector3(Configs.OffsetX, Configs.OffsetY, Configs.OffsetZ);

        // I realize that traditionally, X is pitch and Y is yaw. However, in Unity X is yaw and Y is pitch.
        // Thus, the values here must be swapped.
        var localRotation = Quaternion.Euler(Configs.Yaw, Configs.Pitch, 0);
        transform.SetLocalPositionAndRotation(localPosition, localRotation);
    }

    private static Light GetFlashlightComponent(PlayerControllerB controller)
    {
        if (flashlight) return flashlight!;

        var gameObject = new GameObject(FlashlightKey);
        gameObject.SetActive(true);
        var localFlashlight = gameObject.AddComponent<Light>();
        localFlashlight.enabled = true;

        var transform = gameObject.transform;
        transform.SetParent(controller.playerEye.transform);
        transform.rotation = Quaternion.LookRotation(controller.playerEye.transform.forward);

        localFlashlight.type = LightType.Spot;
        localFlashlight.enabled = true;

        flashlight = localFlashlight;
        return flashlight;
    }
}
