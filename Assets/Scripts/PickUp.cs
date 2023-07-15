using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    public static event Action OnPickupGrabbed;
    AudioSource _audio;

    protected bool isActive = true;

    void Start()
    {
        _audio = GetComponentInChildren<AudioSource>();
    }

    protected void usePickUp()
    {
        OnPickupGrabbed?.Invoke();
        Debug.Log("Grabbed!");
    }

    protected abstract void DoStuff();


    void OnTriggerEnter(Collider other)
    {
        if(isActive && other.gameObject.tag == "Player")
        {
            usePickUp();
            _audio.Play();
            GetComponentInChildren<MeshRenderer>().enabled = false;
            DoStuff();
            isActive = false;
        }
    }
    
    void Update()
    {
        if(!isActive && !_audio.isPlaying)
        {
            Destroy(gameObject);
        }
    }

}
