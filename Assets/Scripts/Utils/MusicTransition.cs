using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MusicTransition : MonoBehaviour {
    public AudioClip ascentMusic;
    public AudioClip shootMusic;

    public AudioSource audiosource;

    bool isInAscent;
    bool isInshooting;
	// Use this for initialization
	void Start ()
    {
        audiosource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (ContextManager.instance.CompareContext(ContextManager.GameContext.Ascent) && !isInAscent)
        {
            isInAscent = true;
            Transition(ascentMusic);
        }

        if (ContextManager.instance.CompareContext(ContextManager.GameContext.Shoot) && !isInshooting)
        {
            isInshooting = true;
           Transition(shootMusic);
        }
	}
    

    void Transition(AudioClip to)
    {
        audiosource.clip = to;
        audiosource.Play();
    }
}
