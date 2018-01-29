using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class GroundTile : Tile {
	public GroundType Type;

#if UNITY_EDITOR
	[MenuItem("Assets/Create/GroundTile")]
	public static void CreateGroundTile() {
		string path = EditorUtility.SaveFilePanelInProject("Save Ground Tile", "New Ground Tile", extension: "Asset", message: "Save Ground Tile", path: "Assets");
		if (path == "") {
			return;
		}
		AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<GroundTile>(), path);
	}
#endif
}
