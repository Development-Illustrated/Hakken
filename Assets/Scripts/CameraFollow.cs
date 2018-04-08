using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
	
	// Update is called once per frame
	void Update () {

        float playerx = player.transform.position.x;
        float playery = player.transform.position.y;

        transform.position = new Vector3(playerx, playery, transform.position.z);
    }
}
