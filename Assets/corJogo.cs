using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class corJogo : MonoBehaviour
{

    public GameObject branco;
    public GameObject normal;

    // Use this for initialization
    public void MudarCor()
    {
        PlayerPrefs.SetInt("cor", 1);
        SceneManager.LoadScene(1);
    }
}
