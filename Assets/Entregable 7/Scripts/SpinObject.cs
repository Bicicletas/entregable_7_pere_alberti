using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public float spinSpeed;
    
    void Update()
    {
        //rota un objeto en el eje y
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
