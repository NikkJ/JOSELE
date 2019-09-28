using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class menuADM : MonoBehaviour
{
    public float incremento;
    public InputField texto;

    public void On()
    {
        PlayerPrefs.SetInt("music", 1);
    }

    public void Off()
    {
        PlayerPrefs.SetInt("music", 0);
    }

    /*public void Speed()
    {
        float.TryParse(texto.text,incremento);
        Debug.Log("inc="+incremento);
        PlayerPrefs.SetFloat("inc", incremento);
    }*/

    public void salvar()
    {
        SceneManager.LoadScene(0);
    }
}
