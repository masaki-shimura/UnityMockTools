using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.Plastic.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;

namespace MSLib.Editor.Tools.ReferenceURL
{
    [CreateAssetMenu(fileName = "ReferenceURLWindowSetting",
        menuName = "ScriptableObjects/ReferenceURLWindowSettingAsset")]
    public class ReferenceURLWindowSettingAsset : ScriptableObject
    {
        [SerializeField] private List<ReferenceURL> _referenceUrlList = new ListStack<ReferenceURL>();

        private static string _assetPath = "";

        private const string DefaultAssetPath =
            "Assets/MSLib/Editor/Tools/ReferenceURL/ReferenceURLWindowSetting.asset";

        public IReadOnlyList<ReferenceURL> ReferenceUrlList => _referenceUrlList;

        private ReferenceURLWindowSettingAsset()
        {
            _assetPath = DefaultAssetPath;
        }

        public static ReferenceURLWindowSettingAsset LoadAsset(string path = null)
        {
            if (String.IsNullOrEmpty(path) == false)
            {
                _assetPath = path;
            }

            var asset = AssetDatabase.LoadAssetAtPath<ReferenceURLWindowSettingAsset>(_assetPath);
            Assert.IsNotNull(asset, "設定ファイルがNullでした");
            return asset;
        }
    }
}