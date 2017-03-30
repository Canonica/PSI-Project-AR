using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
public class ContextManager : MonoBehaviour {
    public enum GameContext
    {
        Waiting,
        TransitionDToA,
        Diving,
        Ascent,
        TransitionAtoS,
        Shoot
    }

    public static ContextManager instance;
    public float transitionDurationDToA;
    public float transitionDurationAToS;
    public GameContext currentGameContext;
    public GameContext previousGameContext;

    public CameraController cameraController;


    public GameObject ARCamera;
    public GameObject camera2D;
    public Image image;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        cameraController = camera2D.GetComponent<CameraController>();
    }

    void Start()
    {
        InitGame();
        camera2D.SetActive(false);
    }

    public void SwitchContext(GameContext contextWanted)
    {
        if(contextWanted == currentGameContext)
        {
            return;
        }

        if(contextWanted == GameContext.TransitionAtoS)
        {
            StartCoroutine(TransitionAToS());
        }
        else if(contextWanted == GameContext.TransitionDToA)
        {
            StartCoroutine(TransitionDToA());
        }
        previousGameContext = currentGameContext;
        currentGameContext = contextWanted;
    }

    public void InitGame()
    {
        SwitchContext(GameContext.Waiting);
    }

    public bool CompareContext(GameContext contextToCompare)
    {
        return contextToCompare == currentGameContext;
    }

    public void TransitionWToD(Vector3 targetPos)
    {
        ARCamera.GetComponentInChildren<GyroHandler>().enabled = false;
        ARCamera.transform.DOMove(targetPos, 1f).OnComplete(() => WaitingToDescent());
    }

    IEnumerator TransitionAToS()
    {
        yield return new WaitForSeconds(transitionDurationAToS);
        SwitchContext(GameContext.Shoot);
    }

    IEnumerator TransitionDToA()
    {
        cameraController.TransitionDToA(transitionDurationDToA);
        yield return new WaitForSeconds(transitionDurationDToA);
        SwitchContext(GameContext.Ascent);
    }

    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    void WaitingToDescent()
    {
        image.DOFade(1, 0.5f).OnComplete(()=> ARCamera.gameObject.SetActive(false));
        image.DOFade(0, 0.5f).SetDelay(1).OnPlay(()=> camera2D.SetActive(true));
        image.DOFade(0, 1).SetDelay(1.5f).OnComplete(()=> SwitchContext(GameContext.Diving));
    }
}
