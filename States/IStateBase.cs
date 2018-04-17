using UnityEngine;
using System.Collections;

public interface IStateBase{
	//void StateUpdate();
	GameScene Scene{
		get;
	}

	void InitializedObjectRefs(); 
}
