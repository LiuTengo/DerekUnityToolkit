using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DerekToolkit.CustomProperty.Drawer
{
    [CustomPropertyDrawer(typeof(ExpandableScriptableObjectAttribute),true)]
    public class ExpandableScriptableObjectDrawer : PropertyDrawer
    {
        private enum BackgroundStyles
        {
            None,
            HelpBox,
            Darken,
            Lighten
        }

        private static bool SHOW_SCRIPT_FIELD = false;
        private static float INNER_SPACING = 6.0f;
        private static float OUTER_SPACING = 4.0f;

        private static BackgroundStyles BACKGROUND_STYLE = BackgroundStyles.HelpBox;

        private static Color DARKEN_COLOR = new Color(0.0f,0.0f,0.0f,0.2f);
        private static Color LIGHTEN_COLOR = new Color(1.0f,1.0f,1.0f,0.2f);

        private Editor editor = null;
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float totalHeight = 0.0f;

            totalHeight += EditorGUIUtility.singleLineHeight;
            if (!property.objectReferenceValue)
            {return totalHeight;}

            if (!property.isExpanded)
            {return totalHeight;}

            if (!editor)
            {
                Editor.CreateCachedEditor(property.objectReferenceValue,null,ref editor);
            }

            if (!editor)
            {
                return totalHeight;
            }

            SerializedProperty field = editor.serializedObject.GetIterator();

            field.NextVisible(true);
            if (SHOW_SCRIPT_FIELD)
            {
                totalHeight += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            }

            while (field.NextVisible(false))
            {
                totalHeight += EditorGUI.GetPropertyHeight(field,true)+EditorGUIUtility.standardVerticalSpacing;
            }

            totalHeight += INNER_SPACING * 2;
            totalHeight += OUTER_SPACING * 2;
            
            return totalHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Rect fieldRect = new Rect(position);
            fieldRect.height = EditorGUIUtility.singleLineHeight;

            EditorGUI.PropertyField(fieldRect,property,label,true);

            if (!property.objectReferenceValue)
            {
                return;
            }

            property.isExpanded = EditorGUI.Foldout(fieldRect,property.isExpanded,GUIContent.none,true);

            if (!property.isExpanded)
            {
                return;
            }
            
            if(!editor)
            {Editor.CreateCachedEditor(property.objectReferenceValue,null,ref editor);}

            if (!editor)
            { return;}

            List<Rect> propertyRects = new List<Rect>();

            Rect marchingRect = new Rect(fieldRect);
            Rect bodyRect = new Rect(fieldRect);

            bodyRect.xMin += EditorGUI.indentLevel * 14;
            bodyRect.yMin += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing +
                             OUTER_SPACING;

            SerializedProperty field = editor.serializedObject.GetIterator();
            marchingRect.y += INNER_SPACING + OUTER_SPACING;

            if(SHOW_SCRIPT_FIELD)
            {
                propertyRects.Add(marchingRect);
                marchingRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            }
            
            while (field.NextVisible(false))
            {
                marchingRect.y += marchingRect.height + EditorGUIUtility.standardVerticalSpacing;
                marchingRect.height = EditorGUI.GetPropertyHeight(field, true);
                propertyRects.Add(marchingRect);
            }

            marchingRect.y += INNER_SPACING;
            bodyRect.yMax = marchingRect.yMax;

            DrawBackground(bodyRect);

            EditorGUI.indentLevel++;
            int index = 0;
            field = editor.serializedObject.GetIterator();
            field.NextVisible(true);
            
            if (SHOW_SCRIPT_FIELD)
            {
                EditorGUI.BeginDisabledGroup(true);
                EditorGUI.PropertyField(propertyRects[index], field, true);
                EditorGUI.EndDisabledGroup();
                index ++;
            }

            while (field.NextVisible(false))
            {
                try
                {
                    EditorGUI.PropertyField(propertyRects[index], field, true);
                }
                catch(StackOverflowException)
                {
                    field.objectReferenceValue = null;
                    Debug. LogError("Detected self-nesting cauisng a StackOverflowException, avoid using the same"+
                                    "object iside a nested structure.");
                }

                index ++;
            }

            EditorGUI.indentLevel--;
        }

        private void DrawBackground(Rect rect)
        {
            switch (BACKGROUND_STYLE)
            {
                case BackgroundStyles.HelpBox:
                    EditorGUI.HelpBox(rect,"",MessageType.None);
                    break;
                case BackgroundStyles.Darken:
                    EditorGUI.DrawRect(rect,DARKEN_COLOR);
                    break;
                case BackgroundStyles.Lighten:
                    EditorGUI.DrawRect(rect, LIGHTEN_COLOR);
                    break;
            }
        }
    }
}