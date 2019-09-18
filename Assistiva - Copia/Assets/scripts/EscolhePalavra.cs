using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EscolhePalavra : MonoBehaviour {
    public List<string> Palavras = new List<string>();
    public string palavraAtual = "";
    public GameObject fundo;
    public GameObject frente;
    public int indice;
    public GameObject MostradorNivel;
    public string aux;
    public List<char> PalavraChar;
    public List<char> PalavraCharFrente;
    public bool flag = false;
    public GameObject aviao;
    public GameObject boneco;
    public GameObject ceu;
    public List<Color> cores;
    private int  indeceCor;
    private bool flagCor=false;
    private float speed = 0;


    // Use this for initialization
    void Start()
    {
        indeceCor = 0;
        cores.Add(Color.white);
        cores.Add(Color.magenta);
        cores.Add(new  Color(255,0,84));
        cores.Add(new Color(7, 117, 142));
        cores.Add(new Color(255, 70, 0));

        //cores.Add(Color.magenta);

        PlayerPrefs.SetInt("Nivel",0);
        MudaPalavra(false);
    }

    //Aumenta o tamanho da string da frente
    public void Acertou(int indiceA,int indiceP)
    {

        if(indiceA==-1 && indiceP == -1)
        {
            indiceA = 0;
            indiceP = palavraAtual.IndexOf(PalavraChar[indiceA]);
        }
      

        PalavraCharFrente[indiceP]= PalavraChar[indiceA];
        frente.GetComponent<Text>().text = "";
        foreach (char i in PalavraCharFrente)
        {
            frente.GetComponent<Text>().text +=""+i;

        }

        PalavraChar.RemoveAt(indiceA);
        if (palavraAtual == frente.GetComponent<Text>().text)
        {
            MudaPalavra(false);
        }

    }
        //Altera indice palavra que deve ser preenchida
    public void MudaPalavra(bool jaChamou)
    {
        if (jaChamou == false)
        {
            PlayerPrefs.SetInt("Nivel", PlayerPrefs.GetInt("Nivel") + 1);
            MostradorNivel.GetComponent<Text>().text = "↑" + PlayerPrefs.GetInt("Nivel");
            if (flagCor == true)
            {
                ceu.GetComponent<SpriteRenderer>().color = cores[(indeceCor + 1) % cores.Count];
                indeceCor = (indeceCor + 1) % cores.Count;
            }
            flagCor = true;
            if (boneco.transform.localScale.x < 1.6f)
            {
                boneco.transform.localScale = new Vector2(boneco.transform.localScale.x + 0.075f, boneco.transform.localScale.y + 0.075f);
            }
            Instantiate(aviao);
        }
        aux = string.Copy(palavraAtual);
        palavraAtual = Palavras[UnityEngine.Random.Range(0, Palavras.Count)];
        //Verificar se as palavras aleatórias não são iguais
        if (aux==palavraAtual && Palavras.Count > 1)
        {
            MudaPalavra(true);
        }


        // fundo.GetComponent<Text>().resizeTextMaxSize= frente.GetComponent<Text>().fontSize    ;

        PalavraChar.Clear();
        PalavraChar.AddRange(palavraAtual);
        PalavraCharFrente.Clear();
        speed = PlayerPrefs.GetFloat("speed") + 0.2f;//PlayerPrefs.GetFloat("inc");
        foreach (char i in palavraAtual)
        {
            PalavraCharFrente.AddRange(" ");
        }
        frente.GetComponent<Text>().text= "";
        fundo.GetComponent<Text>().text = palavraAtual;
        indice = 0;
        PlayerPrefs.SetFloat("speed", speed);
        Debug.Log("Speed muda palavra:"+speed);
        
    }

}
