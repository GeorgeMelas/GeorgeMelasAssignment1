using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;          // This namespace will allow the tab in unity appear with the devices we code for.
public class BuildScript
{
    static string[] scenes = FindEnabledEditorScenes();
    static string appName = "Inventory";
    static string targetDir = "Build";
    
    // Creates an item for the build tab.
    [MenuItem("Build/Windows(x86)")]    // x86 Format
    static void WindowsBuildx86()       //Function
    {
        string appDir = appName + ".exe";   // if the Appdir is called Inventory this will be called Inventory.exe
        GenericBuild(scenes, targetDir + "/" + appDir, BuildTarget.StandaloneWindows, BuildOptions.None);  //Contstaints that we give it when building
    }

    
    // Same here But this time we are building it for android.

    [MenuItem("Build/Android")]
    static void AndroidSDK()
    {
        string appDir = appName + ".apk";   // apk File format
        GenericBuild(scenes, targetDir + "/" + appDir, BuildTarget.Android, BuildOptions.None); // Building to android
    }


    private static string[] FindEnabledEditorScenes()
    { 
    List<string> EditorScenes = new List<string>();
    foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
    {
        if(!scene.enabled) continue;
        EditorScenes.Add(scene.path);   // This will allow to build via Cmd, this will make a build without even going in the program.
    }

    return EditorScenes.ToArray();

    }

    static void GenericBuild(string[] scenes,string targetDir,BuildTarget buildTarget,BuildOptions buildOptions)
        // Creates a Generic Build through the command line,calls it what we have called it in the code and what platform we have selected in the Cmd Line
    {
        BuildPipeline.BuildPlayer(scenes, targetDir, buildTarget, buildOptions);
        string result = BuildPipeline.BuildPlayer(scenes, targetDir, buildTarget, buildOptions);
        if(result.Length > 0)
        {
            throw new Exception("BuildPlayer falure: " + result);
            // If it Fails Throw execption.
        }
    }
}
