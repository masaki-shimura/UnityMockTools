using UnityEditor;

namespace MSLib
{
    public sealed class UnitTestEditorWindow : EditorWindow
    {
        private UnitTestEditorModel _unitTestEditorModel = null;

        [MenuItem("Tools/UnitTest/DebugUnitTestEditorWindow")]
        static void Initialize()
        {
            var window =
                (UnitTestEditorWindow)EditorWindow.GetWindow(typeof(UnitTestEditorWindow));
            window.Show();
        }

        UnitTestEditorWindow()
        {
            _unitTestEditorModel = new UnitTestEditorModel();
        }

        private void OnGUI()
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
    }
}