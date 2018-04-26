using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlles : MonoBehaviour {

	public GameObject world;

	void Start () {
		OVRTouchpad.Create();
		OVRTouchpad.TouchHandler += HandleTouchHandler;

	}
	void HandleTouchHandler(object sender, System.EventArgs e)
	{
		OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
		if (touchArgs.TouchType == OVRTouchpad.TouchEvent.SingleTap)
		{
			world.SetActive( !world.activeInHierarchy );
		}
	}

	void Update () {

	}
}
