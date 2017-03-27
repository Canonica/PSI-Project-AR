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

    PlayerHandler playerHandler;
	// Use this for initialization
	void Start () {
        speed = Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody>();
        isRightDirection = true;
        boundaries = GetComponent<Boundaries>();
        playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
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

        if (boundaries.isOnBoundaries && !isChangingDirection && !beenCaught)
        {
            StartCoroutine(ChangeDirection());
        }

        if (ContextManager.instance.CompareContext(ContextManager.GameContext.Shoot))
        {
            transform.Rotate(Vector3.forward * Random.Range(100, 1000) *  Time.deltaTime);
        }
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ContextManager.instance.SwitchContext(ContextManager.GameContext.Shoot);
            beenCaught = true;
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            rb.AddForce(Random.Range(-1.0f, 1.0f), 0.8f, 0, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(ContextManager.instance.CompareContext(ContextManager.GameContext.Diving) &&  other.tag == "Player")
        {
            other.GetComponent<PlayerHandler>().lifeScript.SubstractLife(this,  1);
        }

        if(ContextManager.instance.CompareContext(ContextManager.GameContext.Ascent) && other.tag == "Player")
        {
            GetCaught(other.transform);
        }
    }

    public void GetCaught(Transform player)
    {
        beenCaught = true;
        transform.DORotate(new Vector3(0, 0, 90), 0.2f);
        rb.isKinematic = false;

        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        transform.parent = player.GetChild(1).transform;
        transform.position = transform.parent.position;
        playerHandler.fishCaughtList.Add(this);
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
