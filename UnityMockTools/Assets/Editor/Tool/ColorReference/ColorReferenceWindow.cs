using UnityEditor;

namespace MSLib
{
    public class ColorReferenceWindow : EditorWindow
    {
        private DebugTaskManager _debugTaskManager = new DebugTaskManager();
        
        [MenuItem("Tools/Color/ColorReferenceWindow")]
        static void Initialize()
        {
            var window =
                (ColorReferenceWindow)EditorWindow.GetWindow(typeof(ColorReferenceWindow));
            window.Show();
        }
        
        private void OnGUI()
        {
            _debugTaskManager.Draw();
        }

        private void OnEnable()
        {
            _debugTaskManager.AddTask("Color Reference", new ColorReferenceTask());

            _debugTaskManager.Init();
        }

        private void OnDisable()
        {
            _debugTaskManager.UnInit();
        }
    }
}