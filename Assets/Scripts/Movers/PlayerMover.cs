using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] InputAction moveRight = new InputAction(type: InputActionType.Button);
    [SerializeField] InputAction moveLeft = new InputAction(type: InputActionType.Button);
    [SerializeField] InputAction moveUp = new InputAction(type: InputActionType.Button);
    [SerializeField] InputAction moveDown = new InputAction(type: InputActionType.Button);

    [SerializeField] float speed = 5f;

    // allow movement only after game start
    public bool canMove = false;

    // Movement direction
    private Vector2 moveDir = Vector2.zero;

    void OnEnable()
    {
        moveRight.Enable();
        moveLeft.Enable();
        moveUp.Enable();
        moveDown.Enable();

        moveRight.performed += OnRight;
        moveRight.canceled += OnRight;

        moveLeft.performed += OnLeft;
        moveLeft.canceled += OnLeft;

        moveUp.performed += OnUp;
        moveUp.canceled += OnUp;

        moveDown.performed += OnDown;
        moveDown.canceled += OnDown;
    }

    void OnDisable()
    {
        moveRight.performed -= OnRight;
        moveRight.canceled -= OnRight;
        moveRight.Disable();

        moveLeft.performed -= OnLeft;
        moveLeft.canceled -= OnLeft;
        moveLeft.Disable();

        moveUp.performed -= OnUp;
        moveUp.canceled -= OnUp;
        moveUp.Disable();

        moveDown.performed -= OnDown;
        moveDown.canceled -= OnDown;
        moveDown.Disable();
    }

    //Handlers

    void OnRight(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canMove) moveDir.x = 1;
        else if (ctx.canceled && moveDir.x > 0) moveDir.x = 0;
    }

    void OnLeft(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canMove) moveDir.x = -1;
        else if (ctx.canceled && moveDir.x < 0) moveDir.x = 0;
    }

    void OnUp(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canMove) moveDir.y = 1;
        else if (ctx.canceled && moveDir.y > 0) moveDir.y = 0;
    }

    void OnDown(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canMove) moveDir.y = -1;
        else if (ctx.canceled && moveDir.y < 0) moveDir.y = 0;
    }

    void Update()
    {
        Vector3 direction = new Vector3(moveDir.x, moveDir.y, 0f);

        if (direction != Vector3.zero)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }
}
