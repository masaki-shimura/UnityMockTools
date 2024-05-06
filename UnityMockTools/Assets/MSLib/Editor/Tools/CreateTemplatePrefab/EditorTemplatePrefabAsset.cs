using System;
using System.Collections.Generic;
using UnityEngine;

namespace MSLib.Editor.Tools.CreateTemplatePrefab
{
    [CreateAssetMenu(fileName = "EditorTemplatePrefabAsset", menuName = "ScriptableObjects/EditorTemplatePrefabAsset")]
    public sealed class EditorTemplatePrefabAsset : ScriptableObject
    {
        [SerializeField]
        private List<DebugTemplatePrefabData> _templatePrefabList = new List<DebugTemplatePrefabData>();

        public IReadOnlyList<DebugTemplatePrefabData> TemplatePrefabList => _templatePrefabList;
    }

    [Serializable]
    public sealed class DebugTemplatePrefabData
    {
        public GameObject templatePrefab = null;
        public string label = "";
        public DebugTemplatePrefabGroup group = DebugTemplatePrefabGroup.Default;
    }

    //グループ指定
    [Flags]
    public enum DebugTemplatePrefabGroup
    {
        None = 0x000,
        Default = 0x001,
        Player = 0x002,
        UI = 0x004,
        Sound = 0x008
    }
}