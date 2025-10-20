# rokid-vps
The project requires the [Rokid SDK UXR 3.0](https://custom.rokid.com/prod/rokid_web/c88be4bcde4c42c0b8b53409e1fa1701/pc/us/846a79e0bae540a393abd850f3b14716.html?documentId=e7936c425bcf4e39b0e9fd0c9f389f4c) package to run.

The Rokid package targets Rokid Max / Rokid Max Pro headsets paired with Rokid Station or compatible Android hosts. Enterprise licensing is required to download the build.

## Enterprise Access

- Contact `support@web-ar.studio` with your Rokid model, host device lineup, and distribution plan.
- Enterprise customers receive:
  - `com.webarvps.vps.rokid` Unity package with pose smoothing and station detection.
  - Sample projects for optical see-through UX and voice command toggles.
  - Documentation for sideloading via Rokid Developer tools.

> **Enterprise only:** Rokid transport adapters, driver checks, and diagnostic overlays are not shipped in the public SDK.

## Prerequisites

- Rokid Max / Max Pro with the latest firmware.
- Rokid Station or Android 12+ device with USB-C DP output.
- Unity 2022.3 LTS with Android build support.

## Setup Steps

1. Install the Enterprise package and import `Rokid_Localization.unity`.
2. Switch to the Android build target (IL2CPP + ARM64) and enable **Split APKs by target architecture**.
3. In `Project Settings → Player → XR Plug-in Management`, enable `OpenXR` and activate the **WebAR³ Rokid Feature Group**.
4. Build and install with `adb install-multiple` or the Rokid Developer assistant.

## Testing Checklist

- Calibrate interpupillary distance (IPD) using Rokid settings before localization tests.
- Validate voice-triggered localization reset (say “Reset positioning”) and confirm the headset haptic feedback fires.
- Test map switching when the glasses reconnect after a cable unplug event.
- Use the included `RokidDiagnostics` prefab to export logs for enterprise support.

## Support

Enterprise customers can schedule firmware validation and request custom UI audits for kiosk or guided-tour scenarios.
