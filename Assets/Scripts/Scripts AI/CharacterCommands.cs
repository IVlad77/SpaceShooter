using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CharacterCommands", menuName = "AI/CharacterCommands", order = 1)]
public class CharacterCommands : ScriptableObject
{
    [Range(-5.0f, 5.0f)]
    public float HorizontalAxis, VerticalAxis;
    
}
