using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collection : MonoBehaviour {
    public static collection instance;
	private List<GameObject> toyList;
	private List<GameObject> lockList;
    private Dictionary<string, int> dictionaryLockName;
	private int borderX = 33;
	private int borderY = 40;
	private int lockBorder = 600;

	private int numCol = 4;
	private int numRow = 4;
	void Awake() {
        if (instance == null){
			instance = this;
		}
		dictionaryLockName = game.instance.getDictionaryLockName();
		lockList = new List<GameObject>();
		foreach (KeyValuePair<string, int> pair in dictionaryLockName){
        	GameObject obj = GameObject.Find(pair.Key);
			lockList.Add(obj);
        }
	    //set the collection page
		for (int i = 0; i < numRow; i++){
			for (int j = 0; j < numCol; j++){
				int id = i * numRow + j;
				lockList[id].transform.parent = GameObject.Find("CollectionCanvas").transform;
				lockList[id].transform.localPosition = new Vector3(-900 + lockBorder * j, 1200 - lockBorder * i, 1600);
				lockList[id].transform.localScale = new Vector3(5f, 5f, 5f);
			}
		}
	}
	//set the position of the toy;
	public void displayCollection() {
        toyList = game.instance.getToyList();
		foreach (var toy in toyList){
			var toyName = toy.tag;
			int [] pos = getToyPosition(toyName);
			toy.transform.parent = GameObject.Find("CollectionCanvas").transform;
			toy.transform.localPosition = new Vector3(-50 + borderX * pos[0], 50 - borderY * pos[1], -1600);
			toy.transform.localScale = new Vector3(3f, 3f, 3f);
			toy.transform.rotation = Quaternion.Euler(0, 180, 0);
			lockList[pos[0] + numRow * pos[1]].SetActive(false);
		}
	}
	//return which col & row the toy should be placed
	public int[] getToyPosition (string toyName){
		int [] ans = new int [2];
		ans[0] = 0;
		ans[1] = 0;
		if (dictionaryLockName.ContainsKey(toyName)){
            int value = dictionaryLockName[toyName];
			ans[0] = value % numRow;  //which col
			ans[1] = value / numCol;  //which row
        }
		return ans;
	}
}
