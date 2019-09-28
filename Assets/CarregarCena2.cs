using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;
using System.Text;

public class CarregarCena2 : MonoBehaviour
{
    public int index;


    // Use this for initialization
    public void Menu2()
    {
        if (index == 1)
        {
            PlayerPrefs.SetInt("Nivel", 1);
            SceneManager.LoadScene(1);
        }
        else
        {
            if (index == 2)
            {
                PlayerPrefs.SetInt("Nivel", 2);
                SceneManager.LoadScene(1);
            }
            else
            {
                if (index == 3)
                {
                    PlayerPrefs.SetInt("Nivel", 3);
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
}
