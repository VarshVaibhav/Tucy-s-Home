using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SpaceshipItemUI : MonoBehaviour
{
    [SerializeField] Color itemNotSelectedColor;
    [SerializeField] Color itemSelectedColor;

    [Space(20f)]
    [SerializeField] Image spaceshipImage;
    [SerializeField] Text spaceshipNameText;
    [SerializeField] Text spaceshipPriceText;
    [SerializeField] Button spaceshipPurchaseButton;

    [Space(20f)]
    [SerializeField] Button itemButton;
    [SerializeField] Image itemImage;
    [SerializeField] Outline itemOutline;

    public void SetItemPosition(Vector2 pos)
    {
        GetComponent<RectTransform>().anchoredPosition += pos;
    }

    public void SetSpaceshipImage(Sprite sprite)
    {
        spaceshipImage.sprite = sprite;
    }

    public void SetSpaceshipName(string name)
    {
        spaceshipNameText.text = name;
    }

    public void SetSpaceshipPrize(int price)
    {
        spaceshipPriceText.text = price.ToString();
    }

    public void SetSpaceshipAsPurchased()
    {
        spaceshipPurchaseButton.gameObject.SetActive(false);
        itemButton.interactable = true;

        itemImage.color = itemNotSelectedColor;
    }
    public void OnItemPurchase(int itemIndex, UnityAction<int> action)
    {
        spaceshipPurchaseButton.onClick.RemoveAllListeners();
        spaceshipPurchaseButton.onClick.AddListener(() => action.Invoke(itemIndex));
    }

    public void OnItemSelect(int itemIndex, UnityAction<int> action)
    {
        itemButton.interactable = true;

        itemButton.onClick.RemoveAllListeners();
        itemButton.onClick.AddListener(() => action.Invoke(itemIndex));
    }
    public void SelectItem()
    {
        itemOutline.enabled = true;
        itemImage.color = itemSelectedColor;
        itemButton.interactable = false;
    }

    public void DeselectItem()
    {
        itemOutline.enabled = false;
        itemImage.color = itemNotSelectedColor;
        itemButton.interactable = true;
    }
}
