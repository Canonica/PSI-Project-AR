using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFish : MonoBehaviour {
    public List<GameObject> possibleFish;
    PlayerHandler playerHandler;
    Transform parent;
	// Use this for initialization
	void Start ()
    {
        playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
        GenerateFishFunction(-1);
        parent = GameObject.Find("Fish").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void GenerateFishFunction(float currentDistance)
    {
        int maxdistance = -playerHandler.distanceScript.maxDistance;
        if(currentDistance > maxdistance + 3)
        {
            GameObject fishToInstantiate = possibleFish[Random.Range(0, possibleFish.Count)];
            
            float posY = Random.Range(currentDistance - 0.5f, currentDistance - 3);
            GameObject tempFish = Instantiate(fishToInstantiate, new Vector3(0, posY, 0), Quaternion.identity);
            tempFish.transform.parent = parent;
            float posX = Random.Range(tempFish.GetComponent<Boundaries>().minX, tempFish.GetComponent<Boundaries>().maxX);
            tempFish.transform.position = new Vector3(posX, tempFish.transform.position.y, 0);
            GenerateFishFunction(posY);
        }
    }
}
