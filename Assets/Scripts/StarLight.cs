using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Light))]
public class StarLight : MonoBehaviour {

	[SerializeField] float flickerTime = 0.1f;

	Light starLight;
	int direction = -1;


	void Awake () {

		starLight = this.GetComponent<Light>();
		StartCoroutine(ChangeDirection());
	}

	void Update () {

		starLight.range += direction * Time.deltaTime;
	}

	IEnumerator ChangeDirection () {

		yield return new WaitForSeconds(flickerTime);
		direction *= -1;
		StartCoroutine(ChangeDirection());
	}
}
