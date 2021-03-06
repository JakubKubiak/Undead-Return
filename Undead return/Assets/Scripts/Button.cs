﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {
	
	public GameObject defenderPrefab;
	public static GameObject selectedDefender;
		
	private Button[] buttonArray;
	private Text costText;

	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
		
		costText = GetComponentInChildren<Text>();
		if (!costText) {Debug.LogWarning (name + " brak kosztu ");}
		
		costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
	}

	void Update () {
	
	}
	
	void OnMouseDown () {
		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
