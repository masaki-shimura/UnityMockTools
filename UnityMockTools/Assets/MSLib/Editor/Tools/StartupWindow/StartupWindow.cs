using System;
using UnityEditor;
using UnityEngine;

namespace MSLib.Editor.Tools.StartupWindow
{
    public sealed class StartupWindow : EditorWindow
    {
        private static StartupWindowSetting _settingAsset = null;

        [MenuItem("Tools/Startup Window")]
        public static void ShowWindow()
        {
            GetWindow<StartupWindow>("Startup Window");
            _settingAsset = StartupWindowSetting.LoadAsset();
        }

        private void OnGUI()
        {
            _settingAsset =
                EditorGUILayout.ObjectField(_settingAsset, typeof(StartupWindowSetting)) as
                    StartupWindowSetting;
            if (_settingAsset == null)
            {
                EditorGUILayout.LabelField("「StartupWindowSetting」の設定ファイルが参照出来ていません");
                return;
            }

            EditorGUILayout.LabelField($"{DateTime.Now:yyyy/MM/dd HH:mm}");
            EditorGUILayout.LabelField(_settingAsset.titleText);
            using (new GUILayout.VerticalScope(GUI.skin.box))
            {
                EditorGUILayout.LabelField(_settingAsset.bodyText);
            }
        }
    }
}