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

    static Player()
    {
        instance = new Player();
    }

    /*
     * GETTERs and SETTERs [START]
     */
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


    /* Delete some Player attribute
    * Used by: Forms WHERE [SetUp1, SetUp2 - Scene] WHEN input_field is empty
    */
    public void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    /* Saves the amount of drank water, in milliliters
     * Used by: CupButton WHERE [Home - Scene] WHEN onClick
     */
    public void AddWaterHistory(int amount)
    {
        string today = DateTime.Today.ToString(DATE_PATTERN_FORMAT);
        int totalAmount = amount;
        if (PlayerPrefs.HasKey(today))
        {
            totalAmount += PlayerPrefs.GetInt(today);
        }

        Debug.Log(String.Format(" Day [{0}] user drank [{1}] ml", today, totalAmount));
        PlayerPrefs.SetInt(today, totalAmount);
    }


    /* Get history from last X days;
     * Eg: GetWaterHistory(0) -> history from today 
     *     GetWaterHistory(7) -> history from last 7 days
     *     
     * Used by: 
     */
    public void GetWaterHistory(int days)
    {
        OrderedDictionary result = new OrderedDictionary();
        DateTime firstDay = DateTime.Today.AddDays(-days);

        for(int i=0; i <= days; i++)
        {
            string key = firstDay.AddDays(i).ToString(DATE_PATTERN_FORMAT);
            Debug.Log(key + " -> " + PlayerPrefs.GetInt(key));
        }
       
    }
}
