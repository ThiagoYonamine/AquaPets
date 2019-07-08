using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{

    public void DrinkWater(int amount)
    {
       // Player.instance.AddWaterHistory(amount);
        Player.instance.GetWaterHistory(7);
    }
}
