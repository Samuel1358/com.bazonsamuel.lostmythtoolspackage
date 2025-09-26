using UnityEngine;
using UnityEditor;

namespace LostMythToolsPackage.UnpackFBX
{
    public class UnpackFBX_ImportObserver : AssetPostprocessor
    {
        public void OnPostprocessModel(GameObject gameObject)
        {
            if (!UnpackFBX_Settings.OpenWhenImport) return;

            if (!assetPath.EndsWith(".fbx", System.StringComparison.OrdinalIgnoreCase)) return;

            UnpackFBXWindow.ShowWindow();
        }
    }
}
