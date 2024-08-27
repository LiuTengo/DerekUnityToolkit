using DerekToolkit.BuffSystem.Base;
using UnityEngine;

namespace DerekToolkit.BuffSystem
{
    [CreateAssetMenu( menuName= "DerekToolkit/BuffSystem", fileName = "BuffSO")]
    public class BuffBase : ScriptableObject
    {
        public BuffData buffData = new BuffData();

        
    }
}