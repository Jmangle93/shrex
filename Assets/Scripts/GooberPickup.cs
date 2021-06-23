using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooberPickup : MonoBehaviour
{
    public GameObject pickupEffect;
    public int gooberValue;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<GooberPickupSound>().play();
            FindObjectOfType<GameManager>().AddGoober(gooberValue);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
