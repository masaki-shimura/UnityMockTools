using UnityEditor;

namespace MSLib
{
    public sealed class DebugFileFocusWindow : EditorWindow
    {
        private DebugTaskManager _debugTaskManager = new DebugTaskManager();

        [MenuItem("Tools/Debug/DebugFileFocusWindow")]
        static void Initialize()
        {
            var window = (DebugFileFocusWindow)EditorWindow.GetWindow(typeof(DebugFileFocusWindow));
            window.Show();
        }

        private void OnGUI()
        {
            _debugTaskManager.Draw();
        }

        private void OnEnable()
        {
            _debugTaskManager.AddTask("ファイルフォーカス", new DebugFileFocusTask());

            _debugTaskManager.Init();
        }

        private void OnDisable()
        {
            _debugTaskManager.UnInit();
        }
    }
}