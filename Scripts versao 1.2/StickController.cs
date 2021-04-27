using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StickController : MonoBehaviour
{
	
	public Image stickBackground;
	Vector2 defaultPosition;
	public bool clicked = false;
	public Touch touch;
	float x=0,y=0,dx,dy,angle,c,maxDist=20f;
	public int currentFingerId = -1 ;

	void Start()
	{
		float distance = (transform.position - Camera.main.transform.position).z;
		Vector3 cameraBounds0 = Camera.main.ViewportToWorldPoint (new Vector3 (0F, 0F, distance));
		stickBackground.transform.position = new Vector2(cameraBounds0.x + stickBackground.GetComponent<Image>().sprite.rect.width * 3, cameraBounds0.y + stickBackground.GetComponent<Image>().sprite.rect.height * 3);
	}

	void Update ()
	{
		defaultPosition = stickBackground.transform.position;
		moveStick(touch);
	}

	void moveStick(Touch touchReceived)
	{
		if(clicked == true)
		{
			transform.position = touchReceived.position;
			dx = transform.position.x - defaultPosition.x;
			dy = transform.position.y - defaultPosition.y;
			angle = Mathf.Atan(dy/dx);
			c = Mathf.Sqrt(dx*dx+dy*dy);
			if(c>maxDist)
			{
				if(dx>=0 && dy>=0)
				{
					x = defaultPosition.x + (maxDist*Mathf.Cos(angle));
					y = defaultPosition.y + (maxDist*Mathf.Sin(angle));
				}
				else if(dx>=0 && dy<=0)
				{
					x = defaultPosition.x + (maxDist*Mathf.Cos(angle));
					y = defaultPosition.y + (maxDist*Mathf.Sin(angle));
				}
				else if(dx<=0 && dy<=0)
				{
					x = defaultPosition.x - (maxDist*Mathf.Cos(angle));
					y = defaultPosition.y - (maxDist*Mathf.Sin(angle));
				}
				else if(dx<=0 && dy>=0)
				{
					x = defaultPosition.x - (maxDist*Mathf.Cos(angle));
					y = defaultPosition.y - (maxDist*Mathf.Sin(angle));
				}
			}
			else
			{
				x = defaultPosition.x + dx;
				y = defaultPosition.y + dy;
			}
				transform.position = new Vector2(x,y);
		}
		else
		{
			transform.position = defaultPosition;
		}
	}

	public float getAxis(string axisName)
	{
		float axisValue = 0;
		if(axisName == "Horizontal")
		{
			axisValue = (transform.position.x-defaultPosition.x)/maxDist;

		}
		if(axisName == "Vertical")
		{
			axisValue = (transform.position.y-defaultPosition.y)/maxDist;
		}
		return axisValue;
	}
	
}
