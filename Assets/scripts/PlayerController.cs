using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public GameObject player;
    public GameObject palavra;
    public float maxHeight;
    public float minHeight;
    public float maxLargura;
    public float minLargura;
    public float speed;
    public float speedLateral;
    public int[] estilos = new int[3];
    private int estilo;
    private float x;
    public char str;
    public Camera kamera;
    public int movimentacao = 0;
    Vector3 posicaoMouse;
    float rotationInicialX, rotationInicialY;
    AudioSource audio;
    int off = 1;
    public Text erros;
    private int erroNum = 0;
    private int erroMax;



    private void Start() {
        //Setar o estilo do jogador
        erroMax = PlayerPrefs.GetInt("erro");
        Debug.Log("ErroMax: " + erroMax);
        estilo = PlayerPrefs.GetInt("estiloPersonagem");
        gameObject.GetComponentInChildren<Animator>().Play(("" + (estilo + 1)));
        kamera = FindObjectOfType<Camera>();
        posicaoMouse = player.transform.position;
        audio = GetComponent<AudioSource>();
        erros = GameObject.Find("Erros").GetComponent<Text>();
        erros.GetComponent<Text>().text = "Erros: " + erroNum;
    }

    void SetMovimentacao(int idMovimento) {
        movimentacao = idMovimento;
    }
    void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            SceneManager.LoadScene(0);

        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            off = 0;
        }

        ///MOVIMENTAÇÃO PELO TECLADO
        if (movimentacao == 0 || movimentacao > 2) {

            float translation = Input.GetAxis("Vertical") * speed;
            float translation2 = Input.GetAxis("Horizontal") * speedLateral;
            translation *= Time.deltaTime;
            translation2 *= Time.deltaTime;
            transform.Translate(translation2, translation, 0);
            float newPos = player.transform.position.y;

            if (transform.position.y > maxHeight) {
                player.transform.position = new Vector2(player.transform.position.x, maxHeight);
            }
            if (transform.position.y < minHeight) {
                player.transform.position = new Vector2(player.transform.position.x, minHeight);
            }

            //Define os limites do movimento de acordo com o tamanho da tela
            if (kamera.WorldToScreenPoint(player.transform.position).x > kamera.scaledPixelWidth) {

                player.transform.position = new Vector2(player.transform.position.x - 0.15f, player.transform.position.y);

            }
            if (kamera.WorldToScreenPoint(player.transform.position).x < 0) {

                player.transform.position = new Vector2(player.transform.position.x + 0.15f, player.transform.position.y);

            }

        } else if (movimentacao == 1) {

            ////MOVIMENTACAO PELO TOQUE
            if (kamera.ScreenToWorldPoint(Input.mousePosition).x > -8.1 && kamera.ScreenToWorldPoint(Input.mousePosition).x < 8.1) {

                if (kamera.ScreenToWorldPoint(Input.mousePosition).y > minHeight - 0.5f) {
                    if (kamera.ScreenToWorldPoint(Input.mousePosition).y < maxHeight) {
                        posicaoMouse = kamera.ScreenToWorldPoint(Input.mousePosition);

                    }
                }

            }
            player.transform.position = Vector2.MoveTowards(player.transform.position, posicaoMouse, speed * 2 * Time.deltaTime);
        } else if (movimentacao == 2) {
            ///MOVIMENTACAO PELO GIROSCOPIO
            float deltaRotationX, deltaRotationY;
            deltaRotationX = rotationInicialX - GyroToUnity(Input.gyro.attitude).eulerAngles.x;
            deltaRotationY = rotationInicialY - GyroToUnity(Input.gyro.attitude).eulerAngles.y;
            player.transform.position = Vector2.MoveTowards(player.transform.position, new Vector2(player.transform.position.x + deltaRotationX, player.transform.position.y + deltaRotationY), speed * 2 * Time.deltaTime);


        }
        ///DAR UMA VISÃO 3D PARA OS SPRITES
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.y);
    }

    private static Quaternion GyroToUnity(Quaternion q) {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }



    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Quad") {
            string palavraAtual = palavra.GetComponent<EscolhePalavra>().palavraAtual;
            char letraColisao = collision.gameObject.GetComponent<move2>().l;
            if (palavra.GetComponent<EscolhePalavra>().Acertou(letraColisao)) {
                
                if (off == 1) {
                    audio.Play();
                }
                Destroy(collision.gameObject);

            } else {
                erroNum++;
                if (erroNum == erroMax) {
                    SceneManager.LoadScene(2);
                } else {
                    collision.gameObject.GetComponent<Collider2D>().enabled = false;
                    collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    erros.GetComponent<Text>().text = "Erros: " + erroNum;
                }
            }
        }
        if (collision.gameObject.tag == "Coringa") {
            if (off == 1) {
                audio.Play();
            }
            palavra.GetComponent<EscolhePalavra>().Acertou('♥');
            Destroy(collision.gameObject);
        }
    }
}
