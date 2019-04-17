using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnNovo : MonoBehaviour {

    public GameObject blocoPrefab;
    public float rateSpawn;
    public float currentTime;
    public float y;
    private GameObject tempPrefab;
    private int nivel;


	// Use this for initialization
	void Start () {
        currentTime = 0;
        nivel = PlayerPrefs.GetInt("Nivel");

    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        //Diminui a velocidade de Spawn de acordo com o nivel que se encontra
        if(currentTime >= rateSpawn/(Mathf.Pow(nivel,0.16f)))
        {
            currentTime = 0;
            y = Random.Range(-4.1f, -0.5f);
            tempPrefab = Instantiate(blocoPrefab) as GameObject;
            nivel = PlayerPrefs.GetInt("Nivel");
            tempPrefab.transform.position = new Vector3(transform.position. x, y, tempPrefab.transform.position.z);
        }
		
	}
}
