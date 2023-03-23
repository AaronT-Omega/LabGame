using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public float moveSpeed = 15f;

  

    public Rigidbody2D rb;
    public InputAction playerControls;
    public bool canMove = true;

    private Vector2 mousePosition;
    public Camera sceneCamera;
    public Gun weapon;

    Vector2 moveDirection = Vector2.zero;
    

    void Start()
    {

    }

    public void OnEnable()
    {
        playerControls.Enable();
    }

    public void OnDisable()
    {
        playerControls.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }

    private void Move()
    {
        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        moveDirection = playerControls.ReadValue<Vector2>();
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}
