using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public AudioClip Clip;

    public void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.CompareTag("Car")){
            Destroy(gameObject);
            FuelCounter car_counter = other.GetComponent<FuelCounter>();
            car_counter.Count();
            SFXPlayer.PlaySound(Clip);
        }
    }
}
