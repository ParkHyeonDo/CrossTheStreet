using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCracker : MonoBehaviour
{
    ParticleSystem particle;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            particle.Play();
            Destroy(gameObject, particle.main.duration);
        }
    }
}
