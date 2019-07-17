using System;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public Camera cam;
    Transform dogTransform;
    SpriteRenderer dogSprite;
    Animator dogAnimator;
    private float desireX;
    private string[] animations = {"dog1_idle","dog1_run","dog1_hands"};
    // Start is called before the first frame update
    void Start()
    {
        dogTransform = GetComponent<Transform>();
        dogSprite = GetComponent<SpriteRenderer>();
        dogAnimator = GetComponent<Animator>();
        InvokeRepeating("CheckPoop", 2.0f, 60f);
    }

    // Update is called once per frame
    void Update()
    {
        CheckTouch();
        CheckRun();
    }

    private void CheckPoop()
    {
        if (Player.instance.LastPoop.Length > 0)
        {
            DateTime lastLogin = DateTime.Parse(Player.instance.LastPoop);
            DateTime todayTime = DateTime.Now;
            double totalPoop = Math.Floor(todayTime.Subtract(lastLogin).TotalHours);
            
            totalPoop = Math.Min(totalPoop, 24);
            GameObject poop = Resources.Load("Poop") as GameObject;
            for (int i = 0; i < totalPoop; i++)
            {
                Instantiate(poop, this.transform.position, Quaternion.identity,
                    GameObject.FindGameObjectWithTag("PoopCanvas").transform);
                Player.instance.LastPoop = DateTime.Now.ToString();
            }
        }
        else
        {
            //dog never pooped
            Player.instance.LastPoop = DateTime.Now.ToString();
        }
    }

    private void CheckRun()
    {
        if(Mathf.Abs(dogTransform.position.x - desireX) > 0.1)
        {
            dogAnimator.Play(animations[1]);
            float direction = 0f;
            //Sesire position is in the right
            if (dogTransform.position.x - desireX < 0)
            {
                direction = +0.1f;
                dogSprite.flipX = false;
            }
            else
            {
                direction = -0.1f;
                dogSprite.flipX = true;
            }
            dogTransform.position = new Vector2(dogTransform.position.x + direction, dogTransform.position.y);
        }
        else
        {
            dogAnimator.Play(animations[0]);
        }
    }

    private void CheckTouch()
    {
        #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            desireX = cam.ScreenToWorldPoint(Input.mousePosition).x;
        }
           
        #endif
        #if UNITY_ANDROID
        if (IsDoubleTap())
        {
            desireX = cam.ScreenToWorldPoint(Input.GetTouch(0).position).x;
        }
        #endif
    }

    private bool IsDoubleTap()
    {
        bool result = false;
        float MaxTimeWait = 2;
        float VariancePosition = 1;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float DeltaTime = Input.GetTouch(0).deltaTime;
            float DeltaPositionLenght = Input.GetTouch(0).deltaPosition.magnitude;

            if (DeltaTime > 0 && DeltaTime < MaxTimeWait && DeltaPositionLenght < VariancePosition)
                result = true;
        }
        return result;
    }


}
