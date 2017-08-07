using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
	static GameMaster _Instance;
	public static GameMaster Instance
	{
		get
		{
			if( _Instance == null )
				FindInstance();

			return _Instance;
		}
	}

	[SerializeField]
	public EventManager EventManager;
	[SerializeField]
	List<Card> Cards;
	[SerializeField]
	DrawPile CurrentPile;
	[SerializeField]
	Player PlayerOne;
	[SerializeField]
	Player PlayerTwo;

	void Start()
	{
		InitCards();
		PlayerOne.Init();
		PlayerTwo.Init();
		CurrentPile.Init( 99, Cards );
		CurrentPile.Shuffle();
	}

	void Update()
	{
		if( Input.GetKeyDown( KeyCode.Alpha1 ) )
		{
			Debug.Log( "Player One" );
			Card card;
			if( CurrentPile.DrawTopCard( out card ) )
			{
				if( PlayerOne.CurrentHand.Add( card ) )
					Debug.Log( "Adding " + card.CurrentType );
				else
				{
					Debug.Log( "Hand is full!" );
					CurrentPile.Add( card );
				}
			}
		}

		if( Input.GetKeyDown( KeyCode.Alpha2 ) )
		{
			Debug.Log( "Player Two" );
			Card card;
			if( CurrentPile.DrawTopCard( out card ) )
			{
				if( PlayerTwo.CurrentHand.Add( card ) )
					Debug.Log( "Adding " + card.CurrentType );
				else
				{
					Debug.Log( "Hand is full!" );
					CurrentPile.Add( card );
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

	void InitCards()
	{
		foreach( Card card in Cards )
			card.Init();
	}

	static void FindInstance()
	{
		GameObject gameMasterObj = GameObject.Find( "GameMaster" );
		if( gameMasterObj != null )
		{
			GameMaster gameMaster = gameMasterObj.GetComponent<GameMaster>();
			if( gameMaster != null )
			{
				_Instance = gameMaster;
				return;
			}
		}
		Debug.LogError( "GameMaster not found." );
	}
}
