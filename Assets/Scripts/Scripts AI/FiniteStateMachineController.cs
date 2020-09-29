using System.Collections;
using UnityEngine;

// step 1 - define states
enum CharacterState
{
    GO_LEFT,
    SHOOT_1,
    GO_RIGHT,
    SHOOT_2
}

public class FiniteStateMachineController : MonoBehaviour
{
    [SerializeField]
    private CharacterCommands Commands;

    [SerializeField]
    private Transform bullet;

    [SerializeField]
    private Transform firePoint1;
    [SerializeField]
    private Transform firePoint2;

    [SerializeField]
    private GameObject firingEffect;


    // step 2 - add current state, and initialize with default state
    private CharacterState _currentState = CharacterState.SHOOT_1;

    private void Update()
    {
        // step 3 - add actions for each state and transitions
        switch (_currentState)
        {
            case CharacterState.GO_LEFT:
                Commands.HorizontalAxis = -5.0f;
                break;
            case CharacterState.SHOOT_1:
                Instantiate(firingEffect, firePoint1.position, firePoint1.rotation);
                Instantiate(bullet, firePoint1.position, firePoint1.rotation);
                Instantiate(firingEffect, firePoint2.position, firePoint2.rotation);
                Instantiate(bullet, firePoint2.position, firePoint2.rotation);
                _currentState = CharacterState.GO_RIGHT;
                Commands.VerticalAxis = 1.0f;
                StartCoroutine(TimerCoroutine(1.5f, CharacterState.SHOOT_2));
                break;
            case CharacterState.GO_RIGHT:
                Commands.HorizontalAxis = 5.0f;
                break;
            case CharacterState.SHOOT_2:
                Instantiate(firingEffect, firePoint1.position, firePoint1.rotation);
                Instantiate(bullet, firePoint1.position, firePoint1.rotation);
                Instantiate(firingEffect, firePoint2.position, firePoint2.rotation);
                Instantiate(bullet, firePoint2.position, firePoint2.rotation);
                _currentState = CharacterState.GO_LEFT;
                Commands.VerticalAxis = -1.0f;
                StartCoroutine(TimerCoroutine(1.5f, CharacterState.SHOOT_1));
                break;
            default:
                break;
        }
    }

    private IEnumerator TimerCoroutine(float time, CharacterState nextState)
    {
        yield return new WaitForSeconds(time);
        _currentState = nextState;
    }
}
