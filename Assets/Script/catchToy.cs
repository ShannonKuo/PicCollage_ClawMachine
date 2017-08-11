using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchToy : MonoBehaviour {
    //private GameObject toy;
	public static catchToy instance;
	public GameObject previousToy;
	private Time timer;
	// Use this for initialization
	void Awake(){
        if (instance == null){
			instance = this;
		}
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void displayToy(GameObject toy){
	    if (previousToy != null){
			previousToy.transform.localPosition = new Vector3(-270, 1000, -1100);
		}
		//toy.GetComponent<Rigidbody>().useGravity = false;
		//toy.GetComponent<Rigidbody>().isKinematic = true;
		Debug.Log("Set position");
       // StartCoroutine(sleep());
		toy.transform.parent = GameObject.Find("ToyCanvas").transform;
		toy.transform.localPosition = new Vector3(-270, -1050, -1100);
		//Debug.Log(toy.transform.localPosition.y);
		//toy.transform.position = new Vector3(-270, -1050, -1100);
		toy.transform.localScale = new Vector3(5f, 5f, 5f);
		toy.transform.rotation = Quaternion.Euler(0, 180, 0);
	    previousToy = toy;
	}
	private void sleep2(){
		// if (timer < 1){
		// 	timer += Time.time;
		// }
	}
	IEnumerator sleep() {
		yield return new WaitForSeconds(10);
	}
}
