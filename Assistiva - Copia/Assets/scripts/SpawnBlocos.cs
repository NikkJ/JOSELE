using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocos : MonoBehaviour {
    public float maxHeight;
    public float minHeight;
    public float rateSpawn;
    private float currentRateSpawn;
    public GameObject Quad;
    public int maxBlocos;
    public List<GameObject> bloco;

    private void Start()
    {
        for (int i = 0;i< maxBlocos; i++)
        {
            GameObject tempBloco = Instantiate(Quad) as GameObject;
            bloco.Add(tempBloco);
            tempBloco.SetActive(true);
        }
    }

    private void Update()
    {
        currentRateSpawn += Time.deltaTime;
        if(currentRateSpawn > rateSpawn)
        {
            currentRateSpawn = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        float randPosition = Random.Range(minHeight, maxHeight);
        GameObject tempBloco = null;
        for (int i = 0; i < maxBlocos; i++)
        {
            if(bloco[i].activeSelf == false)
            {
                tempBloco = bloco[i];
                break;
            }
        }
        if(tempBloco != null)
        {
            tempBloco.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            tempBloco.SetActive(true);
        }
    }

}
