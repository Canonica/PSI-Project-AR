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
        ShowText("Swipe up to launch the hook !");
    }


    public void ShowText(string parText)
    {
        isShowing = true;
        text.text = parText;
        text.DOFade(1, 0.2f);
        textTween = text.transform.DOScale(1.2f, 0.3f).SetLoops(-1, LoopType.Yoyo);
    }

    public void MaskText()
    {
        isShowing = false;
        text.DOFade(0, 0.2f);
        textTween.Kill();
    }
}
