using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win : MonoBehaviour {
    private int cnt = 5;
	private Dictionary<string, int> dictionaryLockName;
	private bool catchToy = false;
	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision other){
		dictionaryLockName = game.instance.getDictionaryLockName();
		foreach (KeyValuePair<string, int> pair in dictionaryLockName){
			Debug.Log(pair.Key);
        	if (other.gameObject.CompareTag(pair.Key)){
				catchToy = true;
			}
        }
		if (catchToy) {
			game.instance.collectToy(other.gameObject);
			game.instance.setStage(3);
			Debug.Log ("win");
			catchToy = false;
		}
	}
	//for debug usage
	public void testWin(){
		GameObject toy;
		toy = GameObject.Find("LOVEDUCK (" + cnt + ")");
		cnt += 1;
		game.instance.collectToy(toy);
		game.instance.setStage(3);
		Debug.Log ("win");
	}
}
