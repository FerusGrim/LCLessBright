using System.Diagnostics.CodeAnalysis;
using GameNetcodeStuff;
using HarmonyLib;
using LessBright.Behaviors;
using UnityEngine;

namespace LessBright.Patches;

[HarmonyPatch(typeof(PlayerControllerB))]
public class PlayerControllerBPatches
{
    [HarmonyPatch("Awake")]
    [HarmonyPostfix]
    private static void PostFixAwake([SuppressMessage("ReSharper", "InconsistentNaming")] ref PlayerControllerB __instance,
        ref Transform ___playerEye)
    {
        if (LessBright.PlayerController == __instance) return;
        var newObject = new GameObject();

        var transform = newObject.transform;
        transform.SetParent(___playerEye.transform);
        transform.rotation = Quaternion.LookRotation(___playerEye.transform.forward);

        newObject.AddComponent<LessBrightFlashlight>();
    }
}
