using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopMenu : MonoBehaviour {

	[SerializeField] PlayerData playerData;
	[SerializeField] Text currentPowerText;


	void OnEnable () {

		UpdateCurrentPower ();
	}

	public void UpdateCurrentPower () {

		currentPowerText.text = "Power: " + playerData.GetCurrentPower ().ToString ();
	}
}
