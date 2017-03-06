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

	void Awake () {

		starType = StarType.InterstellarCloud;
		//birthday = DateTime.Now;
		//age = DateTime.Now - birthday;
		temperature = 10;
		mass = 6000000;
		radius = 100;
		luminosity = 10;
	}

	public void FeedStar (ElementType element) {

		mass += (int) element;
	}

	public void PressureStar () {

		radius *= 0.9f;
		this.GetComponentInChildren<Light>().range *= 0.9f;
		temperature *= 1.1f;
	}

	#region Getters
	public StarType GetStarType () { return starType; }
	public float GetTemperature () { return temperature; }
	public float GetMass () { return mass; }
	public float GetRadius () { return radius; }
	public float GetLuminosity() { return luminosity; }
	#endregion
}
