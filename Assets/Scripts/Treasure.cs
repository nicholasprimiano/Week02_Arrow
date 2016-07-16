﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Security.Cryptography.X509Certificates;

public class Treasure : MonoBehaviour {

	//Treasure located at (playerSpeed,-playerSpeed)
	bool didPlayerWin = false; //Win State
	public Text dirText; //Direction Text
	public Transform player; //Player Location
	public Transform felicity; //Felicity Location
	public Transform diggle; //Diggle Location
	public Transform barry;  //Barry Location
	public Transform thea;  //Thea Location
	public bool isOpen = false;
	public Door door1;
	public PlayerPhysicsMove playerMove;
	public float increasedPlayerSpeed;
	public TrailRenderer trailRendererGreen;
	public TrailRenderer trailRendererRed;

	void Update () {
		
		const int playerSpeed = 50;

		if (player.position.x < -playerSpeed) {
			//Move Right
			dirText.text = "You are very far away. Go back to the where you started.";
		} else if (player.position.y > playerSpeed) {
			//Move Down	
			dirText.text = "You are very far away. Go back to the where you started.";
		} else if (player.position.y < -playerSpeed) {
			//Move Up
			dirText.text = "You are very far away. Go back to the where you started.";
		} else if (player.position.x > playerSpeed) {
			//Move Left
			dirText.text = "You are very far away. Go back to the where you started.";
		}
		//Player close to Felicity
		else if ((player.position - felicity.transform.position).magnitude < 5f) {
			dirText.text = "I hacked the locked (red) doors. It's open now!";
			isOpen = true;
		}
		//Player close to Diggle
		else if ((player.position - diggle.transform.position).magnitude < 5f) {
			dirText.text = "Hey oliver its Diggle.";
		}
		//Player close to Thea
		else if ((player.position - thea.transform.position).magnitude < 5f) {
			dirText.text = "Thea: Oliver, turn around! This area is clear.";
		}
		//Player close to Barry
		else if ((player.position - barry.transform.position).magnitude < 5f) {
			dirText.text = "Barry: The speed force just have you a boost! Darhk could be this way!";
			//Double player speed on proximity to Barry;
			playerMove.playerSpeed = increasedPlayerSpeed;
			trailRendererGreen.enabled = false;
			trailRendererRed.enabled = true;
			//attach red trail renderer to player
			//why is unity terrible there should be a class for this
			trailRendererRed.transform.parent = player.transform;
			trailRendererRed.transform.position = player.transform.position;
		}
		//Player close 
		else if ((player.position - transform.position).magnitude < 20f) {
			dirText.text = "You are very close. The treasure is right around here.";
			//Player win zone
			if ((player.position - transform.position).magnitude < 5f) {
				dirText.text = "Press [Space] to catch Damien Darhk! ";
				if (Input.GetKeyDown (KeyCode.Space)) {
					AudioSource audio = GetComponent<AudioSource> ();
					audio.Play ();
					didPlayerWin = true;
				} else if (didPlayerWin) {
					SceneManager.LoadScene ("Win Screen");
				}
			}
		} else {
			//Is lock text showing
			if (!door1.lockTextShowing) {
				dirText.text = "Find Damien Darhk!";
			}
		}
		if (Input.GetKey (KeyCode.Space)) {
			dirText.text += " " + (player.position - transform.position).ToString ();
		}
	}
}
