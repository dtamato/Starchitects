using UnityEngine;
using System;
using System.Collections;

[DisallowMultipleComponent]
public class CurrentStar : MonoBehaviour {

	[SerializeField] GameObject starStats;

	// type
	// age
	DateTime birthday;
	float temperature;
	float mass;

	void Awake () {

		birthday = DateTime.Now;
	}

	void OnMouseDown () {

		starStats.SetActive(!starStats.activeSelf);
	}
}
