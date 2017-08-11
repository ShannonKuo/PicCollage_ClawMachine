using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clawManager : MonoBehaviour {
	public static clawManager instance;
	
	public GameObject catcher;
	public GameObject catcher_base;
	public GameObject catcher_parent;
	public GameObject catcher_body;
	public GameObject catcher_1;
	public GameObject catcher_2;
	public GameObject catcher_3;
	//public GameObject catcher_4;
	public GameObject catcher_body_position1;
	public GameObject catcher_base_position;
	public GameObject wallLeft;
	public GameObject wallFront;
	public GameObject machineTop;
	public GameObject machineBottom;
	public GameObject toyParent;

	private Vector3 wallPosLeft;
	private Vector3 wallPosFront;
    private Vector3 initCatcherParentPos;


	private int clawStage = 0;
	private float speed = 0.0005f;
	private float rotate = 35;
	private float borderWall = 0.008f;
	private float borderTop = 0.01f;
	private float borderBottom = 0.012f;
	private float pressDepth = 0.001f;
	private float timer = 0;
	private float angle = 0;
	public int touchFront = 0;
	public int touchLeft = 0;
	
	// Use this for initialization
	void Awake () {
		wallPosLeft = wallLeft.transform.position;
		wallPosFront = wallFront.transform.position;
		initCatcherParentPos = catcher_parent.transform.position;
		
        if (instance == null){
			instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		var x = catcher_base.transform.position.x;
	    var y = catcher_base.transform.position.y;
		var z = catcher_base.transform.position.z;
        var catcherX = catcher.transform.position.x;
	    var catcherY = catcher.transform.position.y;  
	    var catcherZ = catcher.transform.position.z;

		switch(clawStage){
			case 0:
			    //initialize
				scale.instance.resetScale();
				speed = 0.0005f;
				borderWall = 0.008f;
				borderTop = 0.01f;
				borderBottom = 0.02f;
				pressDepth = 0.002f;
				angle = 0;
				clawStage = 1;
				catcher_base.transform.position = catcher_base_position.transform.position;
				Debug.Log("debug: Move to stage 1");
				break;
			case 1:
			    //pressing buttom to control the claw
				break;
		    case 2:
			    //press done and the claw goes down
		 		//test
				y = y - speed;
				catcher_base.transform.position = new Vector3(x, y, z);
				if (catcher_body.transform.position.y  <= machineBottom.transform.position.y + borderBottom){
				    clawStage += 1;	
					Debug.Log("debug: Move to stage 3");
				}
				break;
            case 3:
			    //catch item
				if (angle < rotate) {
					angle += Time.deltaTime * 25;
					catcher_1.transform.Rotate(0, 0, Time.deltaTime * 25);
					catcher_2.transform.Rotate(0, 0, Time.deltaTime * 25);
					catcher_3.transform.Rotate(0, 0, Time.deltaTime * 25);
				}
				else {
					clawStage = 4;
					angle = 0; 
					Debug.Log("debug: Move to stage 4");
				}
				break;
			case 4:
			    //claw goes up
				y = y + speed;
				catcher_base.transform.position = new Vector3(x, y, z);
	
				if (catcher_body.transform.position.y >= machineTop.transform.position.y - borderTop){
					clawStage += 1;
				}
				break;
		    case 5:
			    //move back to the initial position
		
				if (catcher_base.transform.position.x >= wallLeft.transform.position.x + borderWall) {
				    catcher_base.transform.position = new Vector3 (x - speed, y, z);
				}
				else if (catcher_base.transform.position.z >= wallFront.transform.position.z + borderWall) {  
				    catcher_base.transform.position = new Vector3 (x, y, z - speed);	
				}
				else if (timer < 1f) {
					timer += Time.deltaTime;
				}
				else if (angle < rotate) {
					angle += Time.deltaTime * 26;
					catcher_1.transform.Rotate(0, 0, -Time.deltaTime * 26);
					catcher_2.transform.Rotate(0, 0, -Time.deltaTime * 26);
					catcher_3.transform.Rotate(0, 0, -Time.deltaTime * 26);
				}
				else {
					clawStage = 1;
					angle = 0;
					timer = 0;
					Debug.Log("debug: Move to stage 0");						 
				}
				break;
			default:
                break;
		}
	}
	public void setClawStage(int s){
        clawStage = s;
	}
	public int getClawStage(){
        return clawStage;
	}
	public float getSpeed(){
		return speed;
	}
	public float getBorderWall(){
		return borderWall;
	}
	public float getPressDepth(){
		return pressDepth;
	}
	public void scaleMachine(float scaleFactor){
		speed = speed * scaleFactor;
		borderWall = borderWall * scaleFactor;
		borderTop = borderTop * scaleFactor;
		borderBottom = borderBottom * scaleFactor;
		pressDepth = pressDepth * scaleFactor;
        
	}

}
