using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement1 : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    public float jumpButtonGracePeriod;
    [SerializeField] private float _maxHealth = 10;
    
    

    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    private float _currentHealth;
    [SerializeField] private HealthBar _healthbar;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;

        _currentHealth = _maxHealth;

        _healthbar. UpdateHealthBar(_maxHealth, _currentHealth);
    }

    private void OnCollision(Collision collision)
    {
        _currentHealth -= Random.Range(0.5f, 1.5f);

        if(_currentHealth <= 0) 
        {
            
            Destroy(gameObject);
        }
        else 
        {
            _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);
            
            
        }
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded) 
        {
            lastGroundedTime = Time.time;
        }
         
        if (Input.GetButtonDown("Jump")) 
        {
            jumpButtonPressedTime = Time.time;
        }

        if (Time.deltaTime - lastGroundedTime <= jumpButtonGracePeriod) 
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod) 
            {
                ySpeed = jumpSpeed;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else 
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else 
        {
            animator.SetBool("IsMoving", false);
        }
    }
}
