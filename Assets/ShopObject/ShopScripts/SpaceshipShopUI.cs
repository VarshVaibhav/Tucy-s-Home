using UnityEngine;
using UnityEngine.UI;

public class SpaceshipShopUI : MonoBehaviour
{
	[Header("Layout Settings")]
	[SerializeField] float itemSpacing = .5f;
	float itemHeight;

	[Header("UI elements")]
	[SerializeField] Image selectedCharacterIcon;
	[SerializeField] Transform ShopMenu;
	[SerializeField] Transform ShopItemsContainer;
	[SerializeField] GameObject itemPrefab;
	[Space(20)]
	[SerializeField] SpaceshipShopDatabase characterDB;

	[Space(20)]
	[Header("Shop Events")]
	[SerializeField] GameObject shopUI;
	[SerializeField] GameObject openShopButton;
	[SerializeField] GameObject closeShopButton;
	[SerializeField] GameObject MainTextContainer;

	[Space(20)]
	[Header("Main Menu")]
	[SerializeField] Image mainMenuCharacterImage;
	[SerializeField] Text mainMenuCharacterName;

	[Space(20)]
	[Header("Scroll View")]
	[SerializeField] ScrollRect scrollRect;

	int newSelectedItemIndex = 0;
	int previousSelectedItemIndex = 0;

	void Start()
	{
		shopUI.SetActive(false);
		openShopButton.SetActive(false); // thisssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
		closeShopButton.SetActive(false);
		//MainTextContainer.SetActive(true);

		GenerateShopItemsUI();

		SetSelectedCharacter();

		SelectItemUI(GameDataManager.GetSelectedSpaceshipIndex());

		ChangePlayerSkin();

		//AutoScrollShopList(GameDataManager.GetSelectedSpaceshipIndex());
	}

	void AutoScrollShopList(int itemIndex)
	{
	//	scrollRect.verticalNormalizedPosition = Mathf.Clamp01(1f - (itemIndex / (float)(characterDB.CharactersCount - 1)));
	}

	void SetSelectedCharacter()
	{
		int index = GameDataManager.GetSelectedSpaceshipIndex();

		GameDataManager.SetSelectedSpaceship(characterDB.GetSpaceship(index), index);
	}

	void GenerateShopItemsUI()
	{
		for (int i = 0; i < GameDataManager.GetAllPurchasedSpaceship().Count; i++)
		{
			int purchasedCharacterIndex = GameDataManager.GetPurchasedSpaceship(i);
			characterDB.PurchaseSpaceship(purchasedCharacterIndex);
		}
		itemHeight = ShopItemsContainer.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;
		Destroy(ShopItemsContainer.GetChild(0).gameObject);
		ShopItemsContainer.DetachChildren();

		for (int i = 0; i < characterDB.SpaceshipsCount; i++)
		{
			Spaceship spaceship = characterDB.GetSpaceship(i);
			SpaceshipItemUI uiItem = Instantiate(itemPrefab, ShopItemsContainer).GetComponent<SpaceshipItemUI>();

			uiItem.SetItemPosition(Vector2.down * i * (itemHeight + itemSpacing));

			uiItem.gameObject.name = "Item" + i + "-" + spaceship.name;

			uiItem.SetSpaceshipName(spaceship.name);
			uiItem.SetSpaceshipImage(spaceship.image);
			uiItem.SetSpaceshipPrize(spaceship.price);

			if (spaceship.isPurchased)
			{
				uiItem.SetSpaceshipAsPurchased();
				uiItem.OnItemSelect(i, OnItemSelected);
			}
			else
			{
				uiItem.SetSpaceshipPrize(spaceship.price);
				uiItem.OnItemPurchase(i, OnItemPurchased);
			}
			ShopItemsContainer.GetComponent<RectTransform>().sizeDelta =
				Vector2.up * ((itemHeight + itemSpacing) * characterDB.SpaceshipsCount + itemSpacing);
			// upar wali line
		}
	}

	void ChangePlayerSkin()
	{
		Spaceship character = GameDataManager.GetSelectedSpaceship();
		if (character.image != null)
		{
			mainMenuCharacterImage.sprite = character.image;
			mainMenuCharacterName.text = character.name;

			selectedCharacterIcon.sprite = GameDataManager.GetSelectedSpaceship().image;
		}
	}

	void OnItemSelected(int index)
	{
		SelectItemUI(index);

		GameDataManager.SetSelectedSpaceship(characterDB.GetSpaceship(index), index);

		ChangePlayerSkin();
	}

	void SelectItemUI(int itemIndex)
	{
		previousSelectedItemIndex = newSelectedItemIndex;
		newSelectedItemIndex = itemIndex;

		SpaceshipItemUI prevUiItem = GetItemUI(previousSelectedItemIndex);
		SpaceshipItemUI newUiItem = GetItemUI(newSelectedItemIndex);

		prevUiItem.DeselectItem();
		newUiItem.SelectItem();
	}

	SpaceshipItemUI GetItemUI(int index)
	{
		return ShopItemsContainer.GetChild(index).GetComponent<SpaceshipItemUI>();
	}

	void OnItemPurchased(int index)
	{
		Spaceship character = characterDB.GetSpaceship(index);
		SpaceshipItemUI uiItem = GetItemUI(index);

		if (GameDataManager.CanSpendStars(character.price))
		{
			GameDataManager.SpendStars(character.price);
			GameSharedUI.Instance.UpdateCoinsUIText();
			characterDB.PurchaseSpaceship(index);

			uiItem.SetSpaceshipAsPurchased();
			uiItem.OnItemSelect(index, OnItemSelected);

			GameDataManager.AddPurchasedSpaceship(index);
		}
		else
		{
			Debug.Log(" No enough coins.."); // deleteeeeeeeeeeeeeeeeeeeeeeeeeeeee
		}
	}

	public void OpenShop()
	{
		shopUI.SetActive(true);
		openShopButton.SetActive(false);
		closeShopButton.SetActive(true);
		//MainTextContainer.SetActive(false);
	}

	public void CloseShop()
	{
		shopUI.SetActive(false);
		openShopButton.SetActive(true);
		closeShopButton.SetActive(false);
		//MainTextContainer.SetActive(true);
	}
}
