using UnityEditor;
using UnityEngine;
using System.IO;
public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/StreamingAssets";
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        // ...(directory, what type of bundle to create - DryRunBuild,StricyMode, UncompresssedAssetBundle
        BuildPipeline.BuildAssetBundles(assetBundleDirectory,
            BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
    }
}