using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class EscolhePalavra : MonoBehaviour {
    public List<string> Palavras = new List<string>();
    public string palavraAtual = "";
    public GameObject fundo;
    public GameObject frente;
    public int indice;
    public GameObject MostradorNivel;
    public string aux;
    public string PalavraChar;
    public string PalavraCharFrente;
    public bool flag = false;
    public GameObject aviao;
    public GameObject boneco;
    public GameObject ceu;
    public List<Color> cores;
    public char characterLayout = '*';
    private int indeceCor;
    private bool flagCor = false;
    private float speed = 0;


    // Use this for initialization
    void Start() {
        indeceCor = 0;
        cores.Add(Color.white);
        cores.Add(Color.magenta);
        cores.Add(new Color(255, 0, 84));
        cores.Add(new Color(7, 117, 142));
        cores.Add(new Color(255, 70, 0));

        //cores.Add(Color.magenta);

        PlayerPrefs.SetInt("Nivel", 0);
        MudaPalavra(false);
    }

    //Aumenta o tamanho da string da frente
    public bool Acertou(char letra) {
        int indexProxLetra = -1;
        if (letra == '♥') {
            indexProxLetra = new List<char>(PalavraChar.ToCharArray()).FindIndex(x => x == characterLayout);
        } else if (palavraAtual.Contains(letra.ToString())) {
            int count = 0;
            while (true) {
                indexProxLetra = new List<char>(palavraAtual.ToCharArray()).FindIndex(count, x => x == letra);
                count = indexProxLetra + 1;
                if (count > palavraAtual.Length || count <= 0) {
                    indexProxLetra = -1;
                    break;
                }
                Debug.Log(string.Format("Letra: {0} Index: {1}", palavraAtual[indexProxLetra], indexProxLetra));
                if (PalavraChar[indexProxLetra] == characterLayout) {
                    break;
                }
            }
        }

        if (indexProxLetra >= 0 && indexProxLetra < palavraAtual.Length) {
            PalavraCharFrente = PalavraCharFrente.Substring(0, indexProxLetra) + palavraAtual[indexProxLetra] + PalavraCharFrente.Substring(indexProxLetra + 1);
            frente.GetComponent<Text>().text = PalavraCharFrente;

            PalavraChar = PalavraChar.Substring(0, indexProxLetra) + palavraAtual[indexProxLetra] + PalavraChar.Substring(indexProxLetra + 1);
            if (palavraAtual == PalavraCharFrente) {
                MudaPalavra(false);
            }
            return true;
        }
        return false;
    }
    //Altera indice palavra que deve ser preenchida
    public void MudaPalavra(bool jaChamou) {
        if (jaChamou == false) {
            PlayerPrefs.SetInt("Nivel", PlayerPrefs.GetInt("Nivel") + 1);
            MostradorNivel.GetComponent<Text>().text = "↑" + PlayerPrefs.GetInt("Nivel");
            if (flagCor == true) {
                ceu.GetComponent<SpriteRenderer>().color = cores[(indeceCor + 1) % cores.Count];
                indeceCor = (indeceCor + 1) % cores.Count;
            }
            flagCor = true;
            if (boneco.transform.localScale.x < 1.6f) {
                boneco.transform.localScale = new Vector2(boneco.transform.localScale.x + 0.075f, boneco.transform.localScale.y + 0.075f);
            }
            Instantiate(aviao);
        }
        aux = palavraAtual;
        palavraAtual = Palavras[UnityEngine.Random.Range(0, Palavras.Count)];
        //Verificar se as palavras aleatórias não são iguais
        if (aux == palavraAtual && Palavras.Count > 1) {
            MudaPalavra(true);
        }


        // fundo.GetComponent<Text>().resizeTextMaxSize= frente.GetComponent<Text>().fontSize    ;

        PalavraChar = new StringBuilder(palavraAtual.Length).Append(characterLayout, palavraAtual.Length).ToString();
        PalavraCharFrente = new StringBuilder(palavraAtual.Length).Append(' ', palavraAtual.Length).ToString();
        speed = PlayerPrefs.GetFloat("speed") + .2f;//PlayerPrefs.GetFloat("inc");

        frente.GetComponent<Text>().text = "";
        fundo.GetComponent<Text>().text = palavraAtual;
        indice = 0;
        PlayerPrefs.SetFloat("speed", speed);
        Debug.Log("Speed muda palavra:" + speed);

    }

}
