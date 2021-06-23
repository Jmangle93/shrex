using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooberPickupSound : MonoBehaviour
{
    public AudioSource pickupSource;
    public void start()
    {
        pickupSource = GetComponent<AudioSource>();
    }

    public void play()
    {
        pickupSource.Play();
    }
}
