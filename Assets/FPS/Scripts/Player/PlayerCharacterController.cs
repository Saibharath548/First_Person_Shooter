using System;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    private CharacterController characterControllerComponent;

    [Header("Mannually Assign")]
    [SerializeField] private PlayerInputActions playerInputActions;

    [Header("Player Settings")]
    [SerializeField] private float playerSpeedMultiplier;
    [SerializeField] private float yAxis;
    [SerializeField] private float xAxis;

    private void Awake()
    {
        characterControllerComponent = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector3 normalisedMovementInput = playerInputActions.NormalisedPlayerInput();

        yAxis += Input.GetAxisRaw("Mouse X");
        xAxis += Input.GetAxisRaw("Mouse Y");

        xAxis = Mathf.Clamp(xAxis, -10, 10);

        transform.rotation = Quaternion.Euler(-xAxis, yAxis, 0);

        Vector3 playerForwardCalculation = normalisedMovementInput.x * Camera.main.transform.right + normalisedMovementInput.z * Camera.main.transform.forward;
        Vector3 movementDirection = new Vector3(playerForwardCalculation.x, normalisedMovementInput.y, playerForwardCalculation.z);

        characterControllerComponent.Move(movementDirection * playerSpeedMultiplier * Time.deltaTime);
        characterControllerComponent.SimpleMove(Vector3.zero);
    }

    public Vector3 GetPlayerCurrentVelocity()
    {
        Vector3 currentPlayerVelocity = characterControllerComponent.velocity;
        return currentPlayerVelocity;
    }

}
