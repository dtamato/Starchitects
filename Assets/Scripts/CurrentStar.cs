using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class CurrentStar : MonoBehaviour {

	[SerializeField] GameObject starStats;


	void OnMouseDown () {

		starStats.SetActive(!starStats.activeSelf);
	}
}
