using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativarEfeito : MonoBehaviour
{
    public GameObject obj;

    // Use this for initialization
    void Update()
    {
        if (PlayerPrefs.GetInt("Nivel") == 2)
        {
            Instantiate(obj);
        }
    }
}
