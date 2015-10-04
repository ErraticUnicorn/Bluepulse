using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Generator : MonoBehaviour 
{
	public GeneratorSpriteHandler generatorHandler;
	public GameObject fullPower;
	
	public Text text;
	Image image;
	float value;

	public void AddValue( float _value )
	{
		float newValue = value + _value;
		if (newValue < 100f)
		{
			SetValue( newValue );
		}
	}

	public void SetValue( float _value )
	{
		value = _value;
		CheckValue();
	}

	public bool isReady()
	{
		return value >= 100;
	}

	public void Activate()
	{
		value = 0;
		CheckValue();
	}
	
	void Start()
	{
		if( value == 100 )fullPower.SetActive(false);
		image = this.gameObject.GetComponent<Image>();
		SetValue( 0 );
	}
	
	void CheckValue()
	{
		text.text = value.ToString()+"%";
		if( value <= 100 && value > 90 )
		{
			
			if( value == 100 )fullPower.SetActive(true);
			image.sprite = generatorHandler.generatorSprites[9];
		}
		else if( value <= 90 && value > 80 )
		{
			image.sprite = generatorHandler.generatorSprites[8];
		}
		else if( value <= 80 && value > 70 )
		{
			image.sprite = generatorHandler.generatorSprites[7];
		}
		else if( value <= 70 && value > 60 )
		{
			image.sprite = generatorHandler.generatorSprites[6];
		}
		else if( value <= 60 && value > 50 )
		{
			image.sprite = generatorHandler.generatorSprites[5];
		}
		else if( value <= 50 && value > 40 )
		{
			image.sprite = generatorHandler.generatorSprites[4];
		}
		else if( value <= 40 && value > 30 )
		{
			image.sprite = generatorHandler.generatorSprites[3];
		}
		else if( value <= 30 && value > 20 )
		{
			image.sprite = generatorHandler.generatorSprites[2];
		}
		else if( value <= 20 && value > 10 )
		{
			image.sprite = generatorHandler.generatorSprites[1];
		}
		else if( value <= 10  )
		{
			image.sprite = generatorHandler.generatorSprites[0];
		}
	}
}
