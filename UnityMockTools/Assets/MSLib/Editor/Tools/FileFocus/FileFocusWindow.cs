using UnityEditor;

namespace MSLib
{
    public sealed class FileFocusWindow : EditorWindow
    {
        private EditorWindowTaskManager _editorWindowTaskManager = new EditorWindowTaskManager();

        [MenuItem("Tools/FileFocusWindow")]
        static void Initialize()
        {
            var window = (FileFocusWindow)EditorWindow.GetWindow(typeof(FileFocusWindow));
            window.Show();
        }

        private void OnGUI()
        {
            _editorWindowTaskManager.Draw();
        }

        private void OnEnable()
        {
            _editorWindowTaskManager.AddTask("ファイルフォーカス", new EditorWindowFileFocusTask());

            _editorWindowTaskManager.Init();
        }

        private void OnDisable()
        {
            _editorWindowTaskManager.UnInit();
        }
    }
}