using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintUserInfo : MonoBehaviour
{
    public Text userInfo;
    public Text userName;
    public Text userCurrentCupSize;
    public Text userLevel;
    public Text userNormalCoin;
    public Text userSpecialCoin;

    void Start()
    {
        
        userInfo.text += "\n userEmail: " +Player.instance.Email;
        userInfo.text += "\n userAge: " + Player.instance.Age;
        userInfo.text += "\n userWeight: " + Player.instance.Weight;
        userInfo.text += "\n userName: " + Player.instance.Name;
        userInfo.text += "\n userTraining: " + Player.instance.Training;
        userInfo.text += "\n userProgressive: " + Player.instance.Progressive;
        userInfo.text += "\n userWaterGoal: " + Player.instance.WaterGoal;
        userInfo.text += "\n userWaterDrank: " + Player.instance.WaterDrankToday;

        userName.text = Player.instance.Name;
        userCurrentCupSize.text = Player.instance.CurrentCupSize.ToString();
        userLevel.text = Player.instance.Level.ToString();
        userNormalCoin.text = Player.instance.NormalCoin.ToString();
        userSpecialCoin.text = Player.instance.SpecialCoin.ToString();


    }

    private void Update()
    {
        userSpecialCoin.text = Player.instance.SpecialCoin.ToString();
        userNormalCoin.text = Player.instance.NormalCoin.ToString();
    }

    /* Update UI cup with Player.CurrentCupSize value
     * Used by: ExitButton WHERE [Home.scene] WHEN onClick
     */
    public void UpdateCupSize()
    {
        userCurrentCupSize.text = Player.instance.CurrentCupSize.ToString();
    }

    public void UpdateUserLevel()
    {
        userLevel.text = Player.instance.Level.ToString();
    }

    public void UpdateUserSpecialCoin()
    {
        userSpecialCoin.text = Player.instance.SpecialCoin.ToString();
    }
}
