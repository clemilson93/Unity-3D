using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonController : MonoBehaviour
{
	public Touch touch;
	public bool buttonDown = false, buttonUp = false, buttonHold = false;
	public int currentFingerId = -1 ;

	void FixedUpdate ()
	{
		if(buttonDown == true)
		{
			buttonDown = false;
		}
		if(buttonUp == true)
		{
			buttonUp = false;
		}
	}

	public bool buttonPressed()
	{
		return buttonDown;
	}
	public bool buttonReleased()
	{
		return buttonUp;
	}
	public bool buttonHolded()
	{
		return buttonHold;
	}
}
