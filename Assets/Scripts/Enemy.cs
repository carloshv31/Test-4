using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRigidBody;
    private GameObject player;

    public ParticleSystem enemyExplosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        //enemyRigidBody.AddForce(lookDirection * speed);
        enemyRigidBody.AddForce(lookDirection * speed * Time.deltaTime, ForceMode.VelocityChange);



        //if (transform.position.y < -10)
        //{
        //    Instantiate(enemyExplosionParticle.gameObject, transform.position, enemyExplosionParticle.transform.rotation);
        //    AudioManager.Instance.PlaySFX("Enemy Death");
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sensor"))
        {
            Instantiate(enemyExplosionParticle.gameObject, transform.position, enemyExplosionParticle.transform.rotation);
            AudioManager.Instance.PlaySFX("Enemy Death");
            Destroy(gameObject);
        }
    }
}
