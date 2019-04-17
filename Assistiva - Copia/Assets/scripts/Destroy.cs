/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    private float x;
    public GameObject alvo;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        x = transform.position.x;
        transform.position = new Vector3(x, transform.position.y,transform.position.z);
        if (x < -15)
        {
            var pf0 = Instantiate(alvo, transform.position, transform.rotation);
            pf0.SetActive(false);
        }
	}
}
*/