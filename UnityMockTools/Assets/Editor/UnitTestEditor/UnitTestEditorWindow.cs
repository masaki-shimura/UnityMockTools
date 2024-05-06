using UnityEditor;

namespace MSLib
{
    public sealed class UnitTestEditorWindow : EditorWindow
    {
        private DebugTaskManager _debugTaskManager = new DebugTaskManager();

        [MenuItem("Tools/UnitTest/DebugUnitTestEditorWindow")]
        static void Initialize()
        {
            var window =
                (UnitTestEditorWindow)EditorWindow.GetWindow(typeof(UnitTestEditorWindow));
            window.Show();
        }

        UnitTestEditorWindow()
        {
            _debugTaskManager.AddTask("Category Reference", new UnitTaskEditorCategoryReferenceTask());
            _debugTaskManager.Init();
        }

        ~UnitTestEditorWindow()
        {
            _debugTaskManager.UnInit();
        }

        private void OnGUI()
        {
            _debugTaskManager.Draw();
        }
    }
}