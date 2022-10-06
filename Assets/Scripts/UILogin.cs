using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UILogin : MonoBehaviour
{
	public TMP_InputField EmailField;
	public TMP_InputField PasswordField;

	public GameObject loginFailText;

	public UnityAction LoginButtonAction;
	public UnityAction ExitButtonAction;

	public void LoginButton()
	{
		LoginButtonAction.Invoke();
	}

	public void ExitButton()
	{
		ExitButtonAction.Invoke();
	}
}
