using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomUpdateFunction
{
	public readonly int UpdatesPerSecond;
	public readonly Action actionOnUpdate;

	private Coroutine _update;

	private CustomUpdateFunction(int updatesPerSecond, Action actionOnUpdate)
	{
		UpdatesPerSecond = updatesPerSecond;
		this.actionOnUpdate = actionOnUpdate;
	}

	public static CustomUpdateFunction CreateInstanceAndInitiate(int updatesPerSecond, Action actionOnUpdate)
	{
		var instance = new CustomUpdateFunction(updatesPerSecond, actionOnUpdate);
	}

	public void StartUpdating()
	{
		Start(Co_Update());
	}

	private IEnumerator Co_Update()
	{
		var waitTime = 1.0f / UpdatesPerSecond;

		while (true)
		{
			actionOnUpdate();
			yield return new WaitForSeconds(waitTime);
			yield return null;
		}
	}
}
