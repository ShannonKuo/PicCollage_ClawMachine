using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class game : MonoBehaviour {
	public static game instance;
	private int stage = 0;
	private int previousStage = -1;
    public GameObject stage1;
	public GameObject stage2;
	public GameObject stage3;
	public GameObject stage4;
	public GameObject stage5;
	private List<GameObject> toyList = new List<GameObject>();
    private Dictionary<string, int> dictionaryLockName;
    private Color colorOfMachine;
	void Awake(){
		if (instance == null){
			instance = this;
		}
		//add the name here if adding animals
		dictionaryLockName = new Dictionary<string, int>();
        dictionaryLockName.Add("duck", 0);
        dictionaryLockName.Add("penguin", 1);
        dictionaryLockName.Add("sheep", 2);

	}

	// Update is called once per frame
	void Update () {
        if (stage != previousStage){
			previousStage = stage;
			OnStageChange(stage);
		}	
	}
    private void OnStageChange(int nextStage){
		switch(nextStage){
			case 0:
			    //initialize
				stage2.SetActive(true);
				resetGame();
				stage1.SetActive(false);
				stage2.SetActive(false);
				stage3.SetActive(false);
				stage4.SetActive(false);
				stage5.SetActive(false);
				setStage(1);
				Debug.Log("debug: move to game stage 1");
				break;
			case 1:
			    //home page, press start button
				stage1.SetActive(true);
				break;
			case 2:
			    //tap to place the claw machine
			    //move the claw
				Debug.Log("debug: at game stage 2");
				stage1.SetActive(false);
				stage2.SetActive(true);
				stage3.SetActive(false);
				stage4.SetActive(false);
			    break;
			case 3:
			    //get item: winning!!!
				stage2.SetActive(false);
				stage3.SetActive(true);
				catchToy.instance.displayToy(toyList[toyList.Count-1]);
			    break;
			case 4:
			    //collection
				stage3.SetActive(false);
				stage4.SetActive(true);
				collection.instance.displayCollection(); 
				break;
			case 5:
			    //take photo
				stage3.SetActive(false);
				stage4.SetActive(false);
				stage5.SetActive(true);
				takePhoto.instance.displayToy();
				break;
			
		}
	}
	public void setStage(int s){
		stage = s;
	}
	public int getStage(){
		return stage;
	}
	public void resetGame(){
		clawManager.instance.setClawStage(0);
	}
	public void collectToy(GameObject toy){
		toy.GetComponent<Rigidbody>().useGravity = false;
		toy.GetComponent<Rigidbody>().isKinematic = true;
		toy.GetComponent<SphereCollider>().enabled = false;
        toyList.Add(toy);
	}
	public GameObject getLastToy(){
		return toyList[toyList.Count -1 ];
	}
	public List<GameObject> getToyList(){
		return toyList;
	}
	public Dictionary<string, int> getDictionaryLockName(){
		return dictionaryLockName;
	}
	public void setColorOfMachine(int c){
		if (c == 1) colorOfMachine = Color.red;
		else if (c == 2) colorOfMachine = Color.blue;
	}
	public Color getColorOfMachine(){
		return colorOfMachine;
	}
}