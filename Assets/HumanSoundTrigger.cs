using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanSoundTrigger : MonoBehaviour {


	List<GameObject> fingers = new List<GameObject>();

	public List<AudioSource> soundList = new List<AudioSource>();
	public IdleChanger idleChanger;

	//public AnimationClip[] animations;

	public FaceUpdate faceAnim;

	Animator anim;

	int index = 0;
	bool playing = false;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SoundCallBack()
	{
		playing = false;

		faceAnim.faceAnimation = false;
		fingers.Clear ();
		
	}


	void TriggerPlaySound()
	{
		if (playing)return;

		soundList [index].Play ();

		playing = true;
		faceAnim.faceAnimation = true;
		idleChanger.ChangeAnimate = true;
		Invoke ("SoundCallBack",soundList [index].clip.length);


		index++;
		index = index % soundList.Count;
	}



	void OnTriggerEnter(Collider other) {

		//Debug.Log ("Trigger Touched:"+other.gameObject.name);

		//Debug.Log (LayerMask.LayerToName (other.gameObject.layer));

		if (other.gameObject.layer == LayerMask.NameToLayer ("Finger")) 
		{
			fingers.Add(other.gameObject);

			if(fingers.Count == 1)
			{
				TriggerPlaySound();
			}
		}
	}

	void OnTriggerExit(Collider other) {

		if (other.gameObject.layer == LayerMask.NameToLayer ("Finger")) 
		{
			fingers.Remove(other.gameObject);

			if(fingers.Count == 0)
			{
				
			}
		}
	}

}
