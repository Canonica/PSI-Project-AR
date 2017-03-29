using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using DG.Tweening;
public class DisplayManager : MonoBehaviour
{

    public TextMeshProUGUI displayText;
    public float displayTime;
    public float fadeTime;

    private IEnumerator fadeAlpha;

    private static DisplayManager displayManager;

    public static DisplayManager Instance()
    {
        if (!displayManager)
        {
            displayManager = FindObjectOfType(typeof(DisplayManager)) as DisplayManager;
            if (!displayManager)
                Debug.LogError("There needs to be one active DisplayManager script on a GameObject in your scene.");
        }

        return displayManager;
    }

    public void DisplayMessage(string message, Color color)
    {
        displayText.text = message;
        displayText.color = color;
        displayText.DOFade(0, 0);
        displayText.DOFade(1, fadeTime);
        displayText.DOFade(0, fadeTime).SetDelay(displayTime);
    }   
}