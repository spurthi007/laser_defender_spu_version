using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 userInput;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    [SerializeField] float paddingLeft = 6f;
    [SerializeField] float paddingRight = 2f;
    [SerializeField] float paddingTop = 2f;
    [SerializeField] float paddingBottom = 2f;
    Camera mainCamera;
    [SerializeField] float moveSpeed = 10f;
    Shooter shooter;
    public bool isFiring = false;

    void Start()
    {
        //Debug.Log("Transform for Player is "+transform.up);
        mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
        minBounds.x += paddingRight;
        minBounds.y += paddingTop;
        maxBounds.x -= paddingLeft;
        maxBounds.y -= paddingBottom;
        shooter = GetComponent<Shooter>();
    }
    private void Update()
    {
        Movement();
    }

    private void OnMove(InputValue value)
    {
        userInput = value.Get<Vector2>();
    }

    private void OnFire(InputValue value)
    {
        if(value.isPressed)
        {
            shooter.Firing();
        }
    }

    //Instructor's version
    // void OnFire(InputValue value)
    // {
    //     if(shooter != null)
    //     {
    //         shooter.isFiring = value.isPressed;
    //     }
    // }

    private void Movement()
    {
        Vector2 userInput3d = moveSpeed * Time.deltaTime * userInput;
        float xMinBound = Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x);
        float yMinBound = Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y);
        Vector2 playerPos = new Vector2(xMinBound, yMinBound);
        transform.position = playerPos + userInput3d;
    }
}
