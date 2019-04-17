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
    public move2 speed;

    // Use this for initialization
    public void Menu()
    {
        if(index == 1)
        {
            SceneManager.LoadScene(1);

        }
    }

}
