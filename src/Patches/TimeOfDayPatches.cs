using System.Diagnostics.CodeAnalysis;
using HarmonyLib;
using LessBright.Config;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace LessBright.Patches;

[HarmonyPatch(typeof(TimeOfDay))]
public class TimeOfDayPatches
{
    private static readonly int SunAnimatorTimeOfDayHash = Animator.StringToHash("timeOfDay");

    [HarmonyPatch("MoveTimeOfDay")]
    [HarmonyPostfix]
    private static void PostFixMoveTimeOfDay([SuppressMessage("ReSharper", "InconsistentNaming")] ref Animator ___sunAnimator)
    {
        if (Configs.Sun.EnablePositionOverride && ___sunAnimator)
            ___sunAnimator.SetFloat(SunAnimatorTimeOfDayHash, Configs.Sun.PositionOverride);
    }

    [HarmonyPatch("SetInsideLightingDimness")]
    [HarmonyPostfix]
    private static void PostFixSetInsideLightingDimness([SuppressMessage("ReSharper", "InconsistentNaming")] ref Light ___sunIndirect,
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        ref HDAdditionalLightData ___indirectLightData)
    {
        if (!LessBright.PlayerController.isInsideFactory || !LessBright.PlayerState.SunInsideEnabled) return;

        if (___sunIndirect)
        {
            ___sunIndirect.enabled = true;
            ___sunIndirect.intensity = Configs.Sun.InsideIntensity.Clamped(Ranges.Sun.InsideIntensity);
        }

        if (___indirectLightData) ___indirectLightData.lightDimmer = 16;
    }
}
