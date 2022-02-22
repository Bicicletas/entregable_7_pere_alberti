using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    [SerializeField] private float force = 10f;
    private GameObject bomb;
    private GameObject coin;
    private float yLim = 14f;
    private bool enableJump = true;
    private float recolectable = 0;
    public ParticleSystem fireworks;
    public ParticleSystem explosion;
    private AudioSource playerAudioSource;
    public AudioClip destruccion;
    public AudioClip salto;
    public AudioClip moneda;
    public AudioClip musica;
    public bool GameOver;

    void Start()
    {
        GameOver = false;
        //encuentra variables por codigo
        coin = GameObject.Find("money");
        bomb = GameObject.Find("Bomb");
        playerRB = GetComponent<Rigidbody>();
        playerAudioSource = GetComponent<AudioSource>();
        //activa el sonido de musica al darle a play
        playerAudioSource.PlayOneShot(musica, 0.25f);
    }

    void Update()
    {
        //si se presiona el espacio y enable jump esta en "true" se añade una fuerza hacia arriba al player y se activa un sonido
        if (Input.GetKeyDown(KeyCode.Space) && enableJump == true && GameOver == false)
        {
            playerRB.AddForce(Vector3.up * force, ForceMode.Impulse);
            // playerAudioSource.PlayOneShot(salto, 1f);
        }
        //si llegas a un limite no puedes segir subiendo
        if (transform.position.y >= yLim)
        {
            transform.position = new Vector3(transform.position.x, yLim, transform.position.z);
            enableJump = false;
        }
        else
        {
            enableJump = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Este if detecta si se colisiona contra una moneda
        if (collision.gameObject.CompareTag("Money"))
        {
            //añade 1 moneda a los recolectables
            recolectable++;
            //destruye la moneda
            Destroy(collision.gameObject);
            //envia un mensaje por consola
            Debug.Log($"Tienes {recolectable} monedas");
            //instancia una particula
            Instantiate(fireworks, transform.position, transform.rotation);
            //activas un sonido
            playerAudioSource.PlayOneShot(moneda, 1f);
        }
        if (collision.gameObject.CompareTag("Bomb"))
        {
            GameOver = true;
            //destruye la bomba
            Destroy(collision.gameObject);
            //envia un mensaje por consola
            Debug.Log("GAME OVER");
            //instancia una particula
            Instantiate(explosion, transform.position, transform.rotation);
            //activas un sonido
            playerAudioSource.PlayOneShot(destruccion, 1f);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            //detiene el juego
            GameOver = true;
            //envia un mensaje por consola
            Debug.Log("GAME OVER");
            //desactivas un sonido
            playerAudioSource.Pause();
        }
    }
    private void OnDestroy()
    {
        //desactivas un sonido una vez sze destruya el player
        playerAudioSource.Pause();
    }
}
