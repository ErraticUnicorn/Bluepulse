using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeneratorSpriteHandler : MonoBehaviour 
{
	public Sprite[] generatorSprites;
	
	public Generator[] generators;
	
	public enum GeneratorType { Yellow , Red , Green , Purple };
	
	public void SetGeneratorValue( GeneratorType _type , float _value )
	{
		switch( _type )
		{
		case GeneratorType.Red:
			generators[0].SetValue( _value );
		break;
		case GeneratorType.Yellow:
			generators[1].SetValue( _value );
			break;
		case GeneratorType.Green:
			generators[2].SetValue( _value );
			break;
		case GeneratorType.Purple:
			generators[3].SetValue( _value );
			break;
		}
	}
	
}
