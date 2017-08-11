using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class scale : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{
    private bool Pressed = false;
	public static scale instance;
	public GameObject hitCube;
	public GameObject catcher_parent;
	public GameObject catcher_base;
	public GameObject clawBodyPosition1;
	public GameObject clawBodyPosition2;
	public GameObject catcher_body;
	public GameObject scaleLarge;
	public GameObject scaleSmall;
	private float range = 0.01f;
	private float scaleFactor = 0.03f;
	private float clawBodyPositionY1;
	private float clawBodyPositionY2;
	// Use this for initialization
	void Awake() {
		if (instance == null){
			instance = this;
		}
	}
	// Update is called once per frame
	void Update () {
		clawBodyPositionY1 = clawBodyPosition1.transform.position.y;
		clawBodyPositionY2 = clawBodyPosition2.transform.position.y;
		if (Pressed && clawManager.instance.getClawStage() <= 1){
			var sX = hitCube.transform.localScale.x;
			var sY = hitCube.transform.localScale.y;
			var sZ = hitCube.transform.localScale.z;
			//larger, scale the mass of the claw also
			if (gameObject.GetInstanceID() == scaleLarge.gameObject.GetInstanceID()){
            	clawManager.instance.scaleMachine(1 + scaleFactor);

            	hitCube.transform.localScale += new Vector3(sX * (scaleFactor), sY * (scaleFactor), sZ * (scaleFactor));
				catcher_parent.GetComponent<Rigidbody>().mass *= (1 + scaleFactor);
				range = range * (1 + scaleFactor);

			}
			//smaller, scale the mass of the claw also
			else if (gameObject.GetInstanceID() == scaleSmall.gameObject.GetInstanceID()){
				if (hitCube.transform.localScale.x > 1) {
            		clawManager.instance.scaleMachine(1 - scaleFactor);
            		hitCube.transform.localScale -= new Vector3(sX * (scaleFactor), sY * (scaleFactor), sZ * (scaleFactor));
					catcher_parent.GetComponent<Rigidbody>().mass *= (1 - scaleFactor);
					range = range * (1 - scaleFactor);
				}
			}
			
		}
		//make the clawbody stay between position1 & 2
		if (clawManager.instance.getClawStage() <= 1) {
			if (catcher_body.transform.position.y > clawBodyPositionY1){
				var move = (catcher_body.transform.position.y - clawBodyPositionY1) * 0.01f;
				catcher_base.transform.position = catcher_base.transform.position - new Vector3( 0, move, 0);
				
			}
			if (catcher_body.transform.position.y < clawBodyPositionY2){
				var move = (catcher_body.transform.position.y - clawBodyPositionY2) * 0.01f;
				catcher_base.transform.position = catcher_base.transform.position - new Vector3( 0, move, 0);
				
			}
		}
	}
	public void OnPointerDown(PointerEventData eventData){
        Pressed = true;
    }
 
    public void OnPointerUp(PointerEventData eventData){
        Pressed = false;
    }
	public void resetScale(){
		hitCube.transform.localScale = new Vector3(1,1,1);
		catcher_parent.GetComponent<Rigidbody>().mass = (1.5f);
	}
}
