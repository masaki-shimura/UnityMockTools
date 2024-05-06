namespace MSLib
{
    public interface IEditorWindowTask
    {
        public bool IsFoldout { get; set; }

        void Init();
        void UnInit();
        void Update();
        void Draw();

        void Execution();

        string GetOverviewText();
    }
}