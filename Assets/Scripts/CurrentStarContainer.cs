using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CurrentStarContainer : MonoBehaviour {

	[SerializeField] GameObject starStatsPanel;

	[SerializeField] Star currentStar;


	void OnMouseDown () {

		if(Input.GetMouseButtonDown(0) && currentStar.gameObject.GetComponentInChildren<Light>().enabled == true) {

			starStatsPanel.SetActive(!starStatsPanel.activeSelf);
		}
	}

	public void SetCurrentStar(Star newCurrentStar) {

		currentStar = newCurrentStar;
	}

	public Star GetCurrentStar () {

		return currentStar;
	}
}
