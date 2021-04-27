using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePadController : MonoBehaviour
{
	public Image[]imageButtons;
	public Image[]imageSticks;
	string buttonName;
	float stickMaxDistance = 50f;
	float stickSpeed = 3f;

	void Update()
	{
		if(Input.touchCount > 0)
		{
			for(int touchIndex = 0; touchIndex<Input.touchCount;touchIndex++)
			{
				switch(Input.GetTouch(touchIndex).phase)
				{
				case TouchPhase.Began:
					for(int i = 0;i<imageSticks.Length;i++)
					{
						if(Vector2.Distance(imageSticks[i].transform.position, Input.GetTouch(touchIndex).position) <= imageSticks[i].GetComponent<Image>().sprite.rect.width/2 && imageSticks[i].GetComponent<StickController>().clicked == false)
						{
							imageSticks[i].GetComponent<StickController>().touch = Input.GetTouch(touchIndex);
							imageSticks[i].GetComponent<StickController>().clicked = true;
							imageSticks[i].GetComponent<StickController>().currentFingerId = Input.GetTouch(touchIndex).fingerId;
						}
					}
					for(int i = 0;i<imageButtons.Length;i++)
					{
						if(Vector2.Distance(imageButtons[i].transform.position, Input.GetTouch(touchIndex).position) <= imageButtons[i].GetComponent<Image>().sprite.rect.width/2)
						{
							imageButtons[i].GetComponent<ButtonController>().touch = Input.GetTouch(touchIndex);
							imageButtons[i].GetComponent<ButtonController>().buttonDown = true;
							imageButtons[i].GetComponent<ButtonController>().buttonHold = true;
							imageButtons[i].GetComponent<ButtonController>().currentFingerId = Input.GetTouch(touchIndex).fingerId;
						}
					}
					break;
				case TouchPhase.Canceled:

					break;
				case TouchPhase.Ended:
					for(int i = 0;i<imageSticks.Length;i++)
					{
						if(imageSticks[i].GetComponent<StickController>().currentFingerId == Input.GetTouch(touchIndex).fingerId)
						{
							imageSticks[i].GetComponent<StickController>().clicked = false;
							imageSticks[i].GetComponent<StickController>().currentFingerId = -1;
						}
					}
					for(int i = 0;i<imageButtons.Length;i++)
					{
						if(imageButtons[i].GetComponent<ButtonController>().currentFingerId == Input.GetTouch(touchIndex).fingerId)
						{
							imageButtons[i].GetComponent<ButtonController>().buttonUp = true;
							imageButtons[i].GetComponent<ButtonController>().buttonHold = false;
							imageButtons[i].GetComponent<ButtonController>().currentFingerId = -1;
						}
					}
					break;
				case TouchPhase.Moved:
					for(int i = 0;i<imageSticks.Length;i++)
					{
						if(imageSticks[i].GetComponent<StickController>().clicked == true && imageSticks[i].GetComponent<StickController>().currentFingerId == Input.GetTouch(touchIndex).fingerId)
						{
							imageSticks[i].GetComponent<StickController>().touch = Input.GetTouch(touchIndex);
						}
					}
					break;
				case TouchPhase.Stationary:

					break;
					
				}
			}
		}
	}

}
