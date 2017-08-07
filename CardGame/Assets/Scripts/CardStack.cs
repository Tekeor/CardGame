using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack : MonoBehaviour
{
	public enum DrawType
	{
		Top,
		Random
	}

	protected int MaxCount = 1;
	protected List<Card> Cards;

	public void Init( int max, List<Card> cards )
	{
		MaxCount = max;
		Cards = new List<Card>( max );
		if( cards != null )
		{
			foreach( Card card in cards )
				Add( card );
		}
	}

	public void Shuffle()
	{
		Debug.Log( "Shuffling stack..." );
		List<Card> temp = new List<Card>( Cards );
		Cards.Clear();
		while( temp.Count > 0 )
		{
			int index = Random.Range( 0, temp.Count );
			Card currentCard = temp[index];
			Cards.Add( currentCard );
			temp.RemoveAt( index );
		}
	}

	public bool Add( Card card )
	{
		if( Cards.Count < MaxCount && !Cards.Contains( card ) )
		{
			Cards.Add( card );
			card.transform.SetParent( transform );
			GameMaster.Instance.EventManager.TriggerEvent( EventManager.EventTypes.CardAddedToStack, new KeyValuePair<CardStack, Card>(this, card) );
			return true;
		}
		return false;
	}

	public bool Insert( int index, Card card )
	{
		if( Cards.Count < MaxCount && !Cards.Contains( card ) )
		{
			Cards.Insert( index, card );
			card.transform.SetParent( transform );
			GameMaster.Instance.EventManager.TriggerEvent( EventManager.EventTypes.CardAddedToStack, new KeyValuePair<CardStack, Card>( this, card ) );
			return true;
		}
		return false;
	}

	public bool Remove( int index, out Card card )
	{
		if( Cards.Count == 0 || index >= Cards.Count )
		{
			card = null;
			return false;
		}
		card = Cards[index];
		Cards.RemoveAt( index );
		GameMaster.Instance.EventManager.TriggerEvent( EventManager.EventTypes.CardRemovedFromStack, new KeyValuePair<CardStack, Card>( this, card ) );
		return true;
	}

	public void LogCards()
	{
		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		sb.AppendLine( "Card list:" );
		foreach( Card card in Cards )
			sb.AppendLine( card.CurrentType.ToString() );

		Debug.Log( sb.ToString() );
	}
}
