using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour
{

    private Material currentMaterial;
    public float speed;
    private float offset;
    private object _MainTex;

    void Start()
    {
        currentMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += 0.001f;


        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
    }
}

