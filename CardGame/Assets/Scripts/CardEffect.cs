using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectTriggers
{
	Draw,
	EndGame
}

public class CardEffect : MonoBehaviour
{
	[SerializeField]
	EffectTriggers Trigger;
	public EffectTriggers EffectTrigger { get { return Trigger; } }
	[SerializeField]
	string EffectName;


	public void Apply()
	{
		Debug.Log( "Applying effect [" + EffectName + "]" );
	}
}
