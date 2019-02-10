using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : AgentIF {
	public abstract void PerformUpdate(EntityIF entity);
}
