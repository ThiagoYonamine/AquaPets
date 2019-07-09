using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Player 
{
    public static Player instance;

    private const string DATE_PATTERN_FORMAT = "yyyy-MM-dd";

    private string email;
    private int weight;
    private int age;
    private string name;
    private string training;
    private bool progressive;
    private int waterGoal;
    private readonly int waterDrankToday;
    private int level;
    private string lastDayLevelUp; //saves the last day with level up
    private int currentCupSize;

    static Player()
    {
        instance = new Player();
        instance.CurrentCupSize = 250;
    }

    /*
     * GETTERs and SETTERs [START]
     */

    public int CurrentCupSize
    {
        get => PlayerPrefs.GetInt("userCurrentCupSize");
        set
        {
            PlayerPrefs.SetInt("userCurrentCupSize", value);
            currentCupSize = value;
        }
    }

    public string LastDayLevelUp
    {
        get => PlayerPrefs.GetString("userLastDayLevelUp");
        set
        {
            PlayerPrefs.SetString("userLastDayLevelUp", value);
            lastDayLevelUp = value;
        }
    }

    public int Level
    {
        get => Level = PlayerPrefs.GetInt("userLevel");
        set
        {
            PlayerPrefs.SetInt("userLevel", value);
            level = value;
        }
    }

    public int WaterDrankToday
    {
        get => PlayerPrefs.GetInt(Today());
    }

    public int WaterGoal
    {
        get => PlayerPrefs.GetInt("userWaterGoal");
        set
        {
            PlayerPrefs.SetInt("userWaterGoal", value);
            waterGoal = value;
        }
    }

    public string Email
    {
        get => PlayerPrefs.GetString("userEmail");
        set
        {
            PlayerPrefs.SetString("userEmail", value);
            email = value;
        }
    }

    public int Weight
    {
        get => PlayerPrefs.GetInt("userWeight");
        set
        {
            PlayerPrefs.SetInt("userWeight", value);
            weight = value;
        }
    }

    public int Age
    {
        get => PlayerPrefs.GetInt("userAge");
        set
        {
            PlayerPrefs.SetInt("userAge", value);
            age = value;
        }
    }

    public string Name
    {
        get => PlayerPrefs.GetString("userName");
        set
        {
            PlayerPrefs.SetString("userName", value);
            name = value;
        }
    }

    public string Training
    {
        get => PlayerPrefs.GetString("userTraining");
        set
        {
            PlayerPrefs.SetString("userTraining", value);
            training = value;
        }
    }

    public bool Progressive
    {
        get => PlayerPrefs.GetString("userProgressive").Equals("True");
        set
        {
            PlayerPrefs.SetString("userProgressive", value.ToString());
            progressive = value;
        }
    }

    /*
     * GETTERs and SETTERs [END]
     */

    private string Today()
    {
        return DateTime.Today.ToString(DATE_PATTERN_FORMAT);
    }

    /* Delete some Player attribute
    * Used by: Forms WHERE [SetUp1.scene, SetUp2.scene] WHEN input_field is empty
    */
    public void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    /* Saves the amount of drank water, in milliliters
     * Used by: CupButton WHERE [Home.scene] WHEN onClick
     */
    public void AddWaterHistory(int amount)
    {
        string today = Today();
        int totalAmount = amount;
        if (PlayerPrefs.HasKey(today))
        {
            totalAmount += PlayerPrefs.GetInt(today);
        }

        Debug.Log(String.Format("Day [{0}] user drank [{1}] ml", today, totalAmount));
        PlayerPrefs.SetInt(today, totalAmount);

        if (totalAmount >= WaterGoal && !LastDayLevelUp.Equals(Today()))
        {
            Debug.Log(String.Format("LevelUp, [{0}]/[{1}] ml, [{2}]", totalAmount, WaterGoal, !LastDayLevelUp.Equals(Today())));
            LevelUp();
        }
    }

    /* Get history from this week
     * Usage: Player.instance.GetWaterWeekHistory()
     * Used by: todo
     * 
     */
    public ArrayList GetWaterWeekHistory()
    {
        ArrayList result = new ArrayList();
        DayOfWeek dayWeek = DateTime.Today.DayOfWeek;
        int days = (int)dayWeek;
        DateTime firstDay = DateTime.Today.AddDays(-days);
        for (int i = 0; i <= days; i++)
        {
            string key = firstDay.AddDays(i).ToString(DATE_PATTERN_FORMAT);
            Debug.Log("HISTORY: " + i + " " + PlayerPrefs.GetInt(key));
            result.Add(PlayerPrefs.GetInt(key));
        }

        return result;

    }


    /* Set the user water goal
    *  formula: Weight * 35ml
    * Used by: ConfirmButton WHERE [SetUp2.scene] WHEN onClick
    */
    public void DefineWaterGoal()
    {
        //TODO improve formula
        if(Weight > 0)
        {
            WaterGoal = Weight * 35;
        }
    }

    /* Increment player level when reachs the daily goal
    *  Used by: Bar.cs WHERE [Bar.cs] WHEN fillAmount is full(bar is competed)
    */
    public void LevelUp()
    {
        Level = Level + 1;
        LastDayLevelUp = Today();
    }
}
