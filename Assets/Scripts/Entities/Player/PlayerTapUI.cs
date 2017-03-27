using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class PlayerTapUI : MonoBehaviour {
    TextMeshProUGUI text;
    Tween textTween;
    bool isShowing;
	// Use this for initialization
	void Start ()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (ContextManager.instance.CompareContext(ContextManager.GameContext.Waiting) && ContextManager.instance.previousGameContext == ContextManager.GameContext.Waiting && !isShowing)
        {
            ShowText("Tap to start fishing !");
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.A) && isShowing)
        {
            if (ContextManager.instance.CompareContext(ContextManager.GameContext.Waiting) && ContextManager.instance.previousGameContext == ContextManager.GameContext.Waiting)
            {
                ContextManager.instance.SwitchContext(ContextManager.GameContext.Diving);
                MaskText();
            }
        }
    }


    void ShowText(string parText)
    {
        isShowing = true;
        text.text = parText;
        text.DOFade(1, 0.2f);
        textTween = text.transform.DOScale(1.2f, 0.3f).SetLoops(-1, LoopType.Yoyo);
    }

    void MaskText()
    {
        isShowing = false;
        text.DOFade(0, 0.2f);
        textTween.Kill();
    }
}
