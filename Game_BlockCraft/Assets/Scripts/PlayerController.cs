using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float speed = 16.0f;

	private Rigidbody2D rb = null;

	public void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public void Update()
	{
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		Vector2 movement = input.normalized * speed;
		Vector2 deltaMovement = movement * Time.deltaTime;

		//transform.position += new Vector3(deltaMovement.x, deltaMovement.y);
		rb.AddForce(deltaMovement);
	}
}
