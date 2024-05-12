namespace MSLib
{
    public sealed class EditorWindowNullObjectTask : IEditorWindowTask
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