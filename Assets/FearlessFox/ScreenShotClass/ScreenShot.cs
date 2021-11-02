///
/// Questions and bugs: davidbermudezlopez@gmail.com
///

using UnityEngine;
using System.Collections;
using System.IO;

/// <summary>
/// Allows you to take screenshots
/// </summary>
public static class ScreenShot
{
  private static Texture2D screenShot;

  private static string path;

  /// <summary>
  /// Screenshot of the main camera with the size of the screen
  /// </summary>
  /// <param name="path">Path where the file will be saved. Example: Other/ScreenShoot</param>
  /// <param name="name">Name that will have the file</param>
  public static void TakeScreenShot(string path, string name)
  {
    SetPathSaveFile(path, name);
    SaveFile(Screen.width, Screen.height);
  }

  /// <summary>
  /// Screenshot of the chosen camera with the size of the screen
  /// </summary>
  /// <param name="path">Path where the file will be saved. Example: Other/ScreenShoot</param>
  /// <param name="name">Name that will have the file</param>
  /// <param name="cameraUsed">Chosen camera for render</param>
  public static void TakeScreenShot(string path, string name, Camera cameraUsed)
  {
    SetPathSaveFile(path, name);
    SaveFile(Screen.width, Screen.height, cameraUsed);
  }

  /// <summary>
  /// Screenshot of the main camera with custom size
  /// </summary>
  /// <param name="path">Path where the file will be saved. Example: Other/ScreenShoot</param>
  /// <param name="name">Name that will have the file</param>
  /// <param name="width">Custom width size</param>
  /// <param name="height">Custom height size</param>
  public static void TakeScreenShot(string path, string name, int width, int height)
  {
    SetPathSaveFile(path, name);
    SaveFile(width, height);
  }

  /// <summary>
  /// Screenshot of the chosen camera with custom size
  /// </summary>
  /// <param name="path">Path where the file will be saved. Example: Other/ScreenShoot</param>
  /// <param name="name">Name that will have the file</param>
  /// <param name="width">Custom width size</param>
  /// <param name="height">Custom height size</param>
  /// <param name="cameraUsed">Chosen camera for render</param>
  public static void TakeScreenShot(string path, string name, int width, int height, Camera cameraUsed)
  {
    SetPathSaveFile(path, name);
    SaveFile(width, height, cameraUsed);
  }

  /// <summary>
  /// Adds a Screenshot to a material of MeshRenderer. Use of Main Camera with the size of the screen
  /// </summary>
  /// <param name="meshRenderer">Mesh with the material where the texture is saved</param>
  public static void ScreenTextureToMaterial(MeshRenderer meshRenderer, bool usedNewMaterial = false)
  {
    SaveTextureScreen(Screen.width, Screen.height);
    SetTextureAtMaterial(meshRenderer, usedNewMaterial);
  }

  /// <summary>
  ///  Adds a Screenshot to a material of MeshRenderer. Use of Chosen Camera with the size of the screen
  /// </summary>
  /// <param name="meshRenderer">Mesh with the material where the texture is saved</param>
  /// <param name="cameraUsed">Chosen camera for render</param>
  public static void ScreenTextureToMaterial(MeshRenderer meshRenderer, Camera cameraUsed, bool usedNewMaterial = false)
  {
    SaveTextureScreen(Screen.width, Screen.height, cameraUsed);
    SetTextureAtMaterial(meshRenderer, usedNewMaterial);
  }

  /// <summary>
  /// Adds a Screenshot to a material of MeshRenderer. Use of Main Camera with custom size
  /// </summary>
  /// <param name="width">Custom width size</param>
  /// <param name="height">Custom height size</param>
  /// <param name="meshRenderer">Mesh with the material where the texture is saved</param>
  public static void ScreenTextureToMaterial(int width, int height, MeshRenderer meshRenderer, bool usedNewMaterial = false)
  {
    SaveTextureScreen(width, height);
    SetTextureAtMaterial(meshRenderer, usedNewMaterial);
  }

  /// <summary>
  /// Adds a Screenshot to a material of MeshRenderer. Use of Chosen Camera with custom size
  /// </summary>
  /// <param name="width">Custom width size</param>
  /// <param name="height">Custom height size</param>
  /// <param name="meshRenderer">Mesh with the material where the texture is saved</param>
  /// <param name="cameraUsed">Chosen camera for render</param>
  public static void ScreenTextureToMaterial(int width, int height, MeshRenderer meshRenderer, Camera cameraUsed, bool usedNewMaterial = false)
  {
    SaveTextureScreen(width, height, cameraUsed);
    SetTextureAtMaterial(meshRenderer, usedNewMaterial);
  }

  private static void SaveTextureScreen(int width, int height)
  {
    RenderTexture rt = new RenderTexture(width, height, 24);
    Camera.main.targetTexture = rt;
    screenShot = new Texture2D(width, height, TextureFormat.RGB24, false);
    Camera.main.Render();
    RenderTexture.active = rt;
    screenShot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
    Camera.main.targetTexture = null;
    RenderTexture.active = null;
    rt = null;
  }

  private static void SetTextureAtMaterial(MeshRenderer meshRenderer, bool usedNewMaterial)
  {
    if (usedNewMaterial)
      meshRenderer.material = new Material(meshRenderer.material);

    meshRenderer.material.mainTexture = screenShot;
    meshRenderer.material.mainTextureScale = new Vector2(-1, -1);
    screenShot.Apply();
    Debug.Log(string.Format("Update with ´ScreenMaterial´ {0}", meshRenderer.name));
  }

  private static void SaveTextureScreen(int width, int height, Camera cameraUsed)
  {
    RenderTexture renderTexture = new RenderTexture(width, height, 30);
    screenShot = new Texture2D(width, height, TextureFormat.RGB24, false);
    cameraUsed.targetTexture = renderTexture;
    cameraUsed.Render();
    RenderTexture.active = renderTexture;
    screenShot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
    cameraUsed.targetTexture = null;
    RenderTexture.active = null;
    renderTexture = null;
  }

  private static void SaveFile(int width, int height)
  {
    SaveTextureScreen(width, height);
    SaveFile();
  }

  private static void SaveFile(int width, int height, Camera cameraUsed)
  {
    SaveTextureScreen(width, height, cameraUsed);
    SaveFile();
  }

  private static void SaveFile()
  {
    byte[] bytes = screenShot.EncodeToPNG();
    string filename = path;
    if (string.IsNullOrEmpty(filename))
      Debug.LogError("Path invalid");
    File.WriteAllBytes(filename, bytes);
    Debug.Log(string.Format("Saved ScreenShot {0}", filename));
  }

  private static void SetPathSaveFile(string _path, string nameFile)
  {
    path = string.Format("{0}/{1}/{2}.png", Application.dataPath, _path, nameFile);

    if (Directory.Exists(path) == false)
    {
      Debug.Log("Path not found. Has been created");
      string auxPath = string.Format("{0}/{1}", Application.dataPath, _path);
      Directory.CreateDirectory(auxPath);
    }
  }

}
