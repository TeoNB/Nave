using UnityEngine;

public class Controllaser : MonoBehaviour
{
    public GameManager gamemanager;
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            gamemanager.AddScore(10);
            Destroy(collision.gameObject);
            Destroy(gameObject);
		}
		
    }  




}
