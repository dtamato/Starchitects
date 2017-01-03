using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class PlayerData : MonoBehaviour {

	int currentPower;


	void Awake () {

		currentPower = 3000;
	}


	#region Getters
	public int GetCurrentPower () {

		return currentPower;
	}

	public void ChangeCurrentPower (int amount) {

		currentPower += amount;
	}
	#endregion
}
