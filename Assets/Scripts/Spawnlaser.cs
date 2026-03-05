using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Spawnlaser : MonoBehaviour
{
    public GameObject laserPrefab;
    private PlayerInput playerInput;
    bool disparar = true;
    float tiempodisparo = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.actions["Attack"].WasPressedThisFrame() && disparar)
        {
            Instantiate(laserPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            disparar = false;
            StartCoroutine(cambiardisparo());
        }
    }

    IEnumerator cambiardisparo()
    {
        yield return new WaitForSeconds(tiempodisparo);
        disparar=true;
    }


}