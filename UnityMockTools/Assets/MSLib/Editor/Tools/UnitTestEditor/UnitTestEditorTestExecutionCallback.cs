using System;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

namespace MSLib.Editor.Tools.UnitTestEditor
{
    public sealed class UnitTestEditorTestExecutionCallback : ICallbacks
    {
        private Action<string> _onFaild = null;

        public UnitTestEditorTestExecutionCallback(Action<string> onFaild)
        {
            _onFaild = onFaild;
        }

        /// <summary>
        /// テスト実行の開始時に呼び出される
        /// </summary>
        /// <param name="testsToRun"></param>
        public void RunStarted(ITestAdaptor testsToRun)
        {
        }

        /// <summary>
        /// テスト実行の終了時に呼び出される
        /// </summary>
        /// <param name="result"></param>
        public void RunFinished(ITestResultAdaptor result)
        {
        }

        /// <summary>
        /// テストツリーの個々のノードが実行された時に呼び出される
        /// </summary>
        /// <param name="test"></param>
        public void TestStarted(ITestAdaptor test)
        {
        }

        /// <summary>
        /// テストツリーの個々のノードの実行が呼び出された時に呼び出される
        /// </summary>
        /// <param name="result"></param>
        public void TestFinished(ITestResultAdaptor result)
        {
            if (!result.HasChildren && result.ResultState != "Passed")
            {
                Debug.Log(string.Format("Test {0} {1}", result.Test.Name, result.ResultState));
                _onFaild?.Invoke(result.Test.Name);
            }
        }
    }
}