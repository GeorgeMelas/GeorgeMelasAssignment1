using UnityEngine;
using System.Collections;

public class ClickerSound : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip audioClip;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void ClickFunction()
    {
        audioSource.clip = audioClip;       // Plays the audioClip when you press on the button.
        audioSource.Play();                 // Plays it.
    }
}
