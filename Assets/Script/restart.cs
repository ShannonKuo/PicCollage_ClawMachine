using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class restart : MonoBehaviour {
    private Button btn;
	// Use this for initialization
	void Start () {
		Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
	}
	void Awake(){

	}
	// Update is called once per frame
	void Update () {
		
	}
	private void TaskOnClick(){
		Debug.Log("reset");
		scale.instance.resetScale();
		//game.instance.setStage(0);
		clawManager.instance.setClawStage(0);
	}
}
