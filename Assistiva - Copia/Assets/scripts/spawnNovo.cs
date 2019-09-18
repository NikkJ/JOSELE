using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnNovo : MonoBehaviour {

    public GameObject blocoPrefab;
    public float rateSpawn=1;
    public float currentTime;
    public float y;
    public float velocidade;
    private GameObject tempPrefab;
    private int nivel;
    private double a;
    public double b;
    corJogo cor = new corJogo();

    public spawnNovo(corJogo cor)
    {
        this.cor = cor;
    }

    // Use this for initialization
    void Start () {
        currentTime = 0;
        nivel = PlayerPrefs.GetInt("Nivel");
        velocidade =PlayerPrefs.GetFloat("speed");
        a =  (1f/nivel * ((0.8f/velocidade))/rateSpawn); //dando erro de calculo ******REVER A FORMULA************
        Debug.Log("Velocidade spawn: "+a);
    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        //Diminui a velocidade de Spawn de acordo com o nivel que se encontra
        if(currentTime >= a)
        {
            currentTime = 0;
            y = Random.Range(-4.1f, -0.5f);
            tempPrefab = Instantiate(blocoPrefab) as GameObject;
            nivel = PlayerPrefs.GetInt("Nivel");
            tempPrefab.transform.position = new Vector3(transform.position. x, y, tempPrefab.transform.position.z);
        }
		
	}
}
