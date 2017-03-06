using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class PlayerData : MonoBehaviour {

	int currentPower;

	int hydrogenAmount = 1;
	int pressureCookerAmount = 10;

	void Awake () {

		currentPower = 3000;
	}


	#region Getters
	public int GetCurrentPower () { return currentPower; }
	public int GetHydrogenAmount () { return hydrogenAmount; }
	public int GetPressureCookerAmount () { return pressureCookerAmount; }
	#endregion

	public void IncreaseCurrentPower (int amount) {

		currentPower += amount;
	}

	public void DecreaseCurrentPower(int amount) {

		currentPower -= amount;
	}

	// Hydrogen
	public void IncreaseHydrogenAmount (int amount) {

		hydrogenAmount += amount;
	}

	public void DecreaseHydrogenAmount () {

		if(hydrogenAmount > 0) {

			hydrogenAmount--;
		}
	}


}
