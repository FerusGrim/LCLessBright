# v2.0.0

---

- New Feature: Inside Sunlight
    - Separate from the flashlight, this feature allows you to toggle whether or not the sun's light penetrates the facility.
- New Feature: Override Sun Position
    - This feature allows you to manually set the position of the sun.
    - By default, the sun's position is set to around noon, meaning that it's as bright as it can be.
    - This is purely a visual change, and does not affect the actual time of day nor how the sun appears for other players.
- Expanded configuration descriptions. Hopefully this makes it easier to understand what each option does.
- Made everything as efficient as I'm personally capable of doing. As little code is patched as possible.
- Fixed a bug where the flashlight would not follow the player's yaw rotation (pitch was working as intended).

Note: If you do not use LethalConfig (and are updating from a previous version of this mod), I recommend deleting the config for this mod and
allowing it to regenerate. A lot of the options were moved around, renamed, or removed entirely. It'll be very confusing to manually configure
with a pre-existing config.

# v1.2.0

---

- Added more options for the light source
    - The ability to use HEX color codes for the light source
    - The ability to change the Pitch and Yaw of the light source
- Additionally, removed a number of options that did not seem to actually do anything
- In the backend, the configuration is much more sensible.

# v1.1.0

---

- Added ability to toggle light manually from LethalConfig's menu
- Flashlight now only applies to the local player
    - This is just a visual change, the flashlight was already only visible to the local player
- More efficient flashlight retrieval, now that we only need to get the flashlight for the local player

# v1.0.0

---

- Initial release
- Configurable light source
- Toggleable light source
