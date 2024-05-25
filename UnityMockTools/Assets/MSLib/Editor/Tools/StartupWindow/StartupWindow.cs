using System;
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
            EditorGUILayout.LabelField($"{DateTime.Now:yyyy/MM/dd HH:mm}");
            EditorGUILayout.LabelField("■ スタートアップ画面");
            using (new GUILayout.VerticalScope(GUI.skin.box))
            {
                EditorGUILayout.LabelField("ヽ(^o^)丿＜ 今日も頑張っていきましょう");
            }
        }
    }
}