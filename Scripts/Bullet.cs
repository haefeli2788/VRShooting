using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;

    [SerializeField] ParticleSystem hitParticlePrefab;

    void Start()
    {
        var velocity = speed * transform.forward;

        GetComponent<Rigidbody>().AddForce(velocity, ForceMode.VelocityChange);
    }

        void OnTriggerEnter(Collider other)
        {
            other.SendMessage("OnHitBullet");

            Instantiate(hitParticlePrefab, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }

