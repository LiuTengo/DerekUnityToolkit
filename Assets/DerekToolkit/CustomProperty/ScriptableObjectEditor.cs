using UnityEditor;
using UnityEngine;

namespace DerekToolkit.CustomProperty
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ScriptableObject),true)]
    public class ScriptableObjectEditor : Editor
    {
    }
}
