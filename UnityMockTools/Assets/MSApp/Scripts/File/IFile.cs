namespace MSApp.Scripts.File
{
    public interface IFile
    {
        public void Save(FilePath path, FileText fileText);
        public FileText Load(FilePath path);
    }
}