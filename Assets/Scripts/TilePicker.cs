using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class TilePicker : MonoBehaviour {

	public Grid BaseGrid;
	public Tilemap Ground;
	public Text TileInfo;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3Int position = GetGridPoint();
		
		// Display Tile Information
		GroundTile currentTile = Ground.GetTile<GroundTile>(position);
		UpdateDescription(currentTile);

		// Convert Tile
		if(Input.GetMouseButtonDown(0)) {
			ToggleGround(position, currentTile);
		}
	}

	Vector3Int GetGridPoint() {
		Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		worldPoint.z = 0;
		return BaseGrid.WorldToCell(worldPoint);
	}
	void ToggleGround(Vector3Int position, GroundTile tile) {
		string groundPath = "";
		if(tile.Type == GroundType.Normal) {
			groundPath = "Tiles/Ground_Grass";
		} else {
			groundPath = "Tiles/Ground_Normal";
		}
		Ground.SetTile(position, Resources.Load<GroundTile>(groundPath));
	}

	void UpdateDescription(GroundTile tile = null) {
		if(tile == null) {
			TileInfo.text = "";
			return;
		}

		string description = "";
		switch(tile.Type) {
			case GroundType.Normal:
				description = "普通的地板";
				break;
			case GroundType.Grass:
				description = "長草的草地";
				break;
		}

		TileInfo.text = description;
	}
}
