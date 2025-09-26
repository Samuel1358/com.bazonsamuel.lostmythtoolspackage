using System;
using UnityEngine;
#if UNITY_EDITOR
using LostMythToolsPackage.Editor;
#endif

#if UNITY_EDITOR
namespace LostMythToolsPackage.UnpackFBX
{
    public class UnpackFBX_Settings : CustomSettings<UnpackFBX_SettingsData, UnpackFBX_Settings>
    {
        public static string DefaultPath { get { return Data.DefaultPath; } set { Data.DefaultPath = value; } }
        public static bool OpenWhenImport { get { return Data.OpenWhenImport; } set { Data.OpenWhenImport = value; } }
    }

    [Serializable]
    public class UnpackFBX_SettingsData
    {
        public string DefaultPath;
        public bool OpenWhenImport;

        public UnpackFBX_SettingsData()
        {
            DefaultPath = Application.dataPath;
        }
    }
}
#endif
