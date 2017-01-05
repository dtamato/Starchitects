using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[DisallowMultipleComponent]
public class PurchaseMenu : MonoBehaviour {

	[SerializeField] int costPerUnit;
	[SerializeField] Text amountText;
	[SerializeField] Text totalText;
	[SerializeField] PlayerData playerData;

	int amount = 1;
	int totalCost = 0;


	void Awake () {

		UpdateTotal ();
	}

	void UpdateTotal () {

		amount = Mathf.Clamp (amount, 1, 9);
		amountText.text = amount.ToString ("0");

		totalCost = costPerUnit * amount;
		totalText.text = "Total: " + (totalCost);
	}

	public void DecreaseAmount () {

		amount--;
		UpdateTotal ();
	}

	public void IncreaseAmount () {

		amount++;
		UpdateTotal ();
	}

	public void CompletePurchase () {

		playerData.DecreaseCurrentPower (totalCost);
		playerData.IncreaseHydrogenAmount (amount);
		this.gameObject.SetActive (false);
		this.GetComponentInParent<ShopMenu> ().UpdateCurrentPower ();
	}

	void OnDisable () {

		amount = 1;
		totalCost = 0;
		UpdateTotal ();
	}
}
