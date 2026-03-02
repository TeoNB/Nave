using System.Collections;
using UnityEngine;

public class MovimientoAsteroide : MonoBehaviour
{
    Rigidbody2D rbAsteroid;
    private float randomX;
    private Vector2 destino;
    float duracion;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        rbAsteroid = GetComponent<Rigidbody2D>();
        randomX = Random.Range(-4.5f, 4.5f);
        destino = new Vector2(randomX, -6);
        duracion = 3f;
		StopAllCoroutines();
        StartCoroutine(moveAsteroid(destino, duracion));
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (transform.position.y <= -6)
        {
            Destroy(gameObject);
        }*/
    }

    private IEnumerator moveAsteroid (Vector2 destino, float duracion)
    {
        float tiempoActual = 0f;
        Vector2 Inicio = rbAsteroid.position;

        while (tiempoActual < duracion)
        {
            tiempoActual += Time.deltaTime;
            float t = Mathf.Clamp01(tiempoActual /  duracion);
            Vector2 nuevaPos = Vector2.Lerp(Inicio, destino, t);
            rbAsteroid.MovePosition(nuevaPos);
            yield return new WaitForFixedUpdate();
        }
        rbAsteroid.MovePosition(destino);
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
        Debug.Log("Colision con: " + collision.gameObject.name);
	}
}
