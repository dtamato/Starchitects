using UnityEngine;
using System;
using System.Collections;

public enum StarType { InterstellarCloud, Protostar, Star, StarTypeCount }
public enum ElementType { Hydrogen = 1, Helium, Carbon, ElementCount }

[DisallowMultipleComponent]
public class Star : MonoBehaviour {
	
	StarType starType;
	//DateTime birthday;
	//TimeSpan age;
	float temperature;
	float mass;
	float radius;
	float luminosity;
	float rotationSpeed = 0.1f;

	Light starlight;
	bool cloudShrinking = false;

	[SerializeField] StarStatsPanel starStatsPanel;

	void Awake () {

		starType = StarType.InterstellarCloud;
		//birthday = DateTime.Now;
		//age = DateTime.Now - birthday;
		temperature = 10;
		mass = 6000000;
		radius = 100;
		luminosity = 10;
	}

	void Update () {

		this.transform.Rotate(rotationSpeed * Vector3.up);

		if(cloudShrinking) {

			if(this.transform.localScale.x > 1) {
				
				float newScale = this.transform.localScale.x - 0.1f * Time.deltaTime;
				this.transform.localScale = newScale * Vector3.one;

				float newLightRange = starlight.range - 0.2f * Time.deltaTime;
				starlight.range = newLightRange;

				// Check if min size reached
				if(newScale <= 1 && starlight.color != Color.red) {

					this.GetComponent<MeshRenderer>().material.color = new Color32(255, 90, 90, 1);
					this.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
					starlight.color = Color.red;
					starlight.range = 2f;
					rotationSpeed = 1;
					starType = StarType.Protostar;
					cloudShrinking = false;
					starStatsPanel.UpdateStarStats();
				}
			}
		}
	}

	void CheckStarConditions () {

		if(this.GetComponentInChildren<Light>().enabled && this.GetComponentInChildren<MeshRenderer>().enabled && rotationSpeed >= 5) {

			cloudShrinking = true;
		}
	}

	public void AddInterstellarCloud () {

		this.GetComponentInChildren<Light>().enabled = true;
		starlight = this.GetComponentInChildren<Light>();
		CheckStarConditions();
	}

	public void FeedStar (ElementType element) {

		mass += (int) element;
		this.GetComponentInChildren<MeshRenderer>().enabled = true;
		CheckStarConditions();
	}

	public void PressureStar () {

		radius *= 0.9f;
		this.GetComponentInChildren<Light>().range *= 0.9f;
		temperature *= 1.1f;
		Color currentColor = this.GetComponentInChildren<Light> ().color;
		Color adjustedColor = new Color (currentColor.r + 0.2f, currentColor.g + 0.2f, currentColor.b - 0.1f);
		this.GetComponentInChildren<Light> ().color = adjustedColor;
	}

	public void RotateStar () {

		rotationSpeed = 5;
		CheckStarConditions();
	}

	#region Getters
	public StarType GetStarType () { return starType; }
	public float GetTemperature () { return temperature; }
	public float GetMass () { return mass; }
	public float GetRadius () { return radius; }
	public float GetLuminosity() { return luminosity; }
	#endregion
}