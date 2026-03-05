using System.Collections;
using UnityEngine;
using TMPro;

public class MovimientoAsteroide : MonoBehaviour
{
    public GameManager gamemanager;
	Rigidbody2D rbAsteroid;
    private float randomX;
    private Vector2 destino;
    float duracion;
    public TextMeshProUGUI gameoverText;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
        rbAsteroid = GetComponent<Rigidbody2D>();
        randomX = Random.Range(-4.5f, 4.5f);
        destino = new Vector2(randomX, -6);
		//destino = new Vector2(transform.position.x, -6);
		duracion = 3f;
		StopAllCoroutines();
        StartCoroutine(moveAsteroid(destino, duracion));
        
    }

    // Update is called once per frame
    void Update()
    {
		// El asteroide se mueve hacia abajo, y si llega a una posición específica, se destruye
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

	// Detecta colisiones con otros objetos, y si el objeto tiene la etiqueta "Destroy", se destruye a sí mismo
	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
        Debug.Log("Colision con: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            gamemanager.GameOver();
			Destroy(collision.gameObject);

            CancelInvoke("spawnAsteroid");
            Destroy(gameObject);

		}
	}

	
}
