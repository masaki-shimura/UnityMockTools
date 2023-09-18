using System;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

namespace MSLib
{
    [CreateAssetMenu(fileName = "EditorFilePaths",menuName = "ScriptableObjects/EditorFilePathsAsset")]
    public class EditorFilePathsAsset : ScriptableObject
    {
        [SerializeField] private List<DebugFileFocusData> folderPathList = new List<DebugFileFocusData>();
        [SerializeField] private List<DebugGameObjectFocusData> gameObjectPathList = new List<DebugGameObjectFocusData>();
        public IReadOnlyList<DebugFileFocusData> PathList => folderPathList;
        public IReadOnlyList<DebugGameObjectFocusData> GameObjectPathList => gameObjectPathList;
    }

    [Serializable]
    public class DebugFileFocusData
    {
        public string label = "";
        public string path = "";
    }

    [Serializable]
    public class DebugGameObjectFocusData
    {
        public string label = "";
        public GameObject target = null;
    }
}

