using UnityEngine;
using UnityEngine.InputSystem;
public class Movimiento : MonoBehaviour
{
    private PlayerInput playerInput;
	private Rigidbody2D rb;
    Vector2 Move;
    public float velocidad;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();


	}

	private void Update()
	{
		Move = playerInput.actions["Move"].ReadValue<Vector2>();
	}
	// Update is called once per frame
	void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(Move.x * velocidad, Move.y * velocidad);
    }

    

}
