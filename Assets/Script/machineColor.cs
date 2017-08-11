using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machineColor : MonoBehaviour {
	public GameObject machine_top;
	// Use this for initialization
	void Start () {
		//machine_top.Color = game.instance.getColorOfMachine();
		//machine_top.GetComponent<Renderer>().material.color = game.instance.getColorOfMachine();
	}
	
	// Update is called once per frame
	void Update () {
		machine_top.GetComponent<Renderer>().material.color = game.instance.getColorOfMachine();
	}
}
