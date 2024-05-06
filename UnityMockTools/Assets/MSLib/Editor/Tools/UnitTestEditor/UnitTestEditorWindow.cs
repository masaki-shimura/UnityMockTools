using UnityEditor;

namespace MSLib.Editor.Tools.UnitTestEditor
{
    public sealed class UnitTestEditorWindow : EditorWindow
    {
        private EditorWindowTaskManager _editorWindowTaskManager = new EditorWindowTaskManager();
        private static UnitTestEditorModel _unitTestEditorModel;

        [MenuItem("Tools/UnitTestEditorWindow")]
        static void Initialize()
        {
            var window =
                (UnitTestEditorWindow)EditorWindow.GetWindow(typeof(UnitTestEditorWindow));
            window.Show();
        }

        void OnEnable()
        {
            _unitTestEditorModel = new UnitTestEditorModel();
            _editorWindowTaskManager.AddTask("Test Execution",
                new UnitTestEditorTestExecutionTask(_unitTestEditorModel));
            _editorWindowTaskManager.AddTask("Category Reference",
                new UnitTestEditorCategoryReferenceTask(_unitTestEditorModel));
            _editorWindowTaskManager.Init();
        }

        void OnDisable()
        {
            _editorWindowTaskManager.UnInit();
        }

        private void OnGUI()
        {
            _editorWindowTaskManager.Draw();
        }
    }
}