using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float transitionDuration;
    public GameContext currentGameContext;
    public GameContext previousGameContext;

    private CameraController cameraController;

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
    }

    void Start()
    {
        InitGame();
        cameraController = Camera.main.GetComponent<CameraController>();
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

    IEnumerator TransitionAToS()
    {
        yield return new WaitForSeconds(transitionDuration);
        SwitchContext(GameContext.Shoot);
    }

    IEnumerator TransitionDToA()
    {
        cameraController.TransitionDToA(transitionDuration);
        yield return new WaitForSeconds(transitionDuration);
        SwitchContext(GameContext.Ascent);
    }
}
