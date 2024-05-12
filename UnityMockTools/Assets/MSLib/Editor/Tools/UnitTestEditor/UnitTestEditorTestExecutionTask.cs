using UnityEngine;

namespace MSLib.Editor.Tools.UnitTestEditor
{
    public sealed class UnitTestEditorTestExecutionTask : IEditorWindowTask
    {
        private const string overviewText = "各種UnitTaskの実行用";
        private readonly UnitTestEditorModel _unitTestEditorModel;

        public bool IsFoldout { get; set; }

        public UnitTestEditorTestExecutionTask(UnitTestEditorModel model)
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
            if (GUILayout.Button("テストの全実行", GUILayout.MaxWidth(200.0f)))
            {
                _unitTestEditorModel.RunEditTest();
            }

            GUILayout.Label("カテゴリ別実行");
            foreach (var categoryName in _unitTestEditorModel.CategoryNameList)
            {
                if (GUILayout.Button($"{categoryName}", GUILayout.MaxWidth(200.0f)))
                {
                    _unitTestEditorModel.RunEditTest(new[] { categoryName });
                }
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