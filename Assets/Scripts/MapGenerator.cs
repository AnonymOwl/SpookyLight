using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Tile {
	public int tileNb;
	public GameObject prefab;
}

public class MapGenerator : MonoBehaviour {

	//Made as public for debug
	public TextAsset mapDataFile;
	public float tileWidth;
	public float tileHeight;

	public List<Tile> tilePrefabs;

	private LevelItemData levelData;
	private List<List<int>> mapData;

	private Transform levelParent;

	void Start() {
		levelData = ApplicationModel.levelData;
		if (levelData != null)
			mapDataFile = levelData.mapData;

		mapData = GetMap();
		levelParent = GameObject.Find("Level").transform;
		Generate();
	}

	public void Generate()
	{
		float x = 0;
		float z = 0;
		GameObject obj;

		foreach (List<int> line in mapData) {
			x = 0;
			foreach (int tile in line) {
				Tile tileModel = tilePrefabs.Find(t => t.tileNb == tile);
				if (tileModel != null) {
					obj = (GameObject)Instantiate(tileModel.prefab, levelParent);
					obj.transform.position = new Vector3(x, 0, z);
				}
				x += tileWidth;
			}
			z -= tileHeight;
		}
	}

	private List<List<int>> GetMap() {
		List<string> lines;
		List<List<int>> data;

		data = new List<List<int>>();
		lines = mapDataFile.text.Split('\n').ToList();
		foreach (string l in lines) {
			print(l);
			if (l.Contains(","))
				data.Add(l.Split(',').Select(elem => int.Parse(elem)).ToList());
		}
		return data;
	}
}
