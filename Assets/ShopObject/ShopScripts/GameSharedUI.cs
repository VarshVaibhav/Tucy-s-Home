using UnityEngine;
using UnityEngine.UI;

public class GameSharedUI : MonoBehaviour
{
	#region Singleton class: GameSharedUI

	public static GameSharedUI Instance;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	#endregion

	[SerializeField] Text[] starsUIText;

	void Start()
	{
		UpdateCoinsUIText();
	}

	public void UpdateCoinsUIText()
	{
		for (int i = 0; i < starsUIText.Length; i++)
		{
			starsUIText[i].text = GameDataManager.GetStars().ToString() + " $";
		}
	}
}
