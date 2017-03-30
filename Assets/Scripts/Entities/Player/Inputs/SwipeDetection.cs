using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{

    public float minSwipeDistY;
    public float minSwipeDistX;
    private Vector2 startPos;
    public PlayerTapUI playerTapUI;
    private Vector2 swipeDirection;
    public LaunchHook launchHook;

    private void Start()
    {
        launchHook = GetComponent<LaunchHook>();
    }

    private void Update()
    {
        //#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;
                case TouchPhase.Ended:
                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                    if (swipeDistVertical > minSwipeDistY)
                    {
                        swipeDirection = touch.position - startPos;
                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                        if (swipeValue > 0)
                        {
                            SwipeUpDetected(swipeDistVertical, swipeDirection);
                        }
                        else if(swipeValue < 0)
                        {
                            //DOWN
                        }
                    }
                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                    if (swipeDistHorizontal > minSwipeDistX)
                    {
                        swipeDirection = touch.position - startPos;
                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                        if (swipeValue > 0)
                        {
                            //RIGHT
                        }
                        else if (swipeValue < 0)
                        {
                            //LEFT
                        }
                    }
                    break;
            }
        }
    }

    void SwipeUpDetected(float force, Vector2 direction)
    {
        if (ContextManager.instance.CompareContext(ContextManager.GameContext.Waiting) && ContextManager.instance.previousGameContext == ContextManager.GameContext.Waiting)
        {
            
            launchHook.LaunchTheHook(force, direction.normalized);
            playerTapUI.MaskText();
        }
    }
}