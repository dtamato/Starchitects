using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[DisallowMultipleComponent]
public class ItemsMenu : MonoBehaviour {

	[SerializeField] PlayerData playerData;
	[SerializeField] Text hydrogenAmount;
	[SerializeField] GameObject confirmFeedMenu;

	void OnEnable () {

		UpdateAmounts ();
	}

	void UpdateAmounts () {

		hydrogenAmount.text = "x " + playerData.GetHydrogenAmount ().ToString("00");
	}

	public void FeedHydrogen () {

		if (playerData.GetHydrogenAmount () > 0) {

			confirmFeedMenu.SetActive (true);
			this.gameObject.SetActive (false);
		}
	}

	public void ConfirmFeed () {

		playerData.DecreaseHydrogenAmount ();
		confirmFeedMenu.SetActive (false);
	}

	public void CancelFeed () {

		confirmFeedMenu.SetActive (false);
		this.gameObject.SetActive (true);
	}
}
