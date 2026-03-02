using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    public float tiempospawn;
    public GameObject AsterMed3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("spawnAsteroid", 1, tiempospawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnAsteroid ()
    {
        float posicionX = Random.Range(-4.5f, 4.5f);
        Instantiate(AsterMed3, new Vector2(posicionX,6), Quaternion.identity);
    }

}
