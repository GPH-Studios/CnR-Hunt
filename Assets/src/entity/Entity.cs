using UnityEngine;

public class Entity : Representable, EntityIF {
	private AgentIF agent;

	private Vector2 position;
	private Rotation2 rotation;

	public Entity(string prefabName) : base(prefabName) {
		position = new Vector2();
		rotation = new Rotation2();
	}

	public Vector2 GetPosition() {
		return new Vector2(position.x, position.y);
	}

	public void SetPosition(Vector2 position) {
		this.position = position;
	}

	public void AdjustPosition(Vector2 delta) {
		position += delta;
	}

	public Rotation2 GetRotation() {
		return new Rotation2(rotation);
	}

	public void SetRotation(Rotation2 rotation) {
		this.rotation = rotation;
	}

	public void AdjustRotation(Rotation2 delta) {
		rotation += delta;
	}

	public void SetAgent(AgentIF agent) {
		this.agent = agent;
	}

	protected override void PerformUpdate() {
		if (agent != null) {
			agent.PerformUpdate(this);
		}

		SetRepresentationPosition(position);
		SetRepresentationRotation(rotation);
	}
}
