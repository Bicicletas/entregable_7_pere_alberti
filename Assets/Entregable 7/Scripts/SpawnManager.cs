using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabs;
    private int randomIndex;
    private float startTime = 2f;
    private float repeatRate = 1.5f;
    //variable para girar los gameObjects q se spawneen en el lado izquierdo de la pantalla
    private Quaternion offset = Quaternion.Euler(0, 180, 0);
    public PlayerController PlayerController;

    void Start()
    {
        PlayerController = FindObjectOfType<PlayerController>();
        //Espawnea de manera seguida los objetos instanciados en la funcion SpawnObject
        InvokeRepeating("SpawnObject", startTime, repeatRate);
    }

    private void SpawnObject()
    {
        //variable random q se dediaca a decidir si sale 0 o 1 va a spawnear los prefabs a un lado o a otro
        float randomSide = Random.Range(0, 2);
        //escoje de manera random un prefab guardados en la variable randomIndex
        randomIndex = Random.Range(0, prefabs.Length);

        if (PlayerController.GameOver == true)
        {
            CancelInvoke();
        }

        if (randomSide == 0)
        {
            float yRange = Random.Range(1f, 14f);
            float xRange = 16f;
            //variable q guarda la posicion de espawneo del lado derecho
            Vector3 spawnPos = new Vector3(xRange, yRange, 0);
            Instantiate(prefabs[randomIndex], spawnPos, prefabs[randomIndex].transform.rotation);
        }
        else
        {
            float yRange = Random.Range(1f, 14f);
            float xRange = 16f;
            //variable q guarda la posicion de espawneo del lado izquierdo
            Vector3 spawnPos = new Vector3(-xRange, yRange, 0);
            Instantiate(prefabs[randomIndex], spawnPos, prefabs[randomIndex].transform.rotation * offset);
        }
    }
}
