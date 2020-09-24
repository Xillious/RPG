using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayer : MonoBehaviour
{

    private KeyCode forward = KeyCode.W;
    private Rigidbody2D rb;

    private Vector2 velocity;

    Vector2 mousePosition;

    private bool isFacingRight = true;

    public GameObject weapon;
    private Vector2 movement;

    [SerializeField] private float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GetInput();
        Flip();
    }

    private void FixedUpdate()
    {
        Rotation();
        Movement();
    }

    void GetInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.W))
        {

        }
        if (Input.GetKey(KeyCode.A))
        {

        }
        if (Input.GetKey(KeyCode.S))
        {

        }
        if (Input.GetKey(KeyCode.D))
        {

        }
    }

    void Movement()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    void Rotation()
    {
        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        weapon.transform.rotation = Quaternion.Euler(0, 0, angle);
        //rb.rotation = angle;
    }

    void Flip()
    {

        if (mousePosition.x > transform.position.x && isFacingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            isFacingRight = false;
        }
        else if (mousePosition.x < transform.position.x && !isFacingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            isFacingRight = true;
        }

    }
}
