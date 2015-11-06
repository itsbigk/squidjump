using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour
{
    public GameObject squid;
    public float maxHorizontalOffset;
    public float spawnEveryXUnitsMin;
    public float spawnEveryXUnitsMax;
    public float heightOffset;
    public GameObject[] platforms;
    public GameObject[] powerups;
    public float[] chance;
    public float[] minHeight;
    //  public float[] value;
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
        var platform = platforms[0];

        if (squid.transform.position.y > 100)
            platform = platforms[Random.Range(0, platforms.Length - 2)];
        if (squid.transform.position.y > 200)
            platform = platforms[Random.Range(0, platforms.Length - 1)];
        if (squid.transform.position.y > 300)
            platform = platforms[Random.Range(0, platforms.Length)];

        var location = new Vector3(
            transform.position.x + Random.Range(-maxHorizontalOffset, maxHorizontalOffset),
        lastSpawn + spawnEveryXUnits + heightOffset,
        transform.position.z);

        SimplePool.Spawn(platform, location, Quaternion.identity);
        
        TrySpawnPowerup();
    }

    void TrySpawnPowerup()
    {
        var random = Random.Range(0, 100);

        for (int i = 0; i < chance.Length; i++)
        {
            if (minHeight[i] > squid.transform.position.y) continue;

            if (chance[i] > random)
            {
                SpawnPowerup(i);
            }
        }
    }

    void SpawnPowerup(int index)
    {
        var prefab = powerups[index];

        var location = new Vector3(
            transform.position.x + Random.Range(-maxHorizontalOffset, maxHorizontalOffset),
        lastSpawn + 13,
        transform.position.z);

        SimplePool.Spawn(prefab, location, Quaternion.identity);
    }
}
