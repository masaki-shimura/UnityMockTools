using UnityEditor;

namespace MSLib
{
    public class DebugCreateTemplatePrefabWindow : EditorWindow
    {
        private DebugTaskManager _debugTaskManager = new DebugTaskManager();

        [MenuItem("Tools/Debug/DebugCreateTemplatePrefabWindow")]
        static void Initialize()
        {
            var window =
                (DebugCreateTemplatePrefabWindow)EditorWindow.GetWindow(typeof(DebugCreateTemplatePrefabWindow));
            window.Show();
        }

        private void OnGUI()
        {
            _debugTaskManager.Draw();
        }

        private void OnEnable()
        {
            _debugTaskManager.AddTask("Template Prefabs", new DebugCreateTemplatePrefabTask());

            _debugTaskManager.Init();
        }

        private void OnDisable()
        {
            _debugTaskManager.UnInit();
        }
    }
}