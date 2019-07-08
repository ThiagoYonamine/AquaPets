using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("userTraining", "1");
        PlayerPrefs.SetString("userProgressive", "false");
    }

}
