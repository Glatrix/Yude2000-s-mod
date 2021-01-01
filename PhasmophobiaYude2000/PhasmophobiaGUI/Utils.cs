// Decompiled with JetBrains decompiler
// Type: PhasmophobiaGUI.Utils
// Assembly: PhasmophobiaGUI, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0967AAEE-F31B-4649-99E8-D66F4327D3A0
// Assembly location: C:\Users\Ry\Desktop\New folder\PhasmophobiaGUI.dll

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace PhasmophobiaGUI
{
  public class Utils
  {
    public static void CreateConsole()
    {
      Utils.AllocConsole();
      IntPtr stdHandle = Utils.GetStdHandle(-11);
      IntPtr file = Utils.CreateFile("CONOUT$", 3221225472U, FileShare.Write, IntPtr.Zero, FileMode.OpenOrCreate, (FileAttributes) 0, IntPtr.Zero);
      if (!(file != stdHandle))
        return;
      Utils.SetStdHandle(-11, file);
      Console.SetOut((TextWriter) new StreamWriter(Console.OpenStandardOutput(), Console.OutputEncoding)
      {
        AutoFlush = true
      });
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetStdHandle(int nStdHandle, IntPtr hHandle);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr CreateFile(
      [MarshalAs(UnmanagedType.LPTStr)] string filename,
      [MarshalAs(UnmanagedType.U4)] uint access,
      [MarshalAs(UnmanagedType.U4)] FileShare share,
      IntPtr securityAttributes,
      [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
      [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes,
      IntPtr templateFile);

    [DllImport("kernel32")]
    private static extern bool AllocConsole();
  }
}
