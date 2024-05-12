using UnityEngine;

namespace MSApp.Scripts.File
{
    public sealed class FilePath
    {
        public const string ExtensionJson = "json";

        public string FullPath { get; private set; } = "";
        public string FileExtension { get; private set; } = "";

        public FilePath(string fileName, string extension, string path)
        {
            FileExtension = extension;
            FullPath = $"{Application.dataPath}{path}{fileName}.{FileExtension}";
        }

        public bool IsExist()
        {
            return System.IO.File.Exists(FullPath);
        }
    }
}