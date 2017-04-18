using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum Tool { Pressurer, Rotator }

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
	Tool toolUsing;

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
			confirmFeedMenu.GetComponentInChildren<Text>().text = "Add " + elementToFeed.ToString() + "\nto star?";
			confirmFeedMenu.transform.GetChild(1).GetComponentInChildren<Image>().color = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponentInChildren<Image>().color;
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
			confirmItemMenu.transform.GetChild(3).GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Image>().sprite;
			confirmItemMenu.transform.GetChild(3).GetComponent<Image>().color = Color.blue;
			toolUsing = Tool.Pressurer;
			this.gameObject.SetActive(false);
		}
	}

	public void AddRotation () {

		confirmItemMenu.SetActive(true);
		confirmItemMenu.GetComponentInChildren<Text>().text = "Add rotation\n to star?";
		confirmItemMenu.transform.GetChild(3).GetComponent<Image>().sprite = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Image>().sprite;
		confirmItemMenu.transform.GetChild(3).GetComponent<Image>().color = Color.blue;
		toolUsing = Tool.Rotator;
		this.gameObject.SetActive(false);
	}

	public void ConfirmItemUse () {

		Star currentStar = currentStarContainer.GetCurrentStar();

		switch (toolUsing) {
		case Tool.Pressurer:
			currentStar.PressureStar();
			break;
		case Tool.Rotator:
			currentStar.RotateStar();
			break;
		}

		starStatsPanel.UpdateStarStats();
		confirmItemMenu.SetActive(false);
	}

	public void CancelItemUse () {

		confirmItemMenu.SetActive(false);
		this.gameObject.SetActive(true);
	}
	#endregion
}
