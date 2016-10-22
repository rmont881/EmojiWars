using UnityEngine;
using System.Collections;

public class DefaultProjectile : MonoBehaviour {
	public float damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		print ("Success");
		print (collision.transform.tag);
		if (collision.transform.tag == "Player") {
			collision.gameObject.GetComponent<Health> ().modify_health_by (-damage);
		}
		Destroy (gameObject);
	}
}
