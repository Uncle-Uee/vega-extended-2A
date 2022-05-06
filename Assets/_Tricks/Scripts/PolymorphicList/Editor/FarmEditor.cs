using System;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace Tricks
{
    [CustomEditor(typeof(Farm))]
    public class FarmEditor : Editor
    {
        private Farm _farm;

        private void OnEnable()
        {
            _farm = target as Farm;
        }

        public override void OnInspectorGUI()
        {
            using (EditorGUILayout.VerticalScope verticalScope = new EditorGUILayout.VerticalScope())
            {
                using (EditorGUILayout.HorizontalScope horizontalScope = new EditorGUILayout.HorizontalScope())
                {
                    if (GUILayout.Button("Add Cow"))
                    {
                        _farm.AddCow(true);
                    }

                    if (GUILayout.Button("Add Sheep"))
                    {
                        _farm.AddSheep(true);
                    }

                    if (GUILayout.Button("Add Duck"))
                    {
                        _farm.AddDuck(true);
                    }
                }

                using (EditorGUILayout.HorizontalScope horizontalScope = new EditorGUILayout.HorizontalScope())
                {
                    if (GUILayout.Button("Add Non Poly Cow"))
                    {
                        _farm.AddCow();
                    }

                    if (GUILayout.Button("Add Non Poly Sheep"))
                    {
                        _farm.AddSheep();
                    }

                    if (GUILayout.Button("Add Non Poly Duck"))
                    {
                        _farm.AddDuck();
                    }
                }
            }

            DrawDefaultInspector();
        }
    }
}
#endif