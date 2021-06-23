using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooberPickupSound : MonoBehaviour
{
    public AudioSource pickupSource;
    public void start()
    {
        pickupSource = FindObjectOfType<AudioSource>();
    }

    public void play()
    {
        if (gameObject != null)
        {
            AudioSource.PlayClipAtPoint(pickupSource.clip, transform.position);
        }
    }
}
