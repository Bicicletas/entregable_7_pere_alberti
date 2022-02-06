using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 5f;
    private float xRange = 16f;

    void Update()
    {
        //mover los objetos q tengan el script siempre a la izquierda
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        //los dos if sirven para destruir los prefabs que salgan de la pantalla
        if (transform.position.x < -xRange)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > xRange)
        {
            Destroy(gameObject);
        }
    }
}
