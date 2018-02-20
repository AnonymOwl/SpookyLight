using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LevelItemData {

	public int Number;

	public string Name;

	public string Description;

	public TextAsset mapData;

	public Image Picture;
}

public class LevelMenu : MonoBehaviour {

	public List<LevelItemData> LevelList;

	public GameObject LevelItemPrefab;

	private Transform ListContainer;

	private ToggleGroup LevelToggleGroup;

	void Start () {
		ListContainer = GameObject.Find("LevelList").transform.GetChild(0).Find("Content");
		LevelToggleGroup = ListContainer.GetComponent<ToggleGroup>();
		Populate();
	}
	
	void Update () {
		
	}

	void Populate() {
		GameObject newItem;
		bool isFirst = true;
		foreach (LevelItemData item in LevelList) {
			newItem = (GameObject)Instantiate(LevelItemPrefab, ListContainer);
			newItem.GetComponent<Toggle>().group = LevelToggleGroup;
			//Toggle is on by default : turn it off for everything except first level
			if (!isFirst)
				newItem.GetComponent<Toggle>().isOn = false;
			newItem.GetComponent<LevelItem>().data = item;
			newItem.transform.Find("Label").GetComponent<Text>().text = item.Name;

			isFirst = false;
		}
	}
}
