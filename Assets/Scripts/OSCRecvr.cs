using UnityEngine;
using System.Collections;

public class OSCRecvr : MonoBehaviour {

	public OSC osc;
	public UnityEngine.Video.VideoPlayer vplayer;
	public UnityEngine.UI.Text bboard;
	public UnityEngine.TextMesh board3d;

	// Use this for initialization
	void Start () {
		vplayer.loopPointReached += onLoopPointReached;
		Debug.Log(Network.player.ipAddress);
		bboard.text = Network.player.ipAddress;
		board3d.text = Network.player.ipAddress;
		osc.SetAddressHandler( "/play" , OnReceivePlay );
		osc.SetAddressHandler("/stop", OnReceiveStop);
		osc.SetAddressHandler("/pause", OnReceivePause);
		osc.SetAddressHandler("/restart", OnReceiveRestart);
		osc.SetAddressHandler ("/ipon", OnReceiveIpon);
		osc.SetAddressHandler ("/ipoff", OnReceiveIpoff);
	}

	// Update is called once per frame
	void Update () {

	}

	void onLoopPointReached( UnityEngine.Video.VideoPlayer vp) {
		Debug.Log ("VideoEnd");
		vp.Stop ();
	}

	void OnReceivePlay(OscMessage message){
		Debug.Log ("Play");
		vplayer.Play ();
	}

	void OnReceiveStop(OscMessage message) {
		Debug.Log ("Stop");
		vplayer.Stop ();
	}

	void OnReceivePause(OscMessage message) {
		Debug.Log ("Pause");
		vplayer.Pause ();
	}

	void OnReceiveRestart(OscMessage message) {
		Debug.Log ("Restart");
		vplayer.Stop ();
		vplayer.Play ();
	}

	void OnReceiveIpon(OscMessage message) {
		Debug.Log (Network.player.ipAddress);
		bboard.text = Network.player.ipAddress;
		board3d.text = Network.player.ipAddress;
		bboard.gameObject.SetActive (true);
		board3d.gameObject.SetActive (true);
	}

	void OnReceiveIpoff(OscMessage message) {
		Debug.Log (Network.player.ipAddress);
		bboard.text = Network.player.ipAddress;
		board3d.text = Network.player.ipAddress;
		bboard.gameObject.SetActive (false);
		board3d.gameObject.SetActive (false);
	}

}