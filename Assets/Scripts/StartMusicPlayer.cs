using UnityEngine;
using System.Collections;

public class StartMusicPlayer : MonoBehaviour {
	static StartMusicPlayer instance = null;
	
	// Use this for initialization
	void Start () {
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
