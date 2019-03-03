using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    private Vector2 startTouch, swipeDelta;
    private bool swipeLeft, swipeRight;
    private bool isDragging;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }

    // Update is called once per frame
    void Update()
    {
        swipeLeft = swipeRight = false;

        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDragging = true;
                startTouch = Input.touches[0].position;
            }

            else if (Input.touches[0].phase == TouchPhase.Canceled || Input.touches[0].phase == TouchPhase.Ended)
            {
                isDragging = false;
                Reset();
            }
        }

        swipeDelta = Vector2.zero;

        if (isDragging)
        {
            if (Input.touchCount > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
        }

        if (swipeDelta.magnitude > 125)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }

            Reset();
        }
    }

    private void Reset()
    {
        isDragging = false;
        startTouch = swipeDelta = Vector2.zero;
    }
}
