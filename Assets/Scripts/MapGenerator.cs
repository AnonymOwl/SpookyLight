using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public Texture2D Map;

	public void Generate()
	{
		if (Map == null) {
			Debug.LogError("No map texture selected.");
			return;
		}
	}
}
