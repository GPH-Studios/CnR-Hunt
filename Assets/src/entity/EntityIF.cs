using UnityEngine;

public interface EntityIF {
	Vector2 GetPosition();
	void SetPosition(Vector2 position);
	void AdjustPosition(Vector2 delta);

	Rotation2 GetRotation();
	void SetRotation(Rotation2 rotation);
	void AdjustRotation(Rotation2 delta);

	void SetAgent(AgentIF agent);
}
