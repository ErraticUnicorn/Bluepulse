1) To setup the graphics and Assets, simply add the "GameArt" Prefab from the Assets\Art\Prefabs folder!

2)
On the Object:
GameArt - Canvas - Background - GeneratorGroup
Is a Script called GeneratorSpriteHandler
This script animates the Generators, Updates the sprites if the values change etc.
To change a Generator's value, simply access the
"GeneratorSpriteHandler.SetGeneratorValue( GeneratorType _type , float _value );"
in your scripts.

These are the given types:
public enum GeneratorType { Yellow , Red , Green , Purple };

The text and feedback effects will automatically change based on the value.
If more changes are necessary, take a look at the GeneratorSpriteHandler.cs and Generator.cs
They should be self explanatory.

2)
The other thing you need is the Lighyearcounter:
It sits in:
GameArt-Canvas-Background-LightyearGroup-LightyearCount
To change this, add: "using UnityEngine.UI;" to your scripts
Then create a "new Text lightyearsText;" in your script
Modify the "lightyearsText.text = lightyearCount.ToString();" to update the text there.
It should be aligning properly. After 999.999.999 the bounds of the container will be reached, so
you might want to shorten the string to "999.999k" or "999 10pow6" or something...

Greetings,

Max