using System;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace MSLib.Editor.Tools.StartupWindow
{
    /// <summary>
    /// TODO:現在は未使用です。※起動直後に読み込もうとすると参照する事が出来ない為
    /// </summary>
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