using UnityEditor;

namespace MSLib
{
    public sealed class UnitTestEditorWindow : EditorWindow
    {
        private DebugTaskManager _debugTaskManager = new DebugTaskManager();
        private static UnitTestEditorModel _unitTestEditorModel;

        [MenuItem("Tools/UnitTest/DebugUnitTestEditorWindow")]
        static void Initialize()
        {
            var window =
                (UnitTestEditorWindow)EditorWindow.GetWindow(typeof(UnitTestEditorWindow));
            window.Show();
        }

        void OnEnable()
        {
            _unitTestEditorModel = new UnitTestEditorModel();
            _debugTaskManager.AddTask("Test Execution", new UnitTestEditorTestExecutionTask(_unitTestEditorModel));
            _debugTaskManager.AddTask("Category Reference",
                new UnitTaskEditorCategoryReferenceTask(_unitTestEditorModel));
            _debugTaskManager.Init();
        }

        void OnDisable()
        {
            _debugTaskManager.UnInit();
        }

        private void OnGUI()
        {
            _debugTaskManager.Draw();
        }
    }
}