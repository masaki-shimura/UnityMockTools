using System;
using UnityEditor;
using UnityEngine;

namespace MSLib.Editor.Tools.ColorReference
{
    public sealed class ColorReferenceTask : IEditorWindowTask
    {
        private ColorReferenceSettingAsset _settingAsset;
        public bool IsFoldout { get; set; }

        private const string OverviewText = "リファレンス用のカラー情報を保持します";

        public void Init()
        {
            _settingAsset = ColorReferenceSettingAsset.LoadAsset();
        }

        public void UnInit()
        {
        }

        public void Update()
        {
        }

        [Obsolete("Obsolete")]
        public void Draw()
        {
            using (new GUILayout.VerticalScope(GUI.skin.box))
            {
                _settingAsset =
                    EditorGUILayout.ObjectField(_settingAsset, typeof(ColorReferenceSettingAsset)) as
                        ColorReferenceSettingAsset;
                if (_settingAsset == null)
                {
                    EditorGUILayout.LabelField("設定データの参照を付けてください");
                    return;
                }
            }

            DrawReferenceColorList();

            DrawControlColorReference();
        }

        private void DrawControlColorReference()
        {
            EditorGUILayout.LabelField("□ ControlColorReference");

            using (new GUILayout.VerticalScope(GUI.skin.box))
            {
                _settingAsset.UpdateIndex = EditorGUILayout.IntSlider(_settingAsset.UpdateIndex,
                    0, _settingAsset.ReferenceCount, GUILayout.MaxWidth(300.0f));

                _settingAsset.UpdateLabel =
                    EditorGUILayout.TextField(_settingAsset.UpdateLabel, GUILayout.MaxWidth(300.0f));
                _settingAsset.UpdateColor =
                    EditorGUILayout.ColorField(_settingAsset.UpdateColor, GUILayout.MaxWidth(300.0f));

                if (GUILayout.Button("更新", GUILayout.MaxWidth(300.0f)))
                {
                    _settingAsset.UpdateColorReference();
                }

                if (GUILayout.Button("追加", GUILayout.MaxWidth(300.0f)))
                {
                    _settingAsset.AddColorReference();
                }

                if (GUILayout.Button("削除", GUILayout.MaxWidth(300.0f)))
                {
                    _settingAsset.RemoveColorReference();
                }
            }
        }

        private void DrawReferenceColorList()
        {
            EditorGUILayout.LabelField("□ ReferenceColorList");
            using (new GUILayout.VerticalScope(GUI.skin.box))
            {
                foreach (var reference in _settingAsset.ColorReferenceList)
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