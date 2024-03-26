# LessBright

---

Made as an alternative to, and inspired by, the [FullBright][1] plugin.

## Configuration

See also, the Unity Manual entry for [Light][2].

| Name       | Description                                                               | Default   | Type   | Options           |
|------------|---------------------------------------------------------------------------|-----------|--------|-------------------|
| Intensity  | The Intensity of a light                                                  | 3,000     | int    | Range(0, 25,000)  |
| Range      | The range of the light.                                                   | 99,999    | int    | Range(0, 99,999)  |
| Spot Angle | The angle of the spot light's cone in degrees.                            | 130       | int    | Range(0, 179)     |
| Color      | The color of the light.                                                   | `#FFFFFF` | string | [Color Picker][3] |
| OffsetX    | The offset, relative to your eyes, of the Light's position on the X-axis. | 0         | float  | Range(-10, 10)    |
| OffsetY    | The offset, relative to your eyes, of the Light's position on the Y-axis. | 1.75      | float  | Range(-10, 10)    |
| OffsetZ    | The offset, relative to your eyes, of the Light's position on the Z-axis. | 0         | float  | Range(-10, 10)    |
| Pitch      | The rotation of the light, relative to your eyes, on the X-axis.          | 0         | int    | Range(0, 359)     |
| Yaw        | The rotation of the light, relative to your eyes, on the Y-axis.          | 0         | int    | Range(0, 359)     |

## Integration

- [LethalConfig][5] is an **optional** integration that allows you to edit the configuration in-game. Without it, you will still be able to
  edit the configs via whichever method you usually use outside of game.
- [InputUtils][6] is an **optional** integration that allows you to rebind the key used to toggle the light source on and off. Without it,
  the default key is `F`.

[1]: https://thunderstore.io/c/lethal-company/p/OndysWorks/FullBright/ "FullBright Thunderstore Page"

[2]: https://docs.unity3d.com/Manual/class-Light.html "Unity Documentation: Light"

[3]: https://www.google.com/search?q=color+picker "Google Search: Color Picker"

[5]: https://thunderstore.io/c/lethal-company/p/AinaVT/LethalConfig/ "LethalConfig Thunderstore Page"

[6]: https://thunderstore.io/c/lethal-company/p/Rune580/LethalCompany_InputUtils/ "InputUtils Thunderstore Page"
