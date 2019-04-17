using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject palavra;
    public float maxHeight;
    public float minHeight;
    public float maxLargura;
    public float minLargura;
    public float speed;
    public float speedLateral;
    private float x;
    public char str;
    public Camera kamera;
    private void Start()
    {
        kamera = FindObjectOfType<Camera>();
    }
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float translation2 = Input.GetAxis("Horizontal") * speedLateral;
        translation *= Time.deltaTime;
        translation2 *= Time.deltaTime;
        transform.Translate(translation2, translation, 0);
        float newPos = player.transform.position.y;

        if (transform.position.y > maxHeight)
        {
            player.transform.position = new Vector2(player.transform.position.x, maxHeight);
        }
        if (transform.position.y < minHeight)
        {
            player.transform.position = new Vector2(player.transform.position.x, minHeight);
        }

        //Define os limites do movimento de acordo com o tamanho da tela
        if (kamera.WorldToScreenPoint(player.transform.position).x>kamera.scaledPixelWidth)
        {

            player.transform.position = new Vector2(player.transform.position.x-0.15f, player.transform.position.y);

        }
        if (kamera.WorldToScreenPoint(player.transform.position).x < 0)
        {

            player.transform.position = new Vector2(player.transform.position.x + 0.15f, player.transform.position.y);

        }
        ///DAR UMA VISÃO 3D PARA OS SPRITES
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Quad")
        {
            if (palavra.GetComponent<EscolhePalavra>().palavraAtual[palavra.GetComponent<EscolhePalavra>().indice]== collision.gameObject.GetComponent<move2>().l)
            {
                palavra.GetComponent<EscolhePalavra>().Acertou();
            }
                 Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.tag == "Coringa")
        {
            palavra.GetComponent<EscolhePalavra>().Acertou();
            Destroy(collision.gameObject);
        }
    }
}
