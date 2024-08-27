using System;
using UnityEngine;

namespace DerekToolkit.BuffSystem.Base
{
    [Serializable]
    public class BuffData
    {
        public int id;
        public string buffName;
        public string buffDescription;
        public Sprite icon;
        public int maxStack;
        public int priority;
        
        public BuffData() { }
    }
}
