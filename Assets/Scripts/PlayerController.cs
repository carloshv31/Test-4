using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody playerRigidBody;
    private GameObject focalPoint;
    private float powerupStrenght = 15f;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;

    public ParticleSystem explosionParticle;
    //public ParticleSystem dirtParticle;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        //playerRigidBody.AddForce(focalPoint.transform.forward * forwardInput * speed);
        playerRigidBody.AddForce(focalPoint.transform.forward * forwardInput * speed * Time.deltaTime, ForceMode.VelocityChange);


        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);

            AudioManager.Instance.PlaySFX("Powerup");

            // Llamamos la corrutina que creamos para que se active cuando el jugador colecte el poder
            StartCoroutine(PowerupCountdownRoutine());
        }

        // Necesitamos que el juego detecte que el jugador perdió, por lo que haremos que muestre la pantalla de Game Over cuando la bola colisione con el trigger del sensor
        // El jugador funciona con el sensor mientras que los enemigos desaparecen cuando su posición en y es menor a -10

        if (other.gameObject.CompareTag("Sensor"))
        {
            //Destroy(gameObject);
            GameManager.Instance.GameOver();
            AudioManager.Instance.PlaySFX("Death");
            explosionParticle.Play();

            //AudioManager.Instance.musicSource.Stop();
        }
    }

    // Utilizamos una corrutina con un IEnumerator para que retorne el valor de hasPowerup a falso luego de pasados 7 segundos
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !hasPowerup)
        {
            AudioManager.Instance.PlaySFX("Hit");
        }

        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRigidBody.AddForce(awayFromPlayer * powerupStrenght, ForceMode.Impulse);
            
            AudioManager.Instance.PlaySFX("Collision");

            // Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }
}
