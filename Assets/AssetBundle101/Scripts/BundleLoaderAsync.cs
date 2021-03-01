﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class BundleLoaderAsync : MonoBehaviour
{
    public string bundleName = "testbundle";
    public string assetName = "BundledSpriteObject";


    // Start is called before the first frame update
    IEnumerator Start()
    {
        AssetBundleCreateRequest asyncBundleRequest = AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, bundleName));
        yield return asyncBundleRequest;

        AssetBundle localAssetBundle = asyncBundleRequest.assetBundle;


        if (localAssetBundle == null)
        {
            Debug.LogError("Failed to load AssetBundle!");
            yield break;
        }

        AssetBundleRequest assetRequest = localAssetBundle.LoadAssetAsync<GameObject>(assetName);
        yield return assetRequest;

        GameObject prefab = assetRequest.asset as GameObject;

        Instantiate(prefab);

        localAssetBundle.Unload(false);
    }
}
