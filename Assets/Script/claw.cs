using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//didn't use this script

public class claw : MonoBehaviour {
    private bool catchObj = false;
	public static claw instance;

	void Awake () {
		if (instance == null){
			instance = this;
		}
	}

	void OnCollisionEnter(Collision other)
	{
        Debug.Log("collide");
		if (clawManager.instance.getClawStage() == 0) {
            catchObj = false;
		}
		if (clawManager.instance.getClawStage() == 2) {
			Debug.Log("debug: collide Move to stage 3");
			catchObj = true;
		}
		
		else if (clawManager.instance.getClawStage() == 5) {
            Debug.Log("debug: catch toy!!");
			other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
		}
	}
	public bool getCatchObj(){
		return catchObj;
	}
}
