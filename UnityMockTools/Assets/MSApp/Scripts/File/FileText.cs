namespace MSApp.Scripts.File
{
    public sealed class FileText
    {
        public string Text { get; private set; } = "";

        public FileText(string text)
        {
            Text = text;
        }
    }
}