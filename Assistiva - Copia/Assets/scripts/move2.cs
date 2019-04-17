using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour {

    public CarregarCena3 vel = new CarregarCena3();
    public float a;
    public GameObject Quad;
    public GameObject palavra;
    public GameObject Letra;
    private float x;
    private float y;
    public char l;
    // Update is called once per frame
    void Start()
    {
        palavra = GameObject.FindGameObjectWithTag("Palavra");
        int i = Random.Range(0, 100);
        if ( i>= 75 && i<95)
        {
            l = palavra.GetComponent<EscolhePalavra>().palavraAtual[palavra.GetComponent<EscolhePalavra>().indice];
        }
        else if(i<75)
        {
            l = System.Convert.ToChar(Random.Range(65, 90));

        }
        else
        {       
            ///CRIAR CORINGA
            l = '♥';
            gameObject.tag = "Coringa";
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            Letra.GetComponent<TextMesh>().color = Color.red;
            Letra.GetComponent<TextMesh>().fontSize = 80;


        }
        Letra.GetComponent<TextMesh>().text = ""+l;

    }

    void Update () {
        x = transform.position.x;
        x -= a * Time.deltaTime;
        ///DAR UMA VISÃO 3D PARA OS SPRITES
        transform.position = new Vector3(x,transform.position.y,transform.position.y);

        if (x < -12.52f)
        {
            Destroy(transform.gameObject);
        }
    }

}
