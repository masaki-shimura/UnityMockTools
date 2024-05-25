using UnityEditor;
using UnityEngine;

namespace MSLib.Editor.Tools.StartupWindow
{
    public sealed class StartupWindow : EditorWindow
    {
        [MenuItem("Tools/Startup Window")]
        public static void ShowWindow()
        {
            GetWindow<StartupWindow>("Startup Window");
        }

        private void OnGUI()
        {
            GUILayout.Label("Startup Window");
        }
    }
}