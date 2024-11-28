using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterScript : MonoBehaviour
{
    private InputAction moveAction;
    private CharacterController characterController;
    private float speedFactor = 5f;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Vector3 move = Camera.main.transform.forward;  // напрям погляду камери
        move.y = 0.0f;   // проєктуємо на горизонтальну площину
        if(move == Vector3.zero)  // вектор був вертикальним (погляд вниз)
        {
            move = Camera.main.transform.up;   // тоді вперед "дивиться" вісь Y
        }
        move.Normalize();   // видовжуємо вектор після проєктування
        // у даному місці move - напрям постійного руху (польоту)

        Vector3 moveForward = move;  // зберігаємо для повороту персонажа

        // додаємо до нього управління, яке теж орієнтовано по камері
        move += moveValue.x * Camera.main.transform.right ;
        move.y = moveValue.y;
        move.y -= 30f * Time.deltaTime;   // падіння

        characterController.Move(speedFactor * Time.deltaTime * move);
        this.transform.forward = moveForward;   // повертаємо персонажа у напряму руху
        // Debug.Log(this.transform.position.y - Terrain.activeTerrain.SampleHeight(this.transform.position));
    }
}
/* Д.З. Обмежити поворот камери по вертикалі: не менше 0, не більше 90
 * Реалізувати горизонтальний рух таким чином, щоб зберігалась висота
 * над поверхнею землі (відповідно до рельєфу), але не вище за 20 одиниць
 * (в абсолютних координатах)
 * 
 */
