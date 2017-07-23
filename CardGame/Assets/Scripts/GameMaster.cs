using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
	[SerializeField]
	List<Card> Cards;
	[SerializeField]
	CardStack CurrentDeck;
	[SerializeField]
	Player PlayerOne;
	[SerializeField]
	Player PlayerTwo;

	void Start()
	{
		PlayerOne.Init();
		PlayerTwo.Init();
		CurrentDeck.Init( 99, Cards );
		CurrentDeck.Shuffle();
	}

	void Update()
	{
		if( Input.GetKeyDown( KeyCode.Alpha1 ) )
		{
			Debug.Log( "Player One" );
			Card card;
			if( CurrentDeck.Draw( CardStack.DrawType.Top, out card ) )
			{
				if( PlayerOne.CurrentHand.Add( card ) )
					Debug.Log( "Adding " + card.CurrentType );
				else
				{
					Debug.Log( "Hand is full!" );
					CurrentDeck.Add( card );
				}
			}
		}

		if( Input.GetKeyDown( KeyCode.Alpha2 ) )
		{
			Debug.Log( "Player Two" );
			Card card;
			if( CurrentDeck.Draw( CardStack.DrawType.Top, out card ) )
			{
				if( PlayerTwo.CurrentHand.Add( card ) )
					Debug.Log( "Adding " + card.CurrentType );
				else
				{
					Debug.Log( "Hand is full!" );
					CurrentDeck.Add( card );
				}
			}
		}

		if( Input.GetKeyDown( KeyCode.Alpha3 ) )
		{
			Debug.Log( "Player One" );
			PlayerOne.CurrentHand.LogCards();
		}

		if( Input.GetKeyDown( KeyCode.Alpha4 ) )
		{
			Debug.Log( "Player Two" );
			PlayerTwo.CurrentHand.LogCards();
		}
	}
}
