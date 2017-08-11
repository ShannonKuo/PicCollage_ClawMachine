using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonControllerRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {
    public GameObject catcher;
	private Button btn;
    public bool Pressed = false;
	public bool Done = false;
	public bool goDown = false;
	public bool goUp = false;
	private float speed = 0.002f;

	//public Text debug;
	void Awake(){
	
		
	}
	void Start()
    {
        btn = GetComponent<Button>();
        
    }
	
	// Update is called once per frame
	void Update () {
		var x = catcher.transform.position.x;
	  	var y = catcher.transform.position.y;
		var z = catcher.transform.position.z;
		if (Pressed == true && game.instance.getStage() == 1){
	
			//Debug.Log("click");
			/*if (CompareTag("left") == true) {
       	   		 x = x - speed;
			     Debug.Log("debug: left");
				 //debug.text = "left";
			}
			else if (CompareTag("right") == true) {*/
    	   	    x = x + speed;
			   Debug.Log("debug: right");
			   //debug.text = "right";
			/*}	
			else if (CompareTag("forward") == true) {
	   	        z = z + speed;
			   Debug.Log("debug: forward");
			   //debug.text ="forward";
			}
			else if (CompareTag("backward") == true) {
       		    z = z - speed;
			   Debug.Log("debug: backward");
			   //debug.text = "backward";
			}	
			else {
				Debug.Log("debug: other button: " + gameObject.tag);
			}	*/
			catcher.transform.position = new Vector3( x, y, z);
	    }	
		
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
	
		/*if (CompareTag("Done")){
			Done = true;
			game.instance.setStage(2);
			Debug.Log("debug: Move to stage 2");
		}*/
    }
 
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Pressed = true;
		//Debug.Log("Enter");
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        //Pressed = false;
		//Debug.Log("Exit");
    }
 
    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
		
    }
}