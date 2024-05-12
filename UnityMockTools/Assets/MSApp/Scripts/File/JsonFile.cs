using System;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions;

namespace MSApp.Scripts.File
{
    public sealed class JsonFile<T> : IFile
    {
        public void Save(FilePath path, FileText fileText)
        {
            var streamWriter = new StreamWriter(path.FullPath);
            streamWriter.Write(fileText.Text);
            streamWriter.Close();
        }

        public FileText Load(FilePath path)
        {
            Assert.IsTrue(path.IsExist(), $"ファイルが存在しません{path.FullPath}");

            var streamWriter = new StreamReader(path.FullPath);
            var fileText = new FileText(streamWriter.ReadToEnd());
            streamWriter.Close();

            return fileText;
        }

        /// <summary>
        /// JsonTextに変換します
        /// </summary>
        /// <param name="data">MonoBehaviour、ScriptableObject 、Serializable のデータを入れてください</param>
        /// <returns></returns>
        public FileText ConvertToJson(T data)
        {
            //Note:is Serializable で検知する事が出来ない為「IsDefined」でチェック
            //※IsDefined:派生クラス先でオーバーライドされている属性を調べる時に使用
            Assert.IsTrue(
                data is MonoBehaviour ||
                data is ScriptableObject ||
                data.GetType().IsDefined(typeof(SerializableAttribute), true),
                "MonoBehaviour、ScriptableObject 、Serializable のデータを入れてください");

            var fileText = new FileText(JsonUtility.ToJson(data));
            return fileText;
        }

        /// <summary>
        /// Jsonテキストからオブジェクトを生成します
        /// </summary>
        public T LoadObject(string jsonText)
        {
            Assert.IsNotNull(jsonText);
            var createObject = JsonUtility.FromJson<T>(jsonText);
            return createObject;
        }
    }
}