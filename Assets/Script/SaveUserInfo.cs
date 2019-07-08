using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveUserInfo : MonoBehaviour
{

    public void UpdatePlayerPrefs(bool value)
    {
        UpdatePlayerPrefs(value.ToString());
    }

    public void UpdatePlayerPrefs(float value)
    {
        UpdatePlayerPrefs(value.ToString());
    }

    public void UpdatePlayerPrefs(string value)
    {
        Debug.Log(String.Format("Saiving Player attribute [{0}] with value [{1}]", this.name, value));
        if (value.Length > 0)
        {
            switch (this.name)
            {
                case "userAge":
                    Player.instance.Age = int.Parse(value);
                    break;
                case "userEmail":
                    Player.instance.Email = value;
                    break;
                case "userWeight":
                    Player.instance.Weight = int.Parse(value);
                    break;
                case "userName":
                    Player.instance.Name = value;
                    break;
                case "userTraining":
                    Player.instance.Training = value;
                    break;
                case "userProgressive":
                    Player.instance.Progressive = value.Equals("True");
                    break;
                default:
                    Debug.Log("Invalid player attribute: " + this.name);
                    break;
            }
        }
        else
        {
            Player.instance.DeleteKey(this.name);
        }
           
    }

}
