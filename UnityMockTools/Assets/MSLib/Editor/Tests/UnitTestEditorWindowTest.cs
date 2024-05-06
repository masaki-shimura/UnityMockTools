#if ENABLE_UNIT_TEST_EDITOR_WINDOW
using System;
using NUnit.Framework;
using UnityEngine;

namespace MSLib
{
    [TestFixture]
    public class UnitTestEditorWindowTest
    {
        [Test, Category("CategoryTestA")]
        public void CategoryTestA()
        {
            Debug.Log("カテゴリを定義したサンプルメソッド の実行をしました");
        }

        [Test, Category("CategoryTestB")]
        public void CategoryTestB()
        {
            Debug.Log("カテゴリを定義したサンプルメソッド の実行をしました");
        }

        [Test, Category("CategoryTestB"), Ignore("エラー実行確認用")]
        public void ExceptionTest()
        {
            Debug.LogError("ExceptionTestの実行をしました");
            throw new Exception("強制的にエラーを出しました");
        }
    }
}
#endif