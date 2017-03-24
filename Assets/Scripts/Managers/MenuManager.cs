using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {

    public static MenuManager instance;
    public SceneTransition sceneTransition;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void Play()
    {
        sceneTransition.PlayAnimation();
        StartCoroutine(LoadSceneByIndex(1, 1));
    }

    public void ReturnToMainMenu()
    {
        sceneTransition.PlayAnimation();
        StartCoroutine(LoadSceneByIndex(0, 1));
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    IEnumerator LoadSceneByIndex(int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(index);
    }
}
