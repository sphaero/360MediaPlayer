using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OSCRecvr : MonoBehaviour
{
	OSC osc;
	int listIterateIndex = 0;

	public UnityEngine.Video.VideoPlayer vplayer;
	public UnityEngine.TextMesh board3d;
	public List<UnityEngine.Video.VideoClip> vidlist;

	// Use this for initialization
	void Start ()
	{
		vplayer.loopPointReached += onLoopPointReached;
		Debug.Log (Network.player.ipAddress);
		board3d.text = Network.player.ipAddress;
		osc.SetAddressHandler ("/play", OnReceivePlay);
		osc.SetAddressHandler ("/stop", OnReceiveStop);
		osc.SetAddressHandler ("/pause", OnReceivePause);
		osc.SetAddressHandler ("/restart", OnReceiveRestart);
		osc.SetAddressHandler ("/ipon", OnReceiveIpon);
		osc.SetAddressHandler ("/ipoff", OnReceiveIpoff);
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			vplayer.Pause ();
			vplayer.clip = nextVideo ();
			vplayer.Play ();
			/*if ( vplayer.isPlaying ) {
				vplayer.Stop();
			} 
			else 
			{
				vplayer.Play();
			}*/
		}
		if (Input.GetMouseButtonDown (1)) {
			vplayer.Pause ();
			vplayer.clip = prevVideo ();
			vplayer.Play ();
			/*
			if (board3d.gameObject.activeInHierarchy )
			{
				board3d.gameObject.SetActive (false);
			}
			else
			{
				board3d.text = Network.player.ipAddress;
				board3d.gameObject.SetActive( true );
			}*/
		}
	}

	void onLoopPointReached (UnityEngine.Video.VideoPlayer vp)
	{
		Debug.Log ("VideoEnd");
		vp.Stop ();
	}

	void OnReceivePlay (OscMessage message)
	{
		Debug.Log ("Play");
		vplayer.Play ();
	}

	void OnReceiveStop (OscMessage message)
	{
		Debug.Log ("Stop");
		vplayer.Stop ();
	}

	void OnReceivePause (OscMessage message)
	{
		Debug.Log ("Pause");
		vplayer.Pause ();
	}

	void OnReceiveRestart (OscMessage message)
	{
		Debug.Log ("Restart");
		vplayer.Stop ();
		vplayer.Play ();
	}

	void OnReceiveIpon (OscMessage message)
	{
		Debug.Log (Network.player.ipAddress);
		board3d.text = Network.player.ipAddress;
		board3d.gameObject.SetActive (true);
	}

	void OnReceiveIpoff (OscMessage message)
	{
		Debug.Log (Network.player.ipAddress);
		board3d.text = Network.player.ipAddress;
		board3d.gameObject.SetActive (false);
	}

	UnityEngine.Video.VideoClip nextVideo ()
	{
		if (listIterateIndex == vidlist.Count) {
			listIterateIndex = 0;
		}
		if (listIterateIndex < 0) {
			listIterateIndex = vidlist.Count - 1;
		}
		UnityEngine.Video.VideoClip ret = vidlist [listIterateIndex];
		listIterateIndex++;
		return ret;
	}

	UnityEngine.Video.VideoClip prevVideo ()
	{
		if (listIterateIndex == vidlist.Count) {
			listIterateIndex = 0;
		}
		if (listIterateIndex < 0) {
			listIterateIndex = vidlist.Count - 1;
		}
		UnityEngine.Video.VideoClip ret = vidlist [listIterateIndex];
		listIterateIndex--;
		return ret;
	}
}