using UnityEngine;
using System.Collections;

public class HealthBarPositioner : MonoBehaviour {
	public float x_offset;
	public float y_offset;
	private Transform health_bar;
	private Transform player;
	// Use this for initialization
	void Start () {
		player = transform.FindChild ("CharacterRobotBoy");
		health_bar = transform.FindChild ("HealthBar");
	
	}
	
	// Update is called once per frame
	void Update () {
		health_bar.transform.position = new Vector3 (player.position.x+x_offset, player.position.y + y_offset, player.position.z);
	}
}
