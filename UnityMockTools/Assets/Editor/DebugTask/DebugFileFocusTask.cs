using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace MSLib
{
    public sealed class DebugFileFocusTask : IDebugTask
    {
        private const string overviewText = "「Project」Windowで任意のファイルをフォーカスする事が出来ます";
        private string[] paths = new[] { "IDebugTask" };//Assets/.../
        
        public bool IsFoldout { get; set; }

        public void Init()
        {
            
        }

        public void UnInit()
        {
            
        }

        public void Update()
        {
            
        }

        public void Draw()
        {
            if (GUILayout.Button("Focus"))
            {
                Execution();
            }
        }

        /// <summary>
        /// フォルダパスからProject Window の一番上にフォーカスをあてる
        /// NOTE:ファイルフォーカスの手順
        /// 1. 指定のパスで、型が type である最初のアセットオブジェクトを取得                                                                
        /// 2. ウィンドウを最前面に移動                                                                                     
        /// 3. UnityEditor内の参照からProjectBrowserのインスタンスを取得                                                        
        /// 4. フォルダを開くメソッドであるShowFolderContentsを実行                                                              
        ///　※参考サイト:https://github.com/Unity-Technologies/UnityCsReference/blob/master/Editor/Mono/ProjectBrowser.cs 
        /// </summary>
        public void Execution()
        {
            string path = "Assets/Editor";
            
            var obj = AssetDatabase.LoadAssetAtPath(path, typeof(UnityEngine.Object)); 
            EditorUtility.FocusProjectWindow();
            
            var projectBrowserType = Type.GetType("UnityEditor.ProjectBrowser,UnityEditor");
            var instance = projectBrowserType.GetField("s_LastInteractedProjectBrowser", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).GetValue(null);
            
            var methodInfo = projectBrowserType.GetMethod("ShowFolderContents", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            methodInfo.Invoke(instance, new object[] { obj.GetInstanceID(), true });
        }

        public string GetOverviewText()
        {
            return overviewText;
        }
    }
}