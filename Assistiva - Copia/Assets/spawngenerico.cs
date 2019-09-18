using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawngenerico : MonoBehaviour
{
    public List<GameObject> nuvens = new List<GameObject>();
    private GameObject nuvem;
    private GameObject tempPrefab;
    private float currentTime;
    private float y;
    private int nivel;
    public int off=2;
    public float spawnRate=12.5f;
    public float maxAltura,minAltura;
    AudioSource audio;
    bool OnOff;
    bool On;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        currentTime += (Time.deltaTime);
        //Diminui a velocidade de Spawn de acordo com o nivel que se encontra
        if (currentTime >= Random.Range(spawnRate-2.5f, spawnRate+2.5f))
        {
            nuvem = nuvens[Random.Range(0, nuvens.Count)];
            currentTime = 0;
            y = Random.Range(-4.1f, -0.5f);
            tempPrefab = Instantiate(nuvem);
            tempPrefab.transform.position = new Vector2(9.82f,Random.Range(minAltura, maxAltura));
            tempPrefab.transform.localScale = new Vector2(Random.Range(-2,2)>0? tempPrefab.transform.localScale.y : -tempPrefab.transform.localScale.y, tempPrefab.transform.localScale.y);
            nivel = PlayerPrefs.GetInt("Nivel");
        }
        //if (audio.isPlaying && off%2==0)
        //{
        //    audio.Play();
        //}
        if(Input.GetKeyDown(KeyCode.Q))
        {
            audio.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            audio.enabled = true;
        }
      
}
}
