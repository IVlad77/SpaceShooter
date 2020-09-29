using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    [SerializeField]
    private float Speed = 1.0f;

    [SerializeField]
    private CharacterCommands Commands;

    private void FixedUpdate()
    {
        float h = Commands.HorizontalAxis;
        float v = Commands.VerticalAxis;

        transform.position += new Vector3(h, 0.0f, v) * Time.fixedDeltaTime * Speed;
    }
}
