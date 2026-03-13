using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private Vector2 movementInput;
    private Animator animator;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        
    }

   void Update()
    {
        //Obtenimos el input de movimiento del jugador
        movementInput = playerInput.actions["Move"].ReadValue<Vector2>();
        // Actualizamos el parámetro de velocidad en el Animator para controlar las animaciones de movimiento
        animator.SetFloat("velocityX", Mathf.Abs(movementInput.x));
        if(movementInput.x > 0)
        {
            // Si el jugador se mueve hacia la derecha, aseguramos que la escala del sprite esté orientada hacia la derecha
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(movementInput.x < 0)
        {
            // Si el jugador se mueve hacia la izquierda, invertimos la escala del sprite para que mire hacia la izquierda
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
 void FixedUpdate()
    {
        //Aplicamos el movimiento al Rigidbody2D
        rb.linearVelocity = new Vector2(movementInput.x * moveSpeed, rb.linearVelocity.y);
        
        
    }

}