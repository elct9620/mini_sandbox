using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {
	protected Dictionary<Vector3Int, TileInfo> TileData;

	public void ChangeGround(Vector3Int position, GroundType type) {
		if(TileData.ContainsKey(position)) {
			TileInfo info;
			TileData.TryGetValue(position, out info);
			info.GroundType = type;
		} else {
			TileInfo info = new TileInfo();
			info.GroundType = type;
			TileData.Add(position, info);
		}
	}
}
