using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float radius = 5.0f;
    public float force = 30.0f;
    public GameObject explosionEffect;
    public AudioSource source;
    public AudioClip clip;

    //private float countdown;
    //public float delay = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        //countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
       // countdown -= Time.deltaTime;
       // if (countdown <= 0.0f)
        //{
        //    Explode();
       // }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        //Destroy(launchParticles);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

            PlayerHealth playerHealth = nearbyObject.GetComponent<PlayerHealth>();

            if (nearbyObject.CompareTag("Player"))
            {
                PlayerSwitcher.GM.Damage();

                //Damage to Player
                int damage = (int)Math.Round(force / 2);

                //playerHealth.currentHealth = playerHealth.currentHealth - damage;
                playerHealth.TakeDamage(damage);
                
                source.PlayOneShot(clip);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Explode();
        Destroy(gameObject, 0.1f);
    }
}
