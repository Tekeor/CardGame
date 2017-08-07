using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPile : CardStack
{
	public bool DrawTopCard( out Card card )
	{
		Debug.Log( "Drawing the top card..." );
		if( Remove( Cards.Count - 1, out card ) )
		{
			card.TriggerEffect( EffectTriggers.Draw );
			return true;
		}
		
		card = null;
		return false;
	}

	public bool DrawBottomCard( out Card card )
	{
		Debug.Log( "Drawing the bottom card..." );
		if( Remove( 0, out card ) )
			return true;

		card = null;
		return false;
	}
}
