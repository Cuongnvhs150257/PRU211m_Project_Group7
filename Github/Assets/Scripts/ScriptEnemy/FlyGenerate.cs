using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyGenerate : MonoBehaviour
{
    const int SpawnBorderSize = 100;
    int minSpawnX;
    int minSpawnY;
    int maxSpawnX;
    int maxSpawnY;
    Timer spawnTimer;
    [SerializeField]
    GameObject enemy;

    private float timer;

    void Start()
    {
        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - SpawnBorderSize;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;

        //create and start timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = 5;
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= 60)
        {

            if (spawnTimer.Finished)
            {
                SpawnObject();
                spawnTimer.Duration = 5;
                spawnTimer.Run();
            }
        }
    }

    void SpawnObject()
    {
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY),
               -Camera.main.transform.position.z);//z should be zero
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        GameObject objectRender = Instantiate<GameObject>(enemy, worldLocation, Quaternion.identity); ;
    }
}
