using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class SpaceshipShopData
{
    public List<int> purchasedSpaceshipIndexes = new List<int>();
}
[System.Serializable] public class PlayerData
{
    public int stars = 0;
    public int selectedSpaceshipIndex = 0;
}
public static class GameDataManager
{
    static PlayerData playerData = new PlayerData();
    static SpaceshipShopData spaceshipsShopData = new SpaceshipShopData();

    static Spaceship selectedSpaceship;
    static GameDataManager()
    {
        LoadPlayerData();
        LoadSpaceshipShopData();
    }
    public static Spaceship GetSelectedSpaceship()
    {
        return selectedSpaceship;
    }
    public static void SetSelectedSpaceship(Spaceship spaceship, int index)
    {
        selectedSpaceship = spaceship;
        playerData.selectedSpaceshipIndex = index;
        SavePlayerData();
    }
    public  static int GetSelectedSpaceshipIndex()
    {
        return playerData.selectedSpaceshipIndex;
    }
    public static int GetStars()
    {
        return playerData.stars;
    }
    public static void AddStars(int amount)
    {
        playerData.stars += amount;
        SavePlayerData();
    }
    public static bool CanSpendStars(int amount)
    {
        return (playerData.stars >= amount);
    }
    public static void SpendStars(int amount)
    {
        playerData.stars -= amount;
        SavePlayerData();
    }
    static void LoadPlayerData()
    {
        playerData = BinarySerializer.Load<PlayerData>("dataaa.txt");
        UnityEngine.Debug.Log("<color=green>[CharactersShopData] Loaded.</color>");
    }
    static void SavePlayerData()
    {
        BinarySerializer.Save(playerData, "dataaa.txt");
        UnityEngine.Debug.Log("<color=magenta>[CharactersShopData] Saved.</color>");
    }

    public static void AddPurchasedSpaceship(int spaceshipIndex)
    {
        spaceshipsShopData.purchasedSpaceshipIndexes.Add(spaceshipIndex);
        SaveCharactersShopData();
    }

    public static List<int> GetAllPurchasedSpaceship()
    {
        return spaceshipsShopData.purchasedSpaceshipIndexes;
    }

    public static int GetPurchasedSpaceship(int index)
    {
        return spaceshipsShopData.purchasedSpaceshipIndexes[index];
    }
    static void LoadSpaceshipShopData()
    {
        spaceshipsShopData = BinarySerializer.Load<SpaceshipShopData>("dataaaspaceship.txt");
        UnityEngine.Debug.Log("<color=green>[CharactersShopData] Loaded.</color>");
    }

    static void SaveCharactersShopData()
    {
        BinarySerializer.Save(spaceshipsShopData, "dataaaspaceship.txt");
        UnityEngine.Debug.Log("<color=magenta>[CharactersShopData] Saved.</color>");
    }
}
