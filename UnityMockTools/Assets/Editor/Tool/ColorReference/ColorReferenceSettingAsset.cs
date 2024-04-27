using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace MSLib
{
    [CreateAssetMenu(fileName = "ColorReferenceSetting", menuName = "ScriptableObjects/ColorReferenceSettingAsset")]
    public sealed class ColorReferenceSettingAsset : ScriptableObject
    {
        private readonly List<ColorReference> _colorReferences = new List<ColorReference>(5)
        {
            new(Color.white, "初期カラー1"),
            new(Color.blue, "初期カラー2"),
            new(Color.green, "初期カラー3"),
        };

        private static string _assetPath = "";
        private const string DefaultAssetPath = "Assets/Editor/Tool/ColorReference/ColorReferenceSetting.asset";

        public string UpdateLabel { get; set; } = "NONE";
        public Color UpdateColor { get; set; } = Color.white;
        public int UpdateIndex { set; get; }
        public int ReferenceCount => _colorReferences.Count - 1;
        public IReadOnlyList<ColorReference> ColorReferenceList => _colorReferences;

        private ColorReferenceSettingAsset()
        {
            _assetPath = DefaultAssetPath;
        }

        public static ColorReferenceSettingAsset LoadAsset(string path = null)
        {
            if (String.IsNullOrEmpty(path) == false)
            {
                _assetPath = path;
            }

            var asset = AssetDatabase.LoadAssetAtPath<ColorReferenceSettingAsset>(_assetPath);
            Assert.IsNotNull(asset, "設定ファイルがNullでした");
            return asset;
        }

        public void UpdateColorReference()
        {
            if (ReferenceCount <= 0 || UpdateIndex < 0)
            {
                return;
            }

            var idx = UpdateIndex;
            _colorReferences[idx] = new ColorReference(UpdateColor, UpdateLabel);
            EditorUtility.SetDirty(this);
        }

        public void AddColorReference()
        {
            _colorReferences.Add(new ColorReference(UpdateColor, UpdateLabel));
            EditorUtility.SetDirty(this);
        }

        public void RemoveColorReference()
        {
            if (_colorReferences.Count <= UpdateIndex || _colorReferences.Count <= 0)
            {
                return;
            }

            _colorReferences.RemoveAt(UpdateIndex);
            EditorUtility.SetDirty(this);
        }
    }
}