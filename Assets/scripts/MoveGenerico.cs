using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGenerico : MonoBehaviour {
    private float x;
    private float y;
    public float a = 5;
    void Update()
    {
        x = transform.position.x;
        x -= 2f * a * Time.deltaTime;
        ///DAR UMA VISÃO 3D PARA OS SPRITES
        transform.position = new Vector3(x, transform.position.y, transform.position.y);

        if (x < -22.52f)
        {
            Destroy(transform.gameObject);
        }
    }
}
