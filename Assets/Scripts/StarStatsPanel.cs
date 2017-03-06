using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class StarStatsPanel : MonoBehaviour {

	[SerializeField] Star currentStar;
	[SerializeField] Text starTypeText;
	[SerializeField] Text temperatureText;
	[SerializeField] Text massText;
	[SerializeField] Text radiusText;
	[SerializeField] Text luminosityText;


	void Awake () {

		this.gameObject.SetActive(false);
	}

	void OnEnable () {

		UpdateStarStats();
	}

	public void UpdateStarStats () {

		starTypeText.text = currentStar.GetStarType().ToString();
		temperatureText.text = currentStar.GetTemperature() + " K";
		massText.text = currentStar.GetMass() + " M";
		radiusText.text = currentStar.GetRadius() + " R";
		luminosityText.text = currentStar.GetLuminosity() + " L";
	}
}
