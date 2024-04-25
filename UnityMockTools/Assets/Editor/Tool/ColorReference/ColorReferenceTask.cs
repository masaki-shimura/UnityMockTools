using System.Collections.Generic;
using System.Drawing;
using UnityEditor;

namespace MSLib
{
    public sealed class ColorReferenceTask : IDebugTask
    {
        public bool IsFoldout { get; set; }
        private const string OverviewText = "リファレンス用のカラー情報を保持します";
        private const string HeaderText = "リファレンス カラー";

        private static List<ColorReference> _colorReferences = new List<ColorReference>(5)
        {
            new(Color.White, "初期カラー1"),
            new(Color.Aqua, "初期カラー2"),
            new(Color.Aquamarine, "初期カラー3"),
        };

        public void Init()
        {
        }

        public void UnInit()
        {
        }

        public void Update()
        {
        }

        public void Draw()
        {
            EditorGUILayout.LabelField(HeaderText);
        }

        public void Execution()
        {
        }

        public string GetOverviewText()
        {
            return OverviewText;
        }
    }
}