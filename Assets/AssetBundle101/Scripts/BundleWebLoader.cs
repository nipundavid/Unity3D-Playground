using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BundleWebLoader : MonoBehaviour
{

    public string bundleURL = "http://localhost/assetbundles/testbundle";
    public string assetName = "BundledSpriteObject";
    // Start is called before the first frame update
    IEnumerator Start()
    {
        using (WWW web = new WWW(bundleURL))
        {
            yield return web;
            AssetBundle remoteAssetBundle = web.assetBundle;
            if(remoteAssetBundle == null)
            {
                Debug.LogError("Failed to load AssetBundle!");
                yield break;
            }
            GameObject a = (GameObject)Instantiate(remoteAssetBundle.LoadAsset(assetName));
            remoteAssetBundle.Unload(false);
        }
    }
}