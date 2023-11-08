using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    private InputControl inputControl;
    private Vector2 moveDirection;

    [SerializeField] private int speed;

    private void Awake()
    {
        inputControl = new InputControl();

        inputControl.Player.Movement.started += MoveHandler;
        inputControl.Player.Movement.performed += MoveHandler;
        inputControl.Player.Movement.canceled += MoveHandler;
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MoveHandler(InputAction.CallbackContext value)
    {
        moveDirection = value.ReadValue<Vector2>();
    }

    private void MovePlayer()
    {
        transform.Translate(new Vector2(moveDirection.x, moveDirection.y).normalized * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Thief"))
        {
            //AddScore
            //Destroy/Disable Thief
            collision.gameObject.SetActive(false);
        }
    }

















    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }
}
