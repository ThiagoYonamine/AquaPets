using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    public Bar waterBar;

    /* Drink water
     * Used by: Drink.button WHERE [Home.scene] WHEN onLongClick
     */
    public void DrinkWater()
    {
        Player.instance.AddWaterHistory(Player.instance.CurrentCupSize);
        waterBar.Value = Player.instance.WaterDrankToday;
       // Player.instance.GetWaterWeekHistory();

    }
}