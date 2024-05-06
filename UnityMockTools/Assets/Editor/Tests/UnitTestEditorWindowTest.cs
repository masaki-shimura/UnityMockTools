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
    }
}