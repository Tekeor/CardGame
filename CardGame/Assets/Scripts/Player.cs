using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	public CardStack CurrentHand;

	public void Init()
	{
		CurrentHand.Init( 5, null );
	}
}
