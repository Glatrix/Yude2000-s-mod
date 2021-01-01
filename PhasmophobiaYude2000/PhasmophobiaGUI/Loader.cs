// Decompiled with JetBrains decompiler
// Type: PhasmophobiaGUI.Loader
// Assembly: PhasmophobiaGUI, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0967AAEE-F31B-4649-99E8-D66F4327D3A0
// Assembly location: C:\Users\Ry\Desktop\New folder\PhasmophobiaGUI.dll

using UnityEngine;

namespace PhasmophobiaGUI
{
  public class Loader
  {
    private static GameObject gameObject;

    public static void Load()
    {
      Loader.gameObject = new GameObject();
      Loader.gameObject.AddComponent<Cheat>();
      Object.DontDestroyOnLoad((Object) Loader.gameObject);
    }

    public static void Unload() => Object.Destroy((Object) Loader.gameObject);
  }
}
