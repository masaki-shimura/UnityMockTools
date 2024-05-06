using UnityEditor;

namespace MSLib.Editor.Tools.CreateTemplatePrefab
{
    public class CreateTemplatePrefabWindow : EditorWindow
    {
        private EditorWindowTaskManager _editorWindowTaskManager = new EditorWindowTaskManager();

        [MenuItem("Tools/CreateTemplatePrefabWindow")]
        static void Initialize()
        {
            var window =
                (CreateTemplatePrefabWindow)EditorWindow.GetWindow(typeof(CreateTemplatePrefabWindow));
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