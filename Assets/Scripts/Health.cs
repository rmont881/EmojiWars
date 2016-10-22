using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float max_health;
	public Sprite death_sprite_sheet;

	private Transform health_bar;
	private float current_health;
	private float original_scale;
	// Use this for initialization
	void Start () {
		current_health = max_health;
		health_bar = transform.parent.FindChild ("HealthBar").FindChild("Bar");
		original_scale = health_bar.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void modify_health_by(float value){
		current_health += value;
		if (current_health <= 0.0f) {
			current_health = 0.0f;
			print ("Set");
			GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D> ().m_Anim.SetBool("Dead",true);
		}
		health_bar.localScale = new Vector3(current_health *original_scale/ max_health,health_bar.localScale.y,health_bar.localScale.z);
	}

}
