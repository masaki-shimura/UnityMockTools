using UnityEditor;

namespace MSLib.Editor.Tools.UnitTestEditor
{
    public sealed class UnitTaskEditorCategoryReferenceTask : IEditorWindowTask
    {
        private const string overviewText = "ユニットテストのカテゴリを参照します";

        private readonly UnitTestEditorModel _unitTestEditorModel = null;

        public bool IsFoldout { get; set; }

        public UnitTaskEditorCategoryReferenceTask(UnitTestEditorModel model)
        {
            _unitTestEditorModel = model;
        }

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