using UnityEngine;

public class Representation : MonoBehaviour {
	private Representable master;

	private float z;
	private SpriteRenderer spriteRenderer;

	void Start() {
		z = 0f;
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update() {
		if (master == null) {
			return;
		}

		transform.position = master.GetRepresentationPosition();
		transform.eulerAngles = master.GetRepresentationEulerRotation();
		spriteRenderer.sprite = master.GetRepresentationSprite();
	}

	public void SetPosition(Vector2 position) {
		transform.position = new Vector3(position.x, position.y, z);
	}

	public void SetRotation(Vector3 eulerRotation) {
		transform.eulerAngles = eulerRotation;
	}

	public void SetSprite(Sprite sprite) {
		if (spriteRenderer == null) {
			return;
		}

		spriteRenderer.sprite = sprite;
	}

	public static Representation Create(Representable master, GameObject prefab, Vector2 position, Vector3 eulerRotation) {
		GameObject instance = Instantiate(prefab, new Vector3(position.x, position.y, 0f), Quaternion.Euler(eulerRotation)) as GameObject;
		Representation slave = instance.GetComponent<Representation>();
		slave.master = master;

		return slave;
	}
}
