using System;
using UnityEngine;

namespace MSLib
{
    [Serializable]
    public sealed class ColorReference
    {
        public Color Color { get; private set; }
        public string LabelName { get; set; } = "NONE";
        
        public ColorReference(Color color,string labelName)
        {
            this.Color = color;
            this.LabelName = labelName;
        }
    }
}