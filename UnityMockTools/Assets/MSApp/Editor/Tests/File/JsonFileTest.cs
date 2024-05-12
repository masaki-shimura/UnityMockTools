using System;
using MSApp.Scripts.File;
using NUnit.Framework;
using UnityEngine;

namespace MSApp.Editor.Tests.File
{
    public class JsonFileTest
    {
        [Test]
        public void ConvertToJsonTest()
        {
            var jsonFile = new JsonFile<DummyData>();
            var dummyData = new DummyData("DummyTextです", -1);

            var fileText = jsonFile.ConvertToJson(dummyData);

            Debug.Log($"jsonText:{jsonText}");
            Assert.IsNotNull(jsonText);
            Assert.IsNotEmpty(jsonText);
            Debug.Log($"jsonText:{fileText.Text}");
            Assert.IsNotNull(fileText.Text);
            Assert.IsNotEmpty(fileText.Text);
        }

        [Test]
        public void LoadObjectTest()
        {
            var jsonFile = new JsonFile<DummyData>();

            var inputText = "{\"dummyText\":\"Dummy情報です\",\"dummyIndex\":-1}";
            var dummyData = jsonFile.LoadObject(inputText);

            Debug.Log($"text:{dummyData.dummyText} / index:{dummyData.dummyIndex}");
        }
    }

    [Serializable]
    public class DummyData
    {
        public string dummyText = "Dummy情報です";
        public int dummyIndex = 1;

        public DummyData(string dummyText, int dummyIndex)
        {
            this.dummyIndex = dummyIndex;
            this.dummyIndex = dummyIndex;
        }
    }
}