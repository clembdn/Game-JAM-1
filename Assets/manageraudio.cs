using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageraudio : MonoBehaviour
{
    public AudioClip[] audioClip;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audioClip[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
