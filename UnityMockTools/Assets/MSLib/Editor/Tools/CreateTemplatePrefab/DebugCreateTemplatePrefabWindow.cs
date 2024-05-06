using UnityEditor;

namespace MSLib
{
    public class DebugCreateTemplatePrefabWindow : EditorWindow
    {
        private EditorWindowTaskManager _editorWindowTaskManager = new EditorWindowTaskManager();

        [MenuItem("Tools/Debug/DebugCreateTemplatePrefabWindow")]
        static void Initialize()
        {
            var window =
                (DebugCreateTemplatePrefabWindow)EditorWindow.GetWindow(typeof(DebugCreateTemplatePrefabWindow));
            window.Show();
        }

        private void OnGUI()
        {
            _editorWindowTaskManager.Draw();
        }

        private void OnEnable()
        {
            _editorWindowTaskManager.AddTask("Template Prefabs", new EditorWindowCreateTemplatePrefabTask());

            _editorWindowTaskManager.Init();
        }

        private void OnDisable()
        {
            _editorWindowTaskManager.UnInit();
        }
    }
}