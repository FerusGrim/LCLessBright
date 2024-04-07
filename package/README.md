# LessBright

Made as an alternative to, and inspired by, the [FullBright][1] plugin.

When configuring the color of the light, you can use any color picker you like. I personally use [this one][2].

Configuration is thoroughly explained in the configuration file itself.

## Brief Feature Overview

- Toggleable "hands-off" flashlight. Basically, a flashlight that is invisible and doesn't require you to hold it.
- Toggleable "inside sunlight". This feature allows you to toggle whether or not the sun's light penetrates the facility.
    - Typically, this creates a kind of "Flat" lighting effect. The "hands-off" flashlight is still useful in this mode, but it's not as necessary.
- Extremely configurable. You can change the color, intensity, and range of the light source, as well as its position relative to you. You can also
  change the pitch and yaw of the light source.
    - This can be used to create various effects such as "headlamp" or "flashlight"-style lighting.

## Integration

- [LethalConfig][3] is an **optional** integration that allows you to edit the configuration in-game. Without it, you will still be able to
  edit the configs via whichever method you usually use outside of game.
- [InputUtils][4] is an **optional** integration that allows you to rebind the key used to toggle the light source on and off. Without it,
  the default key is `F`.

[1]: https://thunderstore.io/c/lethal-company/p/OndysWorks/FullBright/ "FullBright Thunderstore Page"

[2]: https://www.google.com/search?q=color+picker "Google Search: Color Picker"

[3]: https://thunderstore.io/c/lethal-company/p/AinaVT/LethalConfig/ "LethalConfig Thunderstore Page"

[4]: https://thunderstore.io/c/lethal-company/p/Rune580/LethalCompany_InputUtils/ "InputUtils Thunderstore Page"
