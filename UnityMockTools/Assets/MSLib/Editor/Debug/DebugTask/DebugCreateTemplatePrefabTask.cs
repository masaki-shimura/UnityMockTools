using System;
using UnityEngine.Assertions;
using UnityEditor;
using UnityEngine;

namespace MSLib
{
    public sealed class DebugCreateTemplatePrefabTask : IDebugTask
    {
        private Vector2 scrollPosition = new Vector2();
        public bool IsFoldout { get; set; }
        private const string overviewText = "シーン上に任意のプレハブを生成します";
        private EditorTemplatePrefabAsset _editorTemplatePrefabAsset = null;
        private string settingFilePath = "Assets/Editor/Debug/DebugScriptableObject/EditorTemplatePrefabAsset.asset";
        private DebugTemplatePrefabGroup selectGroup = DebugTemplatePrefabGroup.None;

        public void Init()
        {
            _editorTemplatePrefabAsset = AssetDatabase.LoadAssetAtPath<EditorTemplatePrefabAsset>(settingFilePath);
            Assert.IsNotNull(_editorTemplatePrefabAsset, "設定ファイルがNullでした");
        }

        public void UnInit()
        {
        }

        public void Update()
        {
        }

        public void Draw()
        {
            if (_editorTemplatePrefabAsset == null)
            {
                EditorGUILayout.HelpBox("設定ファイルがロード出来ませんでした", MessageType.Error);
                EditorGUILayout.LabelField("設定ファイルのパスを読み込ませて下さい");
                settingFilePath = EditorGUILayout.TextField(settingFilePath);
                if (GUILayout.Button("初期化", GUILayout.MaxWidth(100.0f)))
                {
                    Init();
                }

                return;
            }

            EditorGUILayout.ObjectField("設定ファイル", _editorTemplatePrefabAsset, typeof(object), true,
                GUILayout.MaxWidth(300.0f));

            EditorGUILayout.LabelField("フィルター", GUILayout.MaxWidth(150.0f));
            using (new GUILayout.HorizontalScope())
            {
                var templatePrefabGroupList = Enum.GetValues(typeof(DebugTemplatePrefabGroup));
                foreach (DebugTemplatePrefabGroup groupName in templatePrefabGroupList)
                {
                    if (GUILayout.Button(groupName.ToString(), GUILayout.MaxWidth(100.0f)))
                    {
                        selectGroup = groupName;
                    }
                }
            }

            using (new GUILayout.VerticalScope(GUI.skin.box))
            {
                using (var scrollView = new EditorGUILayout.ScrollViewScope(scrollPosition))
                {
                    scrollPosition = scrollView.scrollPosition;

                    using (new GUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("ラベル", GUILayout.MaxWidth(150.0f));
                        EditorGUILayout.LabelField("グループ", GUILayout.MaxWidth(150.0f));
                        EditorGUILayout.LabelField("プレハブ", GUILayout.MaxWidth(150.0f));
                        EditorGUILayout.LabelField("", GUILayout.MaxWidth(100.0f));
                    }

                    foreach (var info in _editorTemplatePrefabAsset.TemplatePrefabList)
                    {
                        if (info.group.HasFlag(selectGroup) == false)
                        {
                            continue;
                        }

                        using (new GUILayout.HorizontalScope())
                        {
                            info.label = EditorGUILayout.TextField(info.label, GUILayout.MaxWidth(150.0f));
                            info.group =
                                (DebugTemplatePrefabGroup)EditorGUILayout.EnumPopup(info.group,
                                    GUILayout.MaxWidth(150.0f));
                            info.templatePrefab = (GameObject)EditorGUILayout.ObjectField(info.templatePrefab,
                                typeof(GameObject), true, GUILayout.MaxWidth(150.0f));
                            if (GUILayout.Button("Create", GUILayout.MaxWidth(100.0f)))
                            {
                                Execution(info.templatePrefab);
                            }
                        }
                    }
                }
            }
        }

        public void Execution()
        {
        }

        private void Execution(GameObject prefab)
        {
            PrefabUtility.InstantiatePrefab(prefab);
        }

        public string GetOverviewText()
        {
            return overviewText;
        }
    }
}