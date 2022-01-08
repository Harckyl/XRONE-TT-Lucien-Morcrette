using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TPController : MonoBehaviour
{
    
    public CharacterController controller;
    //direction de la caméra 
    public Transform cam;
    //vitesse du personnage
    public float speed = 6f;
    //vitesse a laquelle le personnage se tourne vers la direction où il va
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    //pour la gravité
    public float gravity = -9.81f;
    Vector3 velocity;
    public float jumpForce = 10;
    //playerinput
    private PlayerInput playerInput;
    public PlayerInputActions playerInputActions;

    //pour le confort, pour que la souris soit invisible
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; //a mettre potentiellement pour cacher la souris mais pas forcément nécessaire 
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
    }
    
    void Update()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(inputVector[0], 0f, inputVector[1]);
        
        if (direction.magnitude >= 0.1f)
        {
            //pour récupérer l'angle dans lequel on va
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);


            //pour tourner le graphique du personnage dans la direction ou on va
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            //pour faire se déplacer le personnage
            Vector3 moveDir = Quaternion.Euler(0f,targetAngle,0f) * Vector3.forward; 
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            
            


        }
        //on cherche a ajouter de la gravité pour pouvoir tomber dans le tour par la suite
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); //parce que 1/2 * v * t²
    }
    public void Jump(InputAction.CallbackContext context)
    {
        
        //c'étiat pour tester le new input system
        if(context.performed)
        {
            Debug.Log("jump");
        }
    }
    //to move the player
    public void Move(InputAction.CallbackContext context)
    {
        

    }
}
