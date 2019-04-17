using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colet : MonoBehaviour
{
    public GameObject Quad;
    public float rateSpawn;
    public float currentTime;
    private float x;
    public GameObject tempPrefab;


    private void Start()
    {
        currentTime = 0;
        Quad = GameObject.FindWithTag("Pick up");
    }


    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= rateSpawn)
        {
            currentTime = 0;
            GameObject tempPrefab = Instantiate(Quad, transform.position, Quaternion.identity) as GameObject;
            Quad.active = true;
        }
    }

    /*internal void SetActive(bool v)
    {
        throw new NotImplementedException();
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }*/
}
