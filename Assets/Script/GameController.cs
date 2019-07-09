﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
 
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void DefinePlayerWaterGoal()
    {
        Player.instance.DefineWaterGoal();
    }

    public void SetNewCup(int amount)
    {
        Player.instance.CurrentCupSize = amount;
    }
}