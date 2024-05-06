using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

namespace MSLib
{
    public sealed class UnitTestEditorModel
    {
        private readonly string[] _categoryNameList = null;
        public IReadOnlyCollection<string> CategoryNameList => _categoryNameList;

        private TestRunnerApi _testRunnerApi = null;

        public UnitTestEditorModel()
        {
            _categoryNameList = GetAllTestCategoryName();
            Assert.IsNotNull(_categoryNameList, "カテゴリ属性が取得出来ませんでした。NUnitでカテゴリ属性が使われていない可能性があります。");
            _testRunnerApi = ScriptableObject.CreateInstance<TestRunnerApi>();
            _testRunnerApi.RegisterCallbacks(new UnitTestEditorTestExecutionCallback(
                (testName) => { EditorUtility.DisplayDialog("テスト結果", $"テストに失敗しました。:{testName}", "ok"); }));
        }

        /// <summary>
        /// 特定の名前空間にあるNUnitのカテゴリで定義した名前を取得する
        /// </summary>
        /// <returns>カテゴリの名前配列</returns>
        private string[] GetAllTestCategoryName()
        {
            var assembly = Assembly.Load("Assembly-CSharp-Editor");
            Assert.IsNotNull(assembly, "テストカテゴリを参照する為のアセンブリ取得に失敗しました");

            //アセンブリからテスト用のカテゴリ属性の名前を取得
            var categoryNames = assembly
                .GetTypes()
                .Where(type => type.IsClass && type.Namespace == "MSLib")
                .SelectMany(GetCategoryForType)
                .Distinct() //重複を削除
                .ToArray();

            return categoryNames;
        }

        /// <summary>
        /// type情報からカテゴリの名前配列を取得する
        /// </summary>
        /// <param name="type">カテゴリを参照したいtypeオブジェクト</param>
        /// <returns>カテゴリの名前配列</returns>
        private IEnumerable<string> GetCategoryForType(Type type)
        {
            //テストメソッドがあれば全て取得
            var testMethodList = type.GetMethods()
                .Where(info => info.GetCustomAttributes(typeof(TestAttribute), false).Any());

            //テストメソッドからカテゴリ属性の物を抽出し名前を取得
            var categoryNameList = testMethodList
                .SelectMany(info => info.GetCustomAttributes<CategoryAttribute>(false)
                    .Select(attribute => attribute.Name));

            return categoryNameList;
        }

        public void RunEditTest()
        {
            var filter = new Filter
            {
                testMode = TestMode.EditMode,
                testNames = null,
                groupNames = null,
                categoryNames = null,
                assemblyNames = null,
                targetPlatform = null,
            };

            _testRunnerApi.Execute(new ExecutionSettings(filter));
        }

        public void RunEditTest(string[] categoryNameList)
        {
            _testRunnerApi.Execute(new ExecutionSettings(new Filter()
            {
                testMode = TestMode.EditMode,
                categoryNames = categoryNameList
            }));
        }
    }
}