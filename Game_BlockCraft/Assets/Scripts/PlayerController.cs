using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float speed = 16.0f;

	void Update()
	{
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		Vector2 movement = input.normalized * speed;
		Vector2 deltaMovement = movement * Time.deltaTime;

		transform.position += new Vector3(deltaMovement.x, deltaMovement.y);
	}
}
