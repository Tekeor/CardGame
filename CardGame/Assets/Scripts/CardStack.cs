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

	int MaxCount = 1;
	List<Card> Cards;

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

	public bool Draw( DrawType drawType, out Card card )
	{
		Debug.Log( "Drawing a card..." );
		if( Cards.Count > 0 )
		{
			switch( drawType )
			{
				case DrawType.Random:
				int index = Random.Range( 0, Cards.Count );
				card = Cards[index];
				Cards.RemoveAt( index );
				return true;

				case DrawType.Top:
				card = Cards[Cards.Count - 1];
				Cards.RemoveAt( Cards.Count - 1 );
				return true;
			}
		}
		card = null;
		return false;
	}

	public bool Add( Card card )
	{
		if( Cards.Count < MaxCount && !Cards.Contains( card ) )
		{
			Cards.Add( card );
			card.transform.SetParent( transform );
			return true;
		}
		else
			return false;
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
