using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour
{
    public GameObject squid;
    public float maxHorizontalOffset;
    public float spawnEveryXUnitsMin;
    public float spawnEveryXUnitsMax;
    public float heightOffset;
    public Transform[] platforms;
    GameManager gameManager;

    float lastSpawn;
    float spawnEveryXUnits;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lastSpawn = transform.position.y;
        spawnEveryXUnits = Random.Range(spawnEveryXUnitsMin, spawnEveryXUnitsMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameOver || gameManager.isGamePaused) return;

        if (squid.transform.position.y > lastSpawn + spawnEveryXUnits + 0.5f)
        {
            Spawn();
            lastSpawn += spawnEveryXUnits;
            spawnEveryXUnits = Random.Range(spawnEveryXUnitsMin, spawnEveryXUnitsMax);
        }
    }

    public void Spawn()
    {
        var platformprefab = platforms[0];

        if (squid.transform.position.y > 50)
            platformprefab = platforms[Random.Range(0, platforms.Length - 1)];
        if (squid.transform.position.y > 100)
            platformprefab = platforms[Random.Range(0, platforms.Length)];

        var location = new Vector3(
            transform.position.x + Random.Range(-maxHorizontalOffset, maxHorizontalOffset),
        lastSpawn + spawnEveryXUnits + heightOffset,
        transform.position.z);

        var new_platform = Instantiate(platformprefab, location, gameObject.transform.rotation) as GameObject;

        //   new_platform.transform.position.y = new_platform.transform.position.y + Random.Range(2,4);
    }
}
