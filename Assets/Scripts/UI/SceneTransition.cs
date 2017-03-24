using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class SceneTransition : MonoBehaviour {
    private Image panel;

	void Start () {
        panel = GetComponent<Image>();
        panel.transform.DOScale(0, 0);
        panel.DOFade(0, 0);
        MenuManager.instance.sceneTransition = this;
    }
	
    public void PlayAnimation()
    {
        panel.transform.DOScale(1, 0.5f);
        panel.DOFade(1, 0.5f);
    }
}
