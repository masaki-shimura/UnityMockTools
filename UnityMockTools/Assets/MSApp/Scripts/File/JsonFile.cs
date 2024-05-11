using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace MSApp.Scripts.File
{
    public sealed class JsonFile<T> : IFile
    {
        /// <summary>
        /// JsonTextに変換します
        /// </summary>
        /// <param name="data">MonoBehaviour、ScriptableObject 、Serializable のデータを入れてください</param>
        /// <returns></returns>
        public string ConvertToJson(T data)
        {
            //Note:is Serializable で検知する事が出来ない為「IsDefined」でチェック
            //※IsDefined:派生クラス先でオーバーライドされている属性を調べる時に使用
            Assert.IsTrue(
                data is MonoBehaviour ||
                data is ScriptableObject ||
                data.GetType().IsDefined(typeof(SerializableAttribute), true),
                "MonoBehaviour、ScriptableObject 、Serializable のデータを入れてください");
            return JsonUtility.ToJson(data);
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