using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideMachineBottom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision other)
	{
	
	    /*Debug.Log("debug: oncollisionenter" + other);

		if (game.instance.getStage() == 2) {		
			//Debug.Log("debug: collision other: " + other.gameObject.tag);
			//if (other.gameObject.CompareTag("machine_bottom") || other.gameObject.CompareTag("toy")) {
   	        Debug.Log("debug: collide bottom");
			game.instance.setStage(3);
			Debug.Log("debug: Move to stage 3");
			//gameObject.GetComponent<Rigidbody>().isKinematic = true;
		   
			//}
		}*/
	}
}
