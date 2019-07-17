using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    public void InstantiateBone()
    {
        GameObject bone = Resources.Load("bone") as GameObject;
        Instantiate(bone, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
