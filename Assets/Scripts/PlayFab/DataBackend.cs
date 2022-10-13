using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine;

public static class DataBackend
{
	private static int _attackCount = 0;

	public static void PlusAttackCount()
	{
		_attackCount++;
		Debug.Log($"Attack: {_attackCount}");
	}

	public static void UpdateLeaderboard(Action callback = null)
	{
		Debug.Log(_attackCount);
		PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest
		{
			FunctionName = "updatePlayerLeaderboard",
			FunctionParameter = new {
				LeaderboardName = "AttackCount",
				Value = _attackCount
			},
			GeneratePlayStreamEvent = true
		},
		result =>
		{
			callback?.Invoke();
			Debug.Log("Leaderboard Update Success!");
		},
		error =>
		{
			callback?.Invoke();
			Debug.LogError("Leaderboard Update Fail!");
		});
	}
}
