// Decompiled with JetBrains decompiler
// Type: PhasmophobiaGUI.PlayerStats
// Assembly: PhasmophobiaGUI, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0967AAEE-F31B-4649-99E8-D66F4327D3A0
// Assembly location: C:\Users\Ry\Desktop\New folder\PhasmophobiaGUI.dll

using System;

namespace PhasmophobiaGUI
{
  public class PlayerStats
  {
    public static void SetMax()
    {
      FileBasedPrefs.SetInt("myTotalExp", int.MaxValue);
      FileBasedPrefs.SetInt("totalExp", int.MaxValue);
      FileBasedPrefs.SetInt("PlayersMoney", int.MaxValue);
      FileBasedPrefs.SetInt("completedTraining", 1);
      FileBasedPrefs.SetInt("PlayerDied", 0);
      FileBasedPrefs.SetInt("EMFReaderInventory", int.MaxValue);
      FileBasedPrefs.SetInt("FlashlightInventory", int.MaxValue);
      FileBasedPrefs.SetInt("CameraInventory", int.MaxValue);
      FileBasedPrefs.SetInt("LighterInventory", int.MaxValue);
      FileBasedPrefs.SetInt("CandleInventory", int.MaxValue);
      FileBasedPrefs.SetInt("UVFlashlightInventory", int.MaxValue);
      FileBasedPrefs.SetInt("CrucifixInventory", int.MaxValue);
      FileBasedPrefs.SetInt("DSLRCameraInventory", int.MaxValue);
      FileBasedPrefs.SetInt("EVPRecorderInventory", int.MaxValue);
      FileBasedPrefs.SetInt("SaltInventory", int.MaxValue);
      FileBasedPrefs.SetInt("TripodInventory", int.MaxValue);
      FileBasedPrefs.SetInt("StrongFlashlightInventory", int.MaxValue);
      FileBasedPrefs.SetInt("MotionSensorInventory", int.MaxValue);
      FileBasedPrefs.SetInt("SoundSensorInventory", int.MaxValue);
      FileBasedPrefs.SetInt("SanityPillsInventory", int.MaxValue);
      FileBasedPrefs.SetInt("ThermometerInventory", int.MaxValue);
      FileBasedPrefs.SetInt("GhostWritingBookInventory", int.MaxValue);
      FileBasedPrefs.SetInt("IRLightSensorInventory", int.MaxValue);
      FileBasedPrefs.SetInt("ParabolicMicrophoneInventory", int.MaxValue);
      FileBasedPrefs.SetInt("IRLightSensorInventory", int.MaxValue);
      FileBasedPrefs.SetInt("ParabolicMicrophoneInventory", int.MaxValue);
      FileBasedPrefs.SetInt("GlowstickInventory", int.MaxValue);
      FileBasedPrefs.SetInt("HeadMountedCameraInventory", int.MaxValue);
      Console.WriteLine("[+] Player statistics maxed out.");
    }

    public static void ResetAll()
    {
      FileBasedPrefs.SetInt("myTotalExp", 100);
      FileBasedPrefs.SetInt("totalExp", 100);
      FileBasedPrefs.SetInt("PlayersMoney", 100);
      FileBasedPrefs.SetInt("completedTraining", 1);
      FileBasedPrefs.SetInt("PlayerDied", 0);
      FileBasedPrefs.SetInt("EMFReaderInventory", 0);
      FileBasedPrefs.SetInt("FlashlightInventory", 0);
      FileBasedPrefs.SetInt("CameraInventory", 0);
      FileBasedPrefs.SetInt("LighterInventory", 0);
      FileBasedPrefs.SetInt("CandleInventory", 0);
      FileBasedPrefs.SetInt("UVFlashlightInventory", 0);
      FileBasedPrefs.SetInt("CrucifixInventory", 0);
      FileBasedPrefs.SetInt("DSLRCameraInventory", 0);
      FileBasedPrefs.SetInt("EVPRecorderInventory", 0);
      FileBasedPrefs.SetInt("SaltInventory", 0);
      FileBasedPrefs.SetInt("TripodInventory", 0);
      FileBasedPrefs.SetInt("StrongFlashlightInventory", 0);
      FileBasedPrefs.SetInt("MotionSensorInventory", 0);
      FileBasedPrefs.SetInt("SoundSensorInventory", 0);
      FileBasedPrefs.SetInt("SanityPillsInventory", 0);
      FileBasedPrefs.SetInt("ThermometerInventory", 0);
      FileBasedPrefs.SetInt("GhostWritingBookInventory", 0);
      FileBasedPrefs.SetInt("IRLightSensorInventory", 0);
      FileBasedPrefs.SetInt("ParabolicMicrophoneInventory", 0);
      FileBasedPrefs.SetInt("IRLightSensorInventory", 0);
      FileBasedPrefs.SetInt("ParabolicMicrophoneInventory", 0);
      FileBasedPrefs.SetInt("GlowstickInventory", 0);
      FileBasedPrefs.SetInt("HeadMountedCameraInventory", 0);
      Console.WriteLine("[+] Player statistics reseted.");
    }
  }
}
