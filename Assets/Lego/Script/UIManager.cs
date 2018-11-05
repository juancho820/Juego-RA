using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public RectTransform colorMenu;
    public RectTransform actionMenu;

    private bool menuAnimating;
    private bool areMenusShowing;
    private float menuAnimationTransition;
    private float animationDuration;

    private void Awake()
    {
        menuAnimating = false;
        menuAnimationTransition = 1;
        animationDuration = 0.2f;
        areMenusShowing = true;
        //OnTheOneButtonClick();
    }

    public void Update()
    {
        if (menuAnimating)
        {
            if (areMenusShowing)
            {
                menuAnimationTransition += Time.deltaTime * (1 - animationDuration);
                if(menuAnimationTransition >= 1)
                {
                    menuAnimationTransition = 1;
                    menuAnimating = false;
                }
            }
            else
            {
                menuAnimationTransition -= Time.deltaTime;
                if (menuAnimationTransition <= 0)
                {
                    menuAnimationTransition = 0;
                    menuAnimating = false;
                }
            }

            colorMenu.anchoredPosition = Vector2.Lerp(new Vector2(0, -50), new Vector2(0,100), menuAnimationTransition);
            actionMenu.anchoredPosition = Vector2.Lerp(new Vector2(-200, 0), new Vector2(50, 0), menuAnimationTransition);
        }
    }

    public void OnTheOneButtonClick()
    {
        areMenusShowing = !areMenusShowing;
        PlayMenuAnimation();
    }

    public void PlayMenuAnimation()
    {
        menuAnimating = true;
    }
}
