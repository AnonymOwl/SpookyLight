using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class ObjectBuilderEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		MapGenerator MGScript = (MapGenerator)target;
		if(GUILayout.Button("Generate Map"))
		{
			MGScript.Generate();
		}
	}
}