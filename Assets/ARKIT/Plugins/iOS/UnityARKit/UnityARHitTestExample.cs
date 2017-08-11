/*using System;
using System.Collections.Generic;
using UnityEngine.UI;
namespace UnityEngine.XR.iOS
{
	public class UnityARHitTestExample : MonoBehaviour
	{
		public Transform m_HitTransform;
		public Text coordinate;
		bool HitTestWithResultType (ARPoint point, ARHitTestResultType resultTypes)
		{
			List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, resultTypes);
			if (hitResults.Count > 0) {
				foreach (var hitResult in hitResults) {
				
					m_HitTransform.position = UnityARMatrixOps.GetPosition (hitResult.worldTransform);
					m_HitTransform.rotation = UnityARMatrixOps.GetRotation (hitResult.worldTransform);
					//Debug.Log (string.Format ("x:{0:0.######} y:{1:0.######} z:{2:0.######}", m_HitTransform.position.x, m_HitTransform.position.y, m_HitTransform.position.z));
					return true;
				}
			}
			return false;
		}

		// Update is called once per frame
		void Update () {
			if (Input.touchCount > 0 && m_HitTransform != null)
			{

				var touch = Input.GetTouch(0);
				if (touch.phase == TouchPhase.Began)
				{

					var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
					//if (screenPosition.x > 10 && screenPosition.y > 10){
					//coordinate.text = "y: " + screenPosition.y.ToString();

					if (screenPosition.y < 0.2){
						Debug.Log("debug: Press Button");
						//return;
					}
					else{
						ARPoint point = new ARPoint {
							x = screenPosition.x,
							y = screenPosition.y
						};
			
						// prioritize reults types
						ARHitTestResultType[] resultTypes = {
							ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, 
							// if you want to use infinite planes use this:
							//ARHitTestResultType.ARHitTestResultTypeExistingPlane,
							ARHitTestResultType.ARHitTestResultTypeHorizontalPlane, 
							ARHitTestResultType.ARHitTestResultTypeFeaturePoint
						}; 

						foreach (ARHitTestResultType resultType in resultTypes)
						{
							if (HitTestWithResultType (point, resultType))
							{
								return;
							}
						}
					}
				}

			}
		}

	}
}
*/
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace UnityEngine.XR.iOS
{
	public class UnityARHitTestExample : MonoBehaviour
	{
		public Transform m_HitTransform;

        bool HitTestWithResultType (ARPoint point, ARHitTestResultType resultTypes)
        {
            List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, resultTypes);
            if (hitResults.Count > 0) {
                foreach (var hitResult in hitResults) {
                    Debug.Log ("Got hit!");
                    m_HitTransform.position = UnityARMatrixOps.GetPosition (hitResult.worldTransform);
                    m_HitTransform.rotation = UnityARMatrixOps.GetRotation (hitResult.worldTransform);
                    Debug.Log (string.Format ("x:{0:0.######} y:{1:0.######} z:{2:0.######}", m_HitTransform.position.x, m_HitTransform.position.y, m_HitTransform.position.z));
                    return true;
                }
            }
            return false;
        }
		
		// Update is called once per frame
		void Update () {
            if (Input.GetKeyDown("space")){
				if (GameObject.Find("Introduction") != null){
					Debug.Log("not null");
					GameObject.Find("Introduction").SetActive(false);
				}
				else {
					Debug.Log("null");
				}
			}
			if (Input.touchCount > 0 && m_HitTransform != null)
			{
				var touch = Input.GetTouch(0);
				Debug.Log("dubug: touch");
				if (GameObject.Find("Introduction") != null){
					GameObject.Find("Introduction").SetActive(false);
				}

				//GameObject introduction = GameObject.Find("Introduction");
				//introduction.SetActive(false);
				if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(0))
				{
					transform.localPosition = Vector3.zero;
		
					var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
					if (screenPosition.y < 0.3 || screenPosition.y > 0.7){
						Debug.Log("debug: Press Button");
						return;
					}
					else {
						Debug.Log("debug: create object");
					}
					ARPoint point = new ARPoint {
						x = screenPosition.x,
						y = screenPosition.y
					};

                    // prioritize reults types
                    ARHitTestResultType[] resultTypes = {
                        ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, 
                        // if you want to use infinite planes use this:
                        //ARHitTestResultType.ARHitTestResultTypeExistingPlane,
                        ARHitTestResultType.ARHitTestResultTypeHorizontalPlane, 
                        ARHitTestResultType.ARHitTestResultTypeFeaturePoint
                    }; 
					
                    foreach (ARHitTestResultType resultType in resultTypes)
                    {
                        if (HitTestWithResultType (point, resultType))
                        {
                            return;
                        }
                    }
				}
			}
		}
	}
}


