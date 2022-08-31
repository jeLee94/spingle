using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class Hammer : MonoBehaviour
{
    
    public ParticleSystem thinStars;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("target"))
        {
            Debug.Log("내리쳐따");
            thinStars.Play();
        }
    }

}
