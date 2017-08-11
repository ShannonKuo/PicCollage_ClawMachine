using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class buttonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public GameObject catcher_base;
	public static buttonController instance;
 
    public bool Pressed = false;
	public bool Done = false;
    
	private float speed;// = 0.01f;
	private float borderWall;// = 0.05f;
	private float pressDepth;// = 0.01f;
	private GameObject buttonLeft;
	private GameObject buttonRight;
	private GameObject buttonForward;
	private GameObject buttonBackward;
	private GameObject buttonDone;

	private GameObject realButtonLeft;
	private GameObject realButtonRight;
	private GameObject realButtonForward;
	private GameObject realButtonBackward;
	private GameObject realButtonDone;

    private GameObject wallFront;
	private GameObject wallBack;
	private GameObject wallLeft;
	private GameObject wallRight;
    
	private GameObject claw_base_position;

	private bool pressLeft = false;
	private bool pressRight = false;
	private bool pressForward = false;
	private bool pressBackward = false;
	private bool pressDone = false;
	
	//public Text debug;
	void Awake(){
	    if (instance == null){
			instance = this;
		}
		buttonLeft = GameObject.Find("left");
		buttonRight = GameObject.Find("right");
		buttonBackward = GameObject.Find("backward");
		buttonForward = GameObject.Find("forward");
        buttonDone = GameObject.Find("done");
        
		wallFront = GameObject.Find("wallFront");
		wallBack = GameObject.Find("wallBack");
		wallLeft = GameObject.Find("wallLeft");
		wallRight = GameObject.Find("wallRight");
		
        realButtonLeft = GameObject.Find("polySurface2");
		realButtonRight = GameObject.Find("polySurface3");
		realButtonBackward = GameObject.Find("polySurface1");
		realButtonForward = GameObject.Find("polySurface5");
        realButtonDone = GameObject.Find("polySurface6");

		claw_base_position = GameObject.Find("claw_base_boundary");
		
	}
	void Start()
    {
		speed = clawManager.instance.getSpeed();
		borderWall = clawManager.instance.getBorderWall();
		pressDepth = clawManager.instance.getPressDepth();
    }

   
	
	// Update is called once per frame
	void Update () {
		var x = catcher_base.transform.position.x;
	  	var y = catcher_base.transform.position.y;
		var z = catcher_base.transform.position.z;
        if (clawManager.instance.getClawStage() < 2 ){
			Done = false;
		}

		if (Pressed == true && clawManager.instance.getClawStage() == 1){
	 
			if (gameObject.GetInstanceID() == buttonLeft.gameObject.GetInstanceID() && CheckCollision(1, x, y, z)) {
       	   		 x = x - speed;
				if (pressLeft == false){
				    realButtonLeft.transform.position = realButtonLeft.transform.position + new Vector3(0, -pressDepth, 0);
				    pressLeft = true;
				}
			}
			else if (gameObject.GetInstanceID() == buttonRight.gameObject.GetInstanceID() && CheckCollision(2, x, y, z)) {
    	   	    x = x + speed;
				if (pressRight == false){
				    realButtonRight.transform.position = realButtonRight.transform.position + new Vector3(0, -pressDepth, 0);
				    pressRight = true;
				}
			}	
			else if (gameObject.GetInstanceID() == buttonForward.gameObject.GetInstanceID() && CheckCollision(3, x, y, z)) {
	   	        z = z + speed;
			   	if (pressForward == false){
				    realButtonForward.transform.position = realButtonForward.transform.position + new Vector3(0, -pressDepth, 0);
				    pressForward = true;
				}
			}
			else if (gameObject.GetInstanceID() == buttonBackward.gameObject.GetInstanceID() && CheckCollision(4, x, y, z)) {
       		    z = z - speed;
		      	if (pressBackward == false){
				    realButtonBackward.transform.position = realButtonBackward.transform.position + new Vector3(0, -pressDepth, 0);
				    pressBackward = true;
				}
			}	
			catcher_base.transform.position = new Vector3( x, y, z);
	    }
		//press the real button of the machine
        else {
			if (pressLeft){
				realButtonLeft.transform.position = realButtonLeft.transform.position + new Vector3(0, pressDepth, 0);
				pressLeft = false;
			}
			if (pressRight){
				realButtonRight.transform.position = realButtonRight.transform.position + new Vector3(0, pressDepth, 0);
				pressRight = false;
			}
			if (pressForward){
				realButtonForward.transform.position = realButtonForward.transform.position + new Vector3(0, pressDepth, 0);
				pressForward = false;
			}
			if (pressBackward){
				realButtonBackward.transform.position = realButtonBackward.transform.position + new Vector3(0, pressDepth, 0);
				pressBackward = false;
			}

		}
		
		
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
		if (gameObject.GetInstanceID() == buttonDone.gameObject.GetInstanceID() && Done != true){
			if (catcher_base.transform.position.x < claw_base_position.transform.position.x &&
			    catcher_base.transform.position.z < claw_base_position.transform.position.z){
				return;
			}
			Done = true;
			pressDone = true;
			realButtonDone.transform.position = realButtonDone.transform.position + new Vector3(0, -pressDepth, 0);
			clawManager.instance.setClawStage(2);
			Debug.Log("debug: Move to stage 2");	
		}
    }
 
    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
		if (pressDone){
			realButtonDone.transform.position = realButtonDone.transform.position + new Vector3(0, pressDepth, 0);
			pressDone = false;
		}
    }
    //prevent the claw from moving outside the machine
	private bool CheckCollision(int d, float x, float y, float z) {
		switch(d) {
			case 1:
			    if (x <= wallLeft.transform.position.x + borderWall) {
			        Debug.Log("collide wall");
					return false;
		        }
				break;
			case 2:
		    	if (x >= wallRight.transform.position.x - borderWall){
					Debug.Log("collide wall");
					return false;
				}
				break;
			case 3:
			    if (z >= wallBack.transform.position.z - borderWall){
					Debug.Log("collide wall");
					return false;
				}
				break;
			case 4: 
			    if (z <= wallFront.transform.position.z + borderWall){
					Debug.Log("collide wall");
					return false;
				}
				break;
		}	
		return true;
	}
 
}