using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using LostMythToolsPackage.Editor;

namespace LostMythToolsPackage.UnpackFBX
{
    public class UnpackFBX_SettingsProvider : SettingsProvider
    {
        public UnpackFBX_SettingsProvider() : base("Project/UnpackFBX", SettingsScope.Project) { }

        [SettingsProvider]
        public static SettingsProvider CreateProvider()
        {
            return new UnpackFBX_SettingsProvider();
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            UnpackFBX_Settings.Load();
        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();
            UnpackFBX_Settings.Save();
        }

        public override void OnGUI(string searchContext)
        {
            base.OnGUI(searchContext);

            EditorGUILayout.Space();
            //UnpackFBX_Settings.DefaultPath = EditorGUILayout.TextField("Default Peth", UnpackFBX_Settings.DefaultPath);
            string path = UnpackFBX_Settings.DefaultPath;
            GUICustomElements.FolderDialog("Default Path", "Unity engine - Unpack FBX", "", ref path, 
                new GUILayoutOption[] { GUILayout.Width(EditorGUIUtility.currentViewWidth * 0.1f), GUILayout.MinWidth(54), GUILayout.Height(EditorGUIUtility.singleLineHeight)} );
            UnpackFBX_Settings.DefaultPath = path;

            UnpackFBX_Settings.OpenWhenImport = EditorGUILayout.Toggle("Open When Import", UnpackFBX_Settings.OpenWhenImport);
        }
    }
}
