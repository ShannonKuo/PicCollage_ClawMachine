using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class takePhoto : MonoBehaviour {
	public static takePhoto instance;

    private bool camAvailable;
	private WebCamTexture backCam;
    private WebCamTexture frontCam;
	private Texture defaltBackground;
	private GameObject toy;
	private List<GameObject> toyList;
	//public RawImage background;
	//public AspectRatioFitter fit;
	void Awake(){
	    if (instance == null){
			instance = this;
		}
	}
	public void displayToy(){
		toy = game.instance.getLastToy();
		toy.transform.parent = GameObject.Find("HitCubeStage5").transform;
		toy.transform.localPosition = new Vector3(0, 0, 0);
		toy.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
	}
    private void Start(){

		/*defaltBackground = background.texture;
		WebCamDevice[] devices = WebCamTexture.devices;
	    if (devices.Length == 0){
			Debug.Log("debug: no camera");
			camAvailable = false;
			return;
		}
		for (int i = 0; i < devices.Length; i++){
			if (!devices[i].isFrontFacing){
				backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
			}
		}
		if (backCam == null){
			Debug.Log("debug: Unable to find back cam");
			return;
		}
		backCam.Play();
		background.texture = backCam;

		camAvailable = true;*/
	}
	private void Update(){
		/*if (!camAvailable){
			return;
		}
		float ratio = (float) backCam.width / (float) backCam.height;
		fit.aspectRatio = ratio;

		float scaleY = backCam.videoVerticallyMirrored ? -1f: 1f;
		background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

		int orient = -backCam.videoRotationAngle;
		background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);*/
	}

	public void screenShot() {
        /*int width = Screen.width;
        int height = Screen.height;
    
        RenderTexture rt = new RenderTexture(width, height, 24);
        m_camera.targetTexture = rt;
        m_camera.Render();
        RenderTexture.active = rt;
        Texture2D screenShot = new Texture2D(width, height, TextureFormat.RGB24, false);

        screenShot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        m_camera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();

        System.IO.File.WriteAllBytes("photo.png", bytes);
        Debug.Log(string.Format("Took screenshot to: {0}", "PradaScreenshotTest.png"));*/
    }
}
