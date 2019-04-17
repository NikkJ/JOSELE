using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscolhePalavra : MonoBehaviour {
    public List<string> Palavras = new List<string>();
    public string palavraAtual = "";
    public GameObject fundo;
    public GameObject frente;
    public int indice = 0;


    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("Nivel",0);
        MudaPalavra();
    }

    //Aumenta o tamanho da string da frente
    public void Acertou()
    {
        frente.GetComponent<Text>().text += palavraAtual[indice];
        indice++;
        if(palavraAtual == frente.GetComponent<Text>().text)
        {
            MudaPalavra();
        }

    }
        //Altera a palavra que deve ser preenchida
        public void MudaPalavra()
    {
        string aux = palavraAtual;
        PlayerPrefs.SetInt("Nivel", PlayerPrefs.GetInt("Nivel")+1);
        palavraAtual = Palavras[Random.Range(0, Palavras.Count)];
        //Verificar se as palavras aleatórias não são iguais
        if (aux==palavraAtual && Palavras.Count > 1)
        {
            MudaPalavra();
        }
        fundo.GetComponent<Text>().text = palavraAtual;
        frente.GetComponent<Text>().text = "";
        indice = 0;

    }

}
