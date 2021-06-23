using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusicTrigger : MonoBehaviour
{
    public AudioClip newTrack;
    private AudioManager manager;
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && newTrack != null)
        {
            manager.ChangeBackgroundMusic(newTrack);
        }
    }
}
