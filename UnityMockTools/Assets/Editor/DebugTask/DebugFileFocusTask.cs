using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace MSLib
{
    public sealed class DebugFileFocusTask : IDebugTask
    {
        private Vector2 scrollPosition = new Vector2();
        private const string overviewText = "「Project」Windowで任意のファイルをフォーカスする事が出来ます";
        private string[] paths = new[] { "IDebugTask" };//Assets/.../
        private EditorFilePathsAsset editorFilePathsAsset = null;
        private const string SettingFilePath = "Assets/Editor/DebugScriptableObject/EditorFilePaths.asset";
        
        
        public bool IsFoldout { get; set; }

        public void Init()
        { 
            editorFilePathsAsset = AssetDatabase.LoadAssetAtPath<EditorFilePathsAsset>(SettingFilePath);
            Assert.IsNotNull(editorFilePathsAsset,"設定ファイルがNullでした");
        }

        public void UnInit()
        {
            
        }

        public void Update()
        {
            
        }

        public void Draw()
        {
            using (new GUILayout.VerticalScope())
            {
                using (var scrollView = new EditorGUILayout.ScrollViewScope(scrollPosition))
                {
                    scrollPosition = scrollView.scrollPosition;
                    
                    using (new GUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("ラベル",GUILayout.MaxWidth(150.0f));
                        EditorGUILayout.LabelField("ファイルパス",GUILayout.MaxWidth(500.0f));
                        EditorGUILayout.LabelField("",GUILayout.MaxWidth(100.0f));
                    }
                
                    foreach (var pathInfo in editorFilePathsAsset.PathList)
                    {
                        var path = pathInfo.path;
                        using (new GUILayout.HorizontalScope())
                        {
                            EditorGUILayout.LabelField(pathInfo.label,GUILayout.MaxWidth(150.0f));
                            EditorGUILayout.LabelField(path,GUILayout.MaxWidth(500.0f));
                            if (GUILayout.Button("Focus",GUILayout.MaxWidth(100.0f)))
                            {
                                Execution(path);
                            }
                        }
                    }
                }
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
        
        public void Execution(string path)
        {
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