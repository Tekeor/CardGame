using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
	[SerializeField]
	int CardType;
	public int CurrentType { get { return CardType; } } 

}
