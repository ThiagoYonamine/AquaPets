using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintUserInfo : MonoBehaviour
{
    Text userInfo;
    void Start()
    {
        userInfo = GetComponent<Text>();
        userInfo.text += "\n userEmail: " +Player.instance.Email;
        userInfo.text += "\n userAge: " + Player.instance.Age;
        userInfo.text += "\n userWeight: " + Player.instance.Weight;
        userInfo.text += "\n userName: " + Player.instance.Name;
        userInfo.text += "\n userTraining: " + Player.instance.Training;
        userInfo.text += "\n userProgressive: " + Player.instance.Progressive;

    
    }

}
