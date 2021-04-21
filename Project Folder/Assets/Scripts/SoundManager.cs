using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static AudioSource audioSrc;
    [SerializeField] AudioClip click;
    [SerializeField] AudioClip play;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayClick()
    {
        audioSrc.clip = click;
        audioSrc.Play();
    }
    public void PlayCardSound()
    {
        audioSrc.clip = play;
        audioSrc.Play();
    }
}
