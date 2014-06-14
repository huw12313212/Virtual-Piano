using UnityEngine;
using System.Collections;

public class FireBallShooter : MonoBehaviour {

	public GameObject FireBall;
	public UISlider mpSlider;

	static public float MP = 100;
	static public float MP_FULL = 100;
	static public float FIRE_BALL_MP = 30;
	static public float MP_Revive = 1;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



	

			if (MP >= FIRE_BALL_MP) {
				if (Input.GetKeyDown ("space")) {

				MP-=FIRE_BALL_MP;
								GameObject fireBall = GameObject.Instantiate (FireBall) as GameObject;

								fireBall.transform.position = this.transform.position;

								FireBallScript script = fireBall.GetComponent<FireBallScript> ();

								script.Velicity = this.transform.forward * 20;
						}

				}

	}
}
