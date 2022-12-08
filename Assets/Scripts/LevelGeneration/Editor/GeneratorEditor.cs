using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelGenerator))]
public class GeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelGenerator lg = (LevelGenerator)target;

        if( GUILayout.Button("Generate") )
        {
            lg.GenerateLevel();
        }

        if( GUILayout.Button("Clear") )
        {
            lg.ClearLevel();
        }
    }
}
