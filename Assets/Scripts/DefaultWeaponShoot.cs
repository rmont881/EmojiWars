using UnityEngine;
using System.Collections;

public class DefaultWeaponShoot : MonoBehaviour {
	public GameObject projectile;
	public float projectile_force;
	public float projectile_cooldown;

	private float player_id;
	private float cooldown_counter;
	// Use this for initialization
	void Start () {
		cooldown_counter = 0.0f;
		player_id = GetComponent<UnityStandardAssets._2D.Platformer2DUserControl> ().controller_id;
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldown_counter <= 0.0f) {
			if (Input.GetKey (KeyCode.L)) {
				// Find direction being faced
				float dir = transform.localScale.x / Mathf.Abs (transform.localScale.x); 
				cooldown_counter = projectile_cooldown;
				GameObject instance = GameObject.Instantiate (projectile);
				instance.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (dir * projectile_force, 0.0f));
				instance.transform.position = transform.position;
				instance.layer = LayerMask.NameToLayer ("ProjectileTeam"+player_id.ToString());
			}
		} else {
			cooldown_counter -= Time.deltaTime;
		}
	}
}
