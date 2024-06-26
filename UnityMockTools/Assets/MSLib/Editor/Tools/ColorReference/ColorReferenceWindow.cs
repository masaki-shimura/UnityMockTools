using UnityEditor;

namespace MSLib.Editor.Tools.ColorReference
{
    public class ColorReferenceWindow : EditorWindow
    {
        private EditorWindowTaskManager _editorWindowTaskManager = new EditorWindowTaskManager();

        [MenuItem("Tools/ColorReferenceWindow")]
        static void Initialize()
        {
            var window =
                (ColorReferenceWindow)EditorWindow.GetWindow(typeof(ColorReferenceWindow));
            window.Show();
        }

        private void OnGUI()
        {
            _editorWindowTaskManager.Draw();
        }

        private void OnEnable()
        {
            _editorWindowTaskManager.AddTask("Color Reference", new ColorReferenceTask());

            _editorWindowTaskManager.Init();
        }

        private void OnDisable()
        {
            _editorWindowTaskManager.UnInit();
        }
    }
}