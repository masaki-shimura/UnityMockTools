using System;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace MSLib.Editor.Tools.StartupWindow
{
    [CreateAssetMenu(fileName = "StartupWindowSetting",
        menuName = "ScriptableObjects/StartupWindowSetting")]
    public sealed class StartupWindowSetting : ScriptableObject
    {
        public string titleText = "";
        public string bodyText = "";
        private static string _assetPath = "";
        private const string DefaultAssetPath = "Assets/MSLib/Editor/Tools/StartupWindow/StartupWindowSetting.asset";

        private StartupWindowSetting()
        {
            _assetPath = DefaultAssetPath;
        }

        public static StartupWindowSetting LoadAsset(string path = null)
        {
            if (String.IsNullOrEmpty(path) == false)
            {
                _assetPath = path;
            }

            var asset = AssetDatabase.LoadAssetAtPath<StartupWindowSetting>(_assetPath);
            Assert.IsNotNull(asset, "設定ファイルがNullでした");
            return asset;
        }
    }
}