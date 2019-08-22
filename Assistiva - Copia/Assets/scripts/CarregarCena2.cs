using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;
using System.Text;

public class CarregarCena3 : MonoBehaviour
{
    public int index;
    public float speed;
    public GameObject quad;
    public float a;



    // Use this for initialization
    public void Menu2()
    {
        speed = 0.5f;
        Debug.Log("chegou");
        index = 1;
        if (index == 1)
        {
            PlayerPrefs.SetFloat("speed", 0.05f);
            //Debug.Log(PlayerPrefs.GetFloat("speed"));
        }
        /*else
        {
            if (index == 2)
            {
                SceneManager.LoadScene(1);
                speed = 0.1f;
            }
            else
            {
                if (index == 3)
                {
                    SceneManager.LoadScene(1);
                    speed = 0.2f;
                }
            }
        }*/
    }
}
