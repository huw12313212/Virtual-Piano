using UnityEngine;
using System.Collections;

public class ClickSound : MonoBehaviour {

	public AudioSource audioSource;

	bool clicked = false;

	int  ThreashHoldZ = 1;

	// Use this for initialization
	void Start () {
	
		audioSource = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (!clicked&&transform.localRotation.eulerAngles.z > 1) 
		{
			clicked = true;

			audioSource.Play();
		}
		else if(clicked&&transform.localRotation.eulerAngles.z <= 1)
		{
			clicked = false;
			
			audioSource.Stop();
		}


	}
}
