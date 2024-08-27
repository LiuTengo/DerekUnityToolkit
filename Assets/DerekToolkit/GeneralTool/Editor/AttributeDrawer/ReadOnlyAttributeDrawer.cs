using DerekToolkit.CustomAttribute;
using UnityEditor;
using UnityEngine;

namespace DerekCustomAttributeDrawer
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ReadOnlyAttribute readOnlyAttribute = (ReadOnlyAttribute)attribute;
            EditorGUI.BeginDisabledGroup(readOnlyAttribute.isReadonly);
            EditorGUI.PropertyField(position, property, label);
            if(readOnlyAttribute.isReadonly)
                EditorGUI.EndDisabledGroup();
        }
    }
}


