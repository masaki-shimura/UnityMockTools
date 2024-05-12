using UnityEditor;
using UnityEngine;

namespace MSLib.Editor.Tools.ReferenceURL
{
    public class ReferenceURLListTask : IEditorWindowTask
    {
        private ReferenceURLWindowSettingAsset _settingAsset;
        public bool IsFoldout { get; set; }


        public void Init()
        {
            _settingAsset = ReferenceURLWindowSettingAsset.LoadAsset();
        }

        public void UnInit()
        {
        }

        public void Update()
        {
        }

        public void Draw()
        {
            using (new GUILayout.VerticalScope(GUI.skin.box))
            {
                _settingAsset =
                    EditorGUILayout.ObjectField(_settingAsset, typeof(ReferenceURLWindowSettingAsset)) as
                        ReferenceURLWindowSettingAsset;
                if (_settingAsset == null)
                {
                    EditorGUILayout.LabelField("設定データの参照を付けてください");
                    return;
                }
            }

            DrawURLList();
        }

        private void DrawURLList()
        {
            using (new GUILayout.VerticalScope(GUI.skin.box))
            {
                using (new GUILayout.VerticalScope(GUI.skin.box))
                {
                    foreach (var info in _settingAsset.ReferenceUrlList)
                    {
                        DrawContentURL(info);
                    }
                }
            }
        }

        private void DrawContentURL(ReferenceURL referenceURL)
        {
            using (new GUILayout.HorizontalScope(GUI.skin.box))
            {
                EditorGUILayout.LabelField(referenceURL.tag, GUILayout.MaxWidth(150.0f));

                var buttonContent = new GUIContent("Open", referenceURL.toolTipText);
                var buttonRect = GUILayoutUtility.GetRect(buttonContent, GUI.skin.button, GUILayout.MaxWidth(100.0f));
                if (GUI.Button(buttonRect, buttonContent))
                {
                    Application.OpenURL(referenceURL.url);
                }

                EditorGUILayout.TextField(referenceURL.url);
            }
        }

        public void Execution()
        {
        }

        public string GetOverviewText()
        {
            return this.GetType().Name;
        }
    }
}