using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public CarSO CarStat;
    private float carSpeed;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale *= CarStat.CarSize;
        carSpeed = CarStat.CarSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(carSpeed * Time.deltaTime, 0, 0);
        CheckPosition();
    }

    private void CheckPosition()
    {
        if (this.transform.position.x < -25f || this.transform.position.x > 25f) 
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Hit();
        }
    }
}
