using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawnerController : MonoBehaviour {
    private GameObject[] SpawnLocations;
    public GameObject AIMonsterPrefab;

    //public GameObject Target;

	// Use this for initialization
	void Start () {
        SpawnLocations = GameObject.FindGameObjectsWithTag("Respawn");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spawn()
    {
        GameObject newMonster = Instantiate(AIMonsterPrefab, transform.position, transform.rotation);

        int randomSpawnerNum = Random.Range(0, SpawnLocations.Length - 1);

        newMonster.transform.position = SpawnLocations[randomSpawnerNum].transform.position;
    }

}
