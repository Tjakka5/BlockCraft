using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float speed = 16.0f;

	[SerializeField]
	private Tilemap tilemap = null;

	[SerializeField]
	private TileBase tile = null;

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

		if (Input.GetButtonDown("Fire1"))
			tilemap.SetTile(MouseToTile(), null);

		if (Input.GetButtonDown("Fire2"))
			tilemap.SetTile(MouseToTile(), tile);
	}

	private Vector3Int MouseToTile()
	{
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3Int tilePosition = new Vector3Int(Mathf.FloorToInt(mousePosition.x), Mathf.FloorToInt(mousePosition.y), 0);

		return tilePosition;
	}
}
