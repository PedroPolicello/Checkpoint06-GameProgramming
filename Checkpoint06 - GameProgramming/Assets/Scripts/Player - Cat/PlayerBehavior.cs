using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public static PlayerBehavior instance;

    private InputControl inputControl;
    private Vector2 moveDirection;

    [SerializeField] private int speed;
    [SerializeField] private GameObject pause;

    //Animations
    private bool isWalkUp;
    private bool isWalkDown;
    private bool isWalkRight;
    private bool isWalkLeft;
    private Animator animator;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        inputControl = new InputControl();

        animator = GetComponent<Animator>();

        inputControl.Player.Movement.started += MoveHandler;
        inputControl.Player.Movement.performed += MoveHandler;
        inputControl.Player.Movement.canceled += MoveHandler;

        inputControl.Player.PauseMenu.started += PauseMenu;

        inputControl.Player.AnimUp.started += SetAnimUp;
        inputControl.Player.AnimUp.canceled += CancelAnimUp;

        inputControl.Player.AnimDown.started += SetAnimDown;
        inputControl.Player.AnimDown.canceled += CancelAnimDown;

        inputControl.Player.AnimLeft.started += SetAnimLeft;
        inputControl.Player.AnimLeft.canceled += CancelAnimLeft;

        inputControl.Player.AnimRight.started += SetAnimRight;
        inputControl.Player.AnimRight.canceled += CancelAnimRight;
    }

    private void Update()
    {
        MovePlayer();
        AnimationHandler();
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
        if (collision.gameObject.CompareTag("Thief"))
        {
            //collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            ScoreSystem.instance.SetScore(1);
            CharactersSpawner.instance.SpawnSingleThief();
        }
    }

    void PauseMenu(InputAction.CallbackContext value)
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    void AnimationHandler()
    {
        if (isWalkUp)
        {
            animator.SetBool("isWalkUp", true);
        }
        else if (!isWalkUp)
        {
            animator.SetBool("isWalkUp", false);
        }

        if (isWalkDown)
        {
            animator.SetBool("isWalkDown", true);
        }
        else if (!isWalkDown)
        {
            animator.SetBool("isWalkDown", false);
        }

        if (isWalkLeft)
        {
            animator.SetBool("isWalkLeft", true);
        }
        else if (!isWalkLeft)
        {
            animator.SetBool("isWalkLeft", false);
        }

        if (isWalkRight)
        {
            animator.SetBool("isWalkRight", true);
        }
        else if (!isWalkRight)
        {
            animator.SetBool("isWalkRight", false);
        }
    }


    void SetAnimUp(InputAction.CallbackContext value)
    {
        value.ReadValueAsButton();
        isWalkUp = true;
    }

    void CancelAnimUp(InputAction.CallbackContext value)
    {
        value.ReadValueAsButton();
        isWalkUp = false;
    }

    void SetAnimDown(InputAction.CallbackContext value)
    {
        value.ReadValueAsButton();
        isWalkDown = true;
    }

    void CancelAnimDown(InputAction.CallbackContext value)
    {
        value.ReadValueAsButton();
        isWalkDown = false;
    }

    void SetAnimLeft(InputAction.CallbackContext value)
    {
        value.ReadValueAsButton();
        isWalkLeft = true;
    }

    void CancelAnimLeft(InputAction.CallbackContext value)
    {
        value.ReadValueAsButton();
        isWalkLeft = false;
    }

    void SetAnimRight(InputAction.CallbackContext value)
    {
        value.ReadValueAsButton();
        isWalkRight = true;
    }

    void CancelAnimRight(InputAction.CallbackContext value)
    {
        value.ReadValueAsButton();
        isWalkRight = false;
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
