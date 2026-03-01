using UnityEngine;
using UnityEngine.InputSystem;
public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 Move;
    public float velocidad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        rb.linearVelocity = new Vector2(Move.x * velocidad, Move.y * velocidad);
    }

    void OnMove(InputValue value)
    {
        Move = value.Get<Vector2>();
    }

}
