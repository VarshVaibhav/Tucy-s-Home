using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpaceshipShopDatabase", menuName = "Shopping/Spaeships shop database")]
public class SpaceshipShopDatabase : ScriptableObject
{
    public Spaceship[] spaceships;

    public int SpaceshipsCount
    {
        get { return spaceships.Length; }
    }

    public Spaceship GetSpaceship(int index)
    {
        return spaceships[index];
    }

    public void PurchaseSpaceship(int index)
    {
        spaceships[index].isPurchased = true;
    }
}
