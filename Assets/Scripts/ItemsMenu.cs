using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[DisallowMultipleComponent]
public class ItemsMenu : MonoBehaviour {

	[Header("References")]
	[SerializeField] CurrentStarContainer currentStarContainer;
	[SerializeField] StarStatsPanel starStatsPanel;
	[SerializeField] PlayerData playerData;
	[SerializeField] Text hydrogenAmount;
	[SerializeField] GameObject confirmFeedMenu;
	[SerializeField] GameObject confirmItemMenu;

	ElementType elementToFeed;

	void OnEnable () {

		UpdateAmounts ();
	}

	void UpdateAmounts () {

		hydrogenAmount.text = "x " + playerData.GetHydrogenAmount ().ToString("00");
	}

	#region FeedingStar
	public void FeedElement (int elementIndex) {

		elementToFeed = (ElementType) elementIndex;

		if (elementToFeed == ElementType.Hydrogen && playerData.GetHydrogenAmount () > 0) {

			confirmFeedMenu.SetActive (true);
			confirmFeedMenu.GetComponentInChildren<Text>().text = "Add" + elementToFeed.ToString() + " to star?";
			this.gameObject.SetActive (false);
		}
	}

	public void ConfirmFeedElement () {

		Star currentStar = currentStarContainer.GetCurrentStar();
		currentStar.FeedStar(elementToFeed);

		if(elementToFeed == ElementType.Hydrogen) {

			playerData.DecreaseHydrogenAmount ();
		}

		starStatsPanel.UpdateStarStats();
		confirmFeedMenu.SetActive (false);
	}

	public void CancelFeedMenu () {

		confirmFeedMenu.SetActive (false);
		this.gameObject.SetActive (true);
	}
	#endregion

	#region ItemToStar
	public void AddPressure () {

		if(playerData.GetPressureCookerAmount() > 0) {

			confirmItemMenu.SetActive(true);
			confirmItemMenu.GetComponentInChildren<Text>().text = "Add pressure\n to star?";
			this.gameObject.SetActive(false);
		}
	}

	public void ConfirmItemUse () {

		Star currentStar = currentStarContainer.GetCurrentStar();
		currentStar.PressureStar();
		starStatsPanel.UpdateStarStats();
		confirmItemMenu.SetActive(false);
	}

	public void CancelItemUse () {

		confirmItemMenu.SetActive(false);
		this.gameObject.SetActive(true);
	}
	#endregion
}
