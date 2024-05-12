using UnityEditor;

namespace MSLib.Editor.Tools.ReferenceURL
{
    public sealed class ReferenceURLWindow : EditorWindow
    {
        private EditorWindowTaskManager _editorWindowTaskManager = new EditorWindowTaskManager();

        [MenuItem("Tools/ReferenceURLWindow")]
        static void Initialize()
        {
            var window =
                (ReferenceURLWindow)EditorWindow.GetWindow(typeof(ReferenceURLWindow));
            window.Show();
        }

        private void OnGUI()
        {
            _editorWindowTaskManager.Draw();
        }

        private void OnEnable()
        {
            _editorWindowTaskManager.AddTask("Reference URL List", new EditorWindowNullObjectTask());

            _editorWindowTaskManager.Init();
        }

        private void OnDisable()
        {
            _editorWindowTaskManager.UnInit();
        }
    }
}