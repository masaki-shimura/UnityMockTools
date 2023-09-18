using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSLib
{
    public interface IDebugTask
    {
        public bool IsFoldout { get; set; }
        
        void Init();
        void UnInit();
        void Update();
        void Draw();
        
        void Execution();

        string GetOverviewText();
    }
}