using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    private Vector2 currentPosition;
    private float desireX;
    private float desireY;
    public string type;
    private void Start()
    {  
        float scale = Camera.main.aspect / 2.05f;
        this.transform.localScale = new Vector3(scale, scale, scale);
        desireX = 8.75f * scale;
        if(type == "Special")
        {
            desireY = 3f * scale;
        }
        else
        {
            desireY = 4.2f * scale;
        }
           
    }
    void Update()
    {
        if(!IsEquals(currentPosition.x, desireX) || !IsEquals(currentPosition.y, desireY))
        {
            currentPosition = this.GetComponent<Transform>().position;
            float x = Mathf.Lerp(currentPosition.x, desireX, Time.deltaTime * 3.5f);
            float y = Mathf.Lerp(currentPosition.y, desireY, Time.deltaTime * 2.5f);
            this.GetComponent<Transform>().position = new Vector2(x, y);
        }
        else
        {
            if (type == "Special")
            {
                Player.instance.SpecialCoin++;
            }
            else
            {
                Player.instance.NormalCoin++;
            }
          
            Destroy(this.gameObject);
        }

    }

    private bool IsEquals(float a, float b)
    {
        return Mathf.Abs(b - a) < 0.5f;
    }
}
