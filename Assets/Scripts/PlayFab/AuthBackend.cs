using PlayFab;
using PlayFab.ClientModels;
using System;

public enum CallbackType
{
	Success,
	Fail
}

public class LoginInfo
{
	public string email;
	public string password;
}

public class LoginCallback
{
	public CallbackType callbackType;
	public LoginResult result;
	public PlayFabError error;
}

public static class AuthBackend
{
	public static void OnLogin(LoginInfo info, Action<LoginCallback> callback = null)
	{
		PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest
		{
			Email = info.email,
			Password = info.password,
			TitleId = PlayFabSettings.TitleId
		},
		result =>
		{
			callback?.Invoke(new LoginCallback { callbackType = CallbackType.Success, result = result });
		},
		error =>
		{
			callback?.Invoke(new LoginCallback { callbackType = CallbackType.Fail, error = error });
		});
	}
}
