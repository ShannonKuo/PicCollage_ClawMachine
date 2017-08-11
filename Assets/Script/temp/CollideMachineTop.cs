using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideMachineTop : MonoBehaviour {
    public GameObject catcher_parent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision other) {
	

		/*if (game.instance.getStage() == 4) {
			
				if (other.gameObject.GetInstanceID() == catcher_parent.GetInstanceID()){
					Debug.Log("debug: collide top");
					Debug.Log("debug: Move to stage 5");
					game.instance.setStage(5);
				}
		}*/
	}
}
