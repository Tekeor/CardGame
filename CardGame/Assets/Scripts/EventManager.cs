using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	public enum EventTypes
	{
		CardAddedToStack,
		CardRemovedFromStack
	}

	Dictionary<EventTypes, List<Action<object>>> RegisterdActions = new Dictionary<EventTypes, List<Action<object>>>();

	public void TriggerEvent( EventTypes eventType, object obj )
	{
		List<Action<object>> registered;
		if( RegisterdActions.TryGetValue( eventType, out registered ) )
		{
			foreach( Action<object> act in registered )
				act( obj );
		}
	}

	public void RegisterToEvent( EventTypes eventType, Action<object> onEventTriggered )
	{
		List<Action<object>> registered;
		if( RegisterdActions.TryGetValue( eventType, out registered ) )
			registered.Add( onEventTriggered );
		else
		{
			registered = new List<Action<object>>();
			registered.Add( onEventTriggered );
			RegisterdActions.Add( eventType, registered );
		}
	}

	public void UnregisterToEvent( EventTypes eventType, Action<object> onEventTriggered )
	{
		List<Action<object>> registered;
		if( RegisterdActions.TryGetValue( eventType, out registered ) )
		{
			if( registered.Contains( onEventTriggered ) )
				registered.Remove( onEventTriggered );
		}
	}
}
