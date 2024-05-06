using UnityEditor;

namespace MSLib
{
    public sealed class UnitTaskEditorCategoryReferenceTask : IDebugTask
    {
        private const string overviewText = "ユニットテストのカテゴリを参照します";

        private UnitTestEditorModel _unitTestEditorModel = null;

        public bool IsFoldout { get; set; }

        public void Init()
        {
            _unitTestEditorModel = new UnitTestEditorModel();
        }

        public void UnInit()
        {
        }

        public void Update()
        {
        }

        public void Draw()
        {
            if (_unitTestEditorModel.CategoryNameList.Count <= 0)
            {
                EditorGUILayout.LabelField("表示するカテゴリがありません");
                return;
            }

            EditorGUILayout.LabelField($"カテゴリ情報");
            foreach (var info in _unitTestEditorModel.CategoryNameList)
            {
                EditorGUILayout.LabelField($"{info}");
            }
        }

        public void Execution()
        {
        }

        public string GetOverviewText()
        {
            return overviewText;
        }
    }
}