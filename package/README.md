# LessBright

---

Made as an alternative to, and inspired by, the [FullBright][1] plugin.

## Configuration

See also, the Unity Manual entry for [Light][2].

| Name            | Description                                                               | Default | Type                     | Options            |
|-----------------|---------------------------------------------------------------------------|---------|--------------------------|--------------------|
| Intensity       | The Intensity of a light                                                  | 250     | float                    | Range(0, 1_000)    |
| SpotAngle       | The angle of the spot light's cone in degrees.                            | 75      | float                    | Range(0, 120)      |
| InnerSpotAngle  | The angle of the spot light's inner cone in degrees.                      | 30      | float                    | Range(0, 90)       |
| BounceIntensity | The multiplier that defines the strength of the bounce lighting.          | 0.5     | float                    | Range(0, 1)        |
| ShadowType      | Determine which type of shadows are cast.                                 | Soft    | [LightShadows][3]        | None, Hard, Soft   |
| ShadowStrength  | Set how dark the shadows cast by the light are.                           | 1       | float                    | 1                  |
| Color           | The color of the light.                                                   | White   | [Configs.PresetColor][4] | See [Reference][4] |
| OffsetX         | The offset, relative to your eyes, of the Light's position on the X-axis. | 0       | float                    | Range(-5, 5)       |
| OffsetY         | The offset, relative to your eyes, of the Light's position on the Y-axis. | 0.75    | float                    | Range(-5, 5)       |
| OffsetZ         | The offset, relative to your eyes, of the Light's position on the Z-axis. | 0       | float                    | Range(-5, 5)       |

## Integration

- [LethalConfig][5] is an **optional** integration that allows you to edit the configuration in-game. Without it, you will still be able to
  edit the configs via whichever method you usually use outside of game.
- [InputUtils][6] is an **optional** integration that allows you to rebind the key used to toggle the light source on and off. Without it,
  the default key is `F`.

[1]: https://thunderstore.io/c/lethal-company/p/OndysWorks/FullBright/ "FullBright Thunderstore Page"
[2]: https://docs.unity3d.com/Manual/class-Light.html "Unity Documentation: Light"
[3]: https://docs.unity3d.com/ScriptReference/LightShadows.html "Unity Documentation: LightShadows"
[4]: ../src/Utils/Configs.cs "Configs.PresetColor"
[5]: https://thunderstore.io/c/lethal-company/p/AinaVT/LethalConfig/ "LethalConfig Thunderstore Page"
[6]: https://thunderstore.io/c/lethal-company/p/Rune580/LethalCompany_InputUtils/ "InputUtils Thunderstore Page"
