using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuManager : MonoBehaviour
{
	[SerializeField] private UIPopup _popupPanel = default;
	[SerializeField] private UISettingsController _settingsPanel = default;
	[SerializeField] private UICredits _creditsPanel = default;
	[SerializeField] private UIMainMenu _mainMenuPanel = default;
	[SerializeField] private UILogin _loginPanel = default;

	[SerializeField] private SaveSystem _saveSystem = default;

	[SerializeField] private InputReader _inputReader = default;


	[Header("Broadcasting on")]
	[SerializeField]
	private VoidEventChannelSO _startNewGameEvent = default;
	[SerializeField]
	private VoidEventChannelSO _continueGameEvent = default;

	public static bool _onLogin = false;

	private bool _hasSaveData;

	private IEnumerator Start()
	{
		_inputReader.EnableMenuInput();
		yield return new WaitForSeconds(0.4f); //waiting time for all scenes to be loaded 
		SetMenuScreen();
	}

	void SetMenuScreen()
	{
		if (_onLogin)
		{
			LoginSuccesss();
			return;
		}

		_loginPanel.LoginButtonAction += () =>
		{
			AuthBackend.OnLogin(new LoginInfo
			{
				email = _loginPanel.EmailField.text,
				password = _loginPanel.PasswordField.text
			},
			result =>
			{
				if (result.callbackType == CallbackType.Success)
				{
					_onLogin = true;
					LoginSuccesss();
				}
				else
				{
					if (_loginPanel.loginFailText.activeSelf == false)
					{
						_loginPanel.loginFailText.SetActive(true);
					}
				}
			});
		};

		_loginPanel.ExitButtonAction += ShowExitConfirmationPopup;
	}

	void LoginSuccesss()
	{
		_loginPanel.gameObject.SetActive(false);

		_hasSaveData = _saveSystem.LoadSaveDataFromDisk();
		_mainMenuPanel.gameObject.SetActive(true);
		_mainMenuPanel.SetMenuScreen(_hasSaveData);
		_mainMenuPanel.ContinueButtonAction += _continueGameEvent.RaiseEvent;
		_mainMenuPanel.NewGameButtonAction += ButtonStartNewGameClicked;
		_mainMenuPanel.SettingsButtonAction += OpenSettingsScreen;
		_mainMenuPanel.CreditsButtonAction += OpenCreditsScreen;
		_mainMenuPanel.ExitButtonAction += ShowExitConfirmationPopup;
	}

	void ButtonStartNewGameClicked()
	{
		if (!_hasSaveData)
		{
			ConfirmStartNewGame();

		}
		else
		{
			ShowStartNewGameConfirmationPopup();

		}

	}

	void ConfirmStartNewGame()
	{
		_startNewGameEvent.RaiseEvent();
	}

	void ShowStartNewGameConfirmationPopup()
	{
		_popupPanel.ConfirmationResponseAction += StartNewGamePopupResponse;
		_popupPanel.ClosePopupAction += HidePopup;

		_popupPanel.gameObject.SetActive(true);
		_popupPanel.SetPopup(PopupType.NewGame);

	}

	void StartNewGamePopupResponse(bool startNewGameConfirmed)
	{

		_popupPanel.ConfirmationResponseAction -= StartNewGamePopupResponse;
		_popupPanel.ClosePopupAction -= HidePopup;

		_popupPanel.gameObject.SetActive(false);

		if (startNewGameConfirmed)
		{
			ConfirmStartNewGame();
		}
		else
		{
			_continueGameEvent.RaiseEvent();
		}

		_mainMenuPanel.SetMenuScreen(_hasSaveData);

	}

	void HidePopup()
	{
		_popupPanel.ClosePopupAction -= HidePopup;
		_popupPanel.gameObject.SetActive(false);
		_mainMenuPanel.SetMenuScreen(_hasSaveData);

	}

	public void OpenSettingsScreen()
	{
		_settingsPanel.gameObject.SetActive(true);
		_settingsPanel.Closed += CloseSettingsScreen;

	}
	public void CloseSettingsScreen()
	{
		_settingsPanel.Closed -= CloseSettingsScreen;
		_settingsPanel.gameObject.SetActive(false);
		_mainMenuPanel.SetMenuScreen(_hasSaveData);

	}
	public void OpenCreditsScreen()
	{
		_creditsPanel.gameObject.SetActive(true);

		_creditsPanel.OnCloseCredits += CloseCreditsScreen;




	}
	public void CloseCreditsScreen()
	{
		_creditsPanel.OnCloseCredits -= CloseCreditsScreen;
		_creditsPanel.gameObject.SetActive(false);
		_mainMenuPanel.SetMenuScreen(_hasSaveData);

	}


	public void ShowExitConfirmationPopup()
	{
		_popupPanel.ConfirmationResponseAction += HideExitConfirmationPopup;
		_popupPanel.gameObject.SetActive(true);
		_popupPanel.SetPopup(PopupType.Quit);



	}
	void HideExitConfirmationPopup(bool quitConfirmed)
	{
		_popupPanel.ConfirmationResponseAction -= HideExitConfirmationPopup;
		_popupPanel.gameObject.SetActive(false);
		if (quitConfirmed)
		{
			DataBackend.UpdateLeaderboard(() =>
			{
				Application.Quit();
			});
		}
		_mainMenuPanel.SetMenuScreen(_hasSaveData);


	}
	private void OnDestroy()
	{
		_popupPanel.ConfirmationResponseAction -= HideExitConfirmationPopup;
		_popupPanel.ConfirmationResponseAction -= StartNewGamePopupResponse;

	}


}
