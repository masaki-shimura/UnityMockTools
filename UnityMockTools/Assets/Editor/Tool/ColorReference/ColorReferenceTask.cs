using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MSLib
{
    public sealed class ColorReferenceTask : IDebugTask
    {
        public bool IsFoldout { get; set; }
        private const string OverviewText = "リファレンス用のカラー情報を保持します";

        private int colorReferenceUpdateIndex = 0;
        private string colorReferenceUpdateLabel = "NONE";
        private Color colorReferenceUpdateColor = Color.white;
        private static List<ColorReference> _colorReferences = new List<ColorReference>(5)
        {
            new(Color.white, "初期カラー1"),
            new(Color.blue, "初期カラー2"),
            new(Color.green, "初期カラー3"),
        };

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
            DrawReferenceColorList();
            
            DrawControlColorReference();
        }

        private void DrawControlColorReference()
        {
            EditorGUILayout.LabelField("□ ControlColorReference");
            using (new GUILayout.VerticalScope(GUI.skin.box))
            {
                colorReferenceUpdateIndex = EditorGUILayout.IntSlider(colorReferenceUpdateIndex,
                    0, _colorReferences.Count-1,GUILayout.MaxWidth(300.0f));
                colorReferenceUpdateLabel = EditorGUILayout.TextField(colorReferenceUpdateLabel,GUILayout.MaxWidth(300.0f));
                colorReferenceUpdateColor = EditorGUILayout.ColorField(colorReferenceUpdateColor,GUILayout.MaxWidth(300.0f));
                
                if (GUILayout.Button("更新",GUILayout.MaxWidth(300.0f)))
                {
                    UpdateColorReference();
                }
                if (GUILayout.Button("追加",GUILayout.MaxWidth(300.0f)))
                {
                    AddColorReference();
                }
                if (GUILayout.Button("削除",GUILayout.MaxWidth(300.0f)))
                {
                    RemoveColorReference();
                }
            }
        }

        private void UpdateColorReference()
        {
            if (_colorReferences.Count <= 0 || colorReferenceUpdateIndex < 0)
            {
                return;
            }
            var idx = colorReferenceUpdateIndex;
            _colorReferences[idx] = new ColorReference(colorReferenceUpdateColor,colorReferenceUpdateLabel);
        }

        private void AddColorReference()
        {
            _colorReferences.Add(new ColorReference(colorReferenceUpdateColor,colorReferenceUpdateLabel));
        }

        private void RemoveColorReference()
        {
            if (_colorReferences.Count <= colorReferenceUpdateIndex)
            {
                return;
            }
            _colorReferences.RemoveAt(colorReferenceUpdateIndex);
        }

        private void DrawReferenceColorList()
        {
            EditorGUILayout.LabelField("□ ReferenceColorList");
            using (new GUILayout.VerticalScope(GUI.skin.box))
            {
                foreach (var reference in _colorReferences)
                {
                    using (new GUILayout.VerticalScope(GUI.skin.box))
                    {
                        EditorGUILayout.LabelField(reference.LabelName);
                        EditorGUILayout.ColorField(reference.Color);
                    }
                }
            }
        }

        public void Execution()
        {
        }

        public string GetOverviewText()
        {
            return OverviewText;
        }
    }
}