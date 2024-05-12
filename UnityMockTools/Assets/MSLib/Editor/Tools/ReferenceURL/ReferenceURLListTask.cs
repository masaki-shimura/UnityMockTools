namespace MSLib.Editor.Tools.ReferenceURL
{
    public class ReferenceURLListTask : IEditorWindowTask
    {
        public bool IsFoldout { get; set; }

        public void Init()
        {
        }

        public void UnInit()
        {
        }

        public void Update()
        {
        }

        public void Draw()
        {
        }

        public void Execution()
        {
        }

        public string GetOverviewText()
        {
            return this.GetType().Name;
        }
    }
}