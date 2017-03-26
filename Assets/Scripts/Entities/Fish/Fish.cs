using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Fish : MonoBehaviour {
    public int maxHealth;
    public int moneyToGive;
    public float minSpeed;
    public float maxSpeed;

    private float speed;
    private Rigidbody rb;


    public bool isRightDirection;
    private bool beenCaught;
    public bool isChangingDirection;
    private Boundaries boundaries;
	// Use this for initialization
	void Start () {
        speed = Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody>();
        isRightDirection = true;
        boundaries = GetComponent<Boundaries>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!beenCaught)
        {
            if (isRightDirection)
            {
                transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime, Space.Self);
            }
            else
            {
                transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime, Space.Self);
            }
        }

        if (boundaries.isOnBoundaries && !isChangingDirection)
        {
            StartCoroutine(ChangeDirection());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(ContextManager.instance.CompareContext(ContextManager.GameContext.Ascent) &&  other.tag == "Player")
        {
            other.GetComponent<PlayerHandler>().lifeScript.SubstractLife(1);
        }

        if(ContextManager.instance.CompareContext(ContextManager.GameContext.Diving) && other.tag == "Player")
        {
            beenCaught = true;
            transform.DORotate(new Vector3(0, 0, 90), 0.2f);
            rb.isKinematic = false;

            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            transform.parent = other.transform.GetChild(1).transform;
            transform.position = transform.parent.position;
        }
    }


    IEnumerator ChangeDirection()
    {
        isChangingDirection = true;
        isRightDirection = !isRightDirection;
        if (!isRightDirection)
        {
            transform.GetChild(0).DORotate(new Vector3(0, 180, 0), 0);
        }
        else
        {
            transform.GetChild(0).DORotate(new Vector3(0, 0, 0), 0);
        }
        yield return new WaitForSeconds(0.5f);
        isChangingDirection = false;
    }

}
