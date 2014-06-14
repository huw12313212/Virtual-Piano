using UnityEngine;
using System.Collections;

public class FaceUpdate : MonoBehaviour
{
	public AnimationClip[] animations;
	public AnimationClip[] talkAnimation;


	Animator anim;

	public float delayWeight;

	void Start ()
	{
		anim = GetComponent<Animator> ();
	}

	void OnGUI ()
	{
		/*
		foreach (var animation in animations) {
			if (GUILayout.Button (animation.name)) {
				anim.CrossFade (animation.name, 0);
			}
		}*/
	}

	float current = 0;

	public bool faceAnimation = false;

	public bool FlipFlop = false;

	int index = 0;

	void Update ()
	{

		if (faceAnimation) {

			if(current>0.95)
			{
				FlipFlop = false;
			}
			else if(current < 0.05)
			{
				FlipFlop = true;
				
				anim.CrossFade (talkAnimation[index].name, 0);

				index++;

				index = index % talkAnimation.Length;
			}

			if(FlipFlop)
			{
				current = Mathf.Lerp (current, 1, delayWeight);
			}
			else
			{
				current = Mathf.Lerp (current, 0, delayWeight);
			}



		} else {
			current = Mathf.Lerp (current, 0, delayWeight);
		}
		anim.SetLayerWeight (1, current);
	}
}
