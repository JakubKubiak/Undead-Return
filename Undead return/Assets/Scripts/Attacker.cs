using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("liczba sekund miedzy pojawianiem sie")]
	public float seenEverySeconds;
	private float currentSpeed;
	private	 GameObject currentTarget;
	private Animator animator;
	
	void Start () {
		animator = GetComponent<Animator>();
	}

	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool ("isAttacking", false);
		}
	}
	
	void OnTriggerEnter2D () {
		
	}
	
	public void SetSpeed (float speed) {
		currentSpeed = speed;
	}
	
	// Called from the animator at time of actual blow
	public void  StrikeCurrentTarget (float damage) {
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage (damage);
			}
		}
	}
	
	public void Attack (GameObject obj) {
		currentTarget = obj;
	}
}
