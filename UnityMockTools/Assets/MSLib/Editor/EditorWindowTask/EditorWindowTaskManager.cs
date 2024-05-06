using System.Collections.Generic;
using UnityEditor;

namespace MSLib
{
    public sealed class EditorWindowTaskManager
    {
        private Dictionary<string, IEditorWindowTask> debugTaskList = new Dictionary<string, IEditorWindowTask>();

        public void Init()
        {
            foreach (var debugTask in debugTaskList)
            {
                debugTask.Value.Init();
            }
        }

        public void UnInit()
        {
            foreach (var debugTask in debugTaskList)
            {
                debugTask.Value.UnInit();
            }

            debugTaskList.Clear();
            debugTaskList = null;
        }

        public void Update()
        {
            foreach (var debugTask in debugTaskList)
            {
                debugTask.Value.Update();
            }
        }

        public void Draw()
        {
            foreach (var debugTask in debugTaskList)
            {
                var debugTaskValue = debugTask.Value;
                debugTaskValue.IsFoldout =
                    EditorGUILayout.BeginFoldoutHeaderGroup(debugTaskValue.IsFoldout, debugTask.Key);

                if (debugTaskValue.IsFoldout)
                {
                    EditorGUILayout.HelpBox(debugTaskValue.GetOverviewText(), MessageType.Info, true);
                    debugTaskValue.Draw();
                }

                EditorGUILayout.EndFoldoutHeaderGroup();
            }
        }

        public void ExecutionAllTask()
        {
            foreach (var debugTask in debugTaskList)
            {
                debugTask.Value.Execution();
            }
        }

        public void AddTask(string labelName, IEditorWindowTask editorWindowTask)
        {
            debugTaskList.Add(labelName, editorWindowTask);
        }
    }
}