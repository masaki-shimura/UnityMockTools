using System;
using UnityEngine.Serialization;

namespace MSLib.Editor.Tools.ReferenceURL
{
    [Serializable]
    public sealed class ReferenceURL
    {
        [FormerlySerializedAs("Tag")] public string tag = "";
        public string toolTipText = "";
        public string url = "";

        public ReferenceURL(string tag, string toolTipText, string url)
        {
            this.tag = tag;
            this.toolTipText = toolTipText;
            this.url = url;
        }
    }
}