using System;
using System.Collections.Generic;
using UnityEngine;

namespace MSLib
{
    [CreateAssetMenu(fileName = "EditorFilePaths",menuName = "ScriptableObjects/EditorFilePathsAsset")]
    public class EditorFilePathsAsset : ScriptableObject
    {
        [SerializeField] private List<DebugFileFocusData> pathList = new List<DebugFileFocusData>();
        public IReadOnlyList<DebugFileFocusData> PathList => pathList;
    }

    [Serializable]
    public class DebugFileFocusData
    {
        public string label = "";
        public string path = "";
    }
}

