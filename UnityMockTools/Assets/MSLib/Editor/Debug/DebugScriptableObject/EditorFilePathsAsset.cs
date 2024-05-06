using System;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MSLib
{
    [CreateAssetMenu(fileName = "EditorFilePaths",menuName = "ScriptableObjects/EditorFilePathsAsset")]
    public class EditorFilePathsAsset : ScriptableObject
    {
        [SerializeField] private List<DebugFileFocusData> folderPathList = new List<DebugFileFocusData>();
        [SerializeField] private List<DebugObjectFocusData> gameObjectPathList = new List<DebugObjectFocusData>();
        public IReadOnlyList<DebugFileFocusData> PathList => folderPathList;
        public IReadOnlyList<DebugObjectFocusData> GameObjectPathList => gameObjectPathList;
    }

    [Serializable]
    public class DebugFileFocusData
    {
        public string label = "";
        public string path = "";
    }

    [Serializable]
    public class DebugObjectFocusData
    {
        public string label = "";
        public Object target = null;
    }
}

