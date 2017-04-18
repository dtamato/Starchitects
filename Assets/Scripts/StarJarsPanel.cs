using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class StarJarsPanel : MonoBehaviour {

	[SerializeField] Star star;


	public void AddInterstellarCloud () {

		star.AddInterstellarCloud();
		this.gameObject.SetActive(false);
	}

	public void AddStarMaterial () {

		star.FeedStar(ElementType.Hydrogen);
		this.gameObject.SetActive(false);
	}
}
