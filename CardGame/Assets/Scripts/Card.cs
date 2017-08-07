using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
	[SerializeField]
	int CardType;
	public int CurrentType { get { return CardType; } }
	[SerializeField]
	List<CardEffect> EffectsList;

	Dictionary<EffectTriggers, List<CardEffect>> Effects;

	public void Init()
	{
		Effects = new Dictionary<EffectTriggers, List<CardEffect>>();
		foreach( CardEffect effect in EffectsList )
		{
			List<CardEffect> currentList;
			if( Effects.TryGetValue( effect.EffectTrigger, out currentList ) )
				currentList.Add( effect );
			else
			{
				currentList = new List<CardEffect>() { effect };
				Effects.Add( effect.EffectTrigger, currentList );
			}
		}
	}

	public void TriggerEffect( EffectTriggers trigger )
	{
		List<CardEffect> currentList;
		if( Effects.TryGetValue( trigger, out currentList ) )
		{
			foreach( CardEffect effect in currentList )
				effect.Apply();
		}
	}
}
