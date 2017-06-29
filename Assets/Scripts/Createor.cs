using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createor : MonoBehaviour {

    public GameObject[] groups;

	// Use this for initialization
	void Start () {
        SpawnNext();
	}
	
    public void SpawnNext()
    {
        int i = Random.Range(0, groups.Length);
        Instantiate(groups[i], transform.position, Quaternion.identity);
    }


}
