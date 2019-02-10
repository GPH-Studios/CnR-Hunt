using UnityEngine;

public abstract class Representable {
	private static readonly float DEFAULT_COORD = 0f;

	private readonly Vector2 defaultPosition;

	private string prefabName;
	private string spriteName;
	private Vector2 position;
	private Rotation2 rotation;

	private Representation rep;
	private GameObject prefab;
	private Sprite sprite;

	public Representable(string prefabName) : this(prefabName, new Vector2(DEFAULT_COORD, DEFAULT_COORD)) {}

	public Representable(string prefabName, Vector2 defaultPosition) {
		this.defaultPosition = new Vector2(defaultPosition.x, defaultPosition.y);

		SetRepresentationPrefab(prefabName);
		SetRepresentationSprite(null);
		position = new Vector2(this.defaultPosition.x, this.defaultPosition.y);
		rotation = new Rotation2();
	}

	public Representation GetRepresentation() {
		return rep;
	}

	public Vector2 GetRepresentationPosition() {
		return position;
	}

	public void SetRepresentationPosition(Vector2 position) {
		this.position = position;
	}

	public Rotation2 GetRepresentationRotation() {
		return rotation ?? new Rotation2();
	}

	public void SetRepresentationRotation(Rotation2 rotation) {
		this.rotation = rotation;
	}

	public Vector3 GetRepresentationEulerRotation() {
		return new Vector3(0f, 0f, GetRepresentationRotation().inDegrees - 90f);
	}

	public void SetRepresentationPrefab(string prefabName) {
		this.prefabName = prefabName;

		if (prefabName != null) {
			prefab = ResourceLibrary.GetPrefab(prefabName);
		} else {
			prefab = null;
		}
	}

	public Sprite GetRepresentationSprite() {
		return sprite;
	}

	public void SetRepresentationSprite(string spriteName) {
		this.spriteName = spriteName;

		if (spriteName != null) {
			sprite = ResourceLibrary.GetSprite(spriteName);
		} else {
			sprite = null;
		}
	}

	public void CreateRepresentation() {
		if (rep != null) {
			GameObject.Destroy(rep);
		}

		rep = Representation.Create(this, prefab, position, GetRepresentationEulerRotation());
	}

	public void UpdateRepresentation() {
		PerformUpdate();

		rep.SetPosition(position);
		rep.SetRotation(GetRepresentationEulerRotation());
		rep.SetSprite(sprite);
	}

	protected abstract void PerformUpdate();
}
