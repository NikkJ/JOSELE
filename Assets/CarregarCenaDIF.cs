using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarregarCenaDIF : MonoBehaviour
{
    public GameObject menu;
    public GameObject opcoes;
    public GameObject customizar;
    public GameObject white;
    public InputField input;

    private void Start()
    {
        PlayerPrefs.SetFloat("speed", 1f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Use this for initialization
    public void Menu2()
    {
        PlayerPrefs.SetInt("cor", 0);
        SceneManager.LoadScene(1);
    }
    public void Opcoes()
    {
        TrocarTela(menu, opcoes);
    }
    public void Customizar()
    {
        TrocarTela(opcoes, customizar);

    }

    public void Personagem0()
    {
        PlayerPrefs.SetInt("estiloPersonagem", 0);
   
    }

    public void Personagem1()
    {
        PlayerPrefs.SetInt("estiloPersonagem", 1);
        
    }
    public void Personagem2()
    {
        PlayerPrefs.SetInt("estiloPersonagem", 2);

    }
    public void Personagem3()
    {
        PlayerPrefs.SetInt("estiloPersonagem", 3);

    }
    public void Personagem4()
    {
        PlayerPrefs.SetInt("estiloPersonagem", 4);

    }
    public void Personagem5()
    {
        PlayerPrefs.SetInt("estiloPersonagem", 5);

    }
    public void CarregarJogo()
    {
        SceneManager.LoadScene(1);

    }

    public void TentarNovamente()
    {
        SceneManager.LoadScene(0);
    }


    private void TrocarTela(GameObject atual, GameObject nova)
    {
        atual.SetActive(false);
        nova.SetActive(true);
    }

    public void Erros()
    {
        int erros = int.Parse(input.text);
        PlayerPrefs.SetInt("erro", erros);
    }
}