using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCreep2 : MonoBehaviour
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
        spawnTimer.Duration = 7;
        spawnTimer.Run();

        float timeIndex = PlayerPrefs.GetFloat("time");
        if (timeIndex > 0)
        {
            timer = timeIndex;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 30)
        {

            if (spawnTimer.Finished)
            {
                SpawnObject();
                spawnTimer.Duration = 7;
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
