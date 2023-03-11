using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    // The prefab of the item to spawn
    public List<GameObject> itemPrefab;

    public GameObject quad;

    // The number of items to spawn
    public int itemCount = 10;

    // The size of the map (assuming it is a square)
    public float mapSize = 100f;

    // The minimum distance between items
    public float minDistance = 5f;

    //Time between 2 spams
    Timer spawmTimer;

    //Time to detroy items
    Timer detroyTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawmTimer = gameObject.GetComponent<Timer>();
        detroyTimer = gameObject.GetComponent<Timer>();
        spawmTimer.Duration = 5;
        spawmTimer.Run();
        detroyTimer.Duration = 10;
        detroyTimer.Run();
    }

    void Update()
    {
        if (detroyTimer.Finished)
        {
            detroyItems();
        }

        if (spawmTimer.Finished)
        {
            spawmItem();
            spawmTimer.Duration = 15;
            spawmTimer.Run();

            detroyTimer.Duration = 10;
            detroyTimer.Run();
            
        }
        
    }

    private void spawmItem()
    {

        // Spawn items randomly on the map
        for (int i = 0; i < itemCount; i++)
        {
            // Generate a random position on the map
            Vector2 position = new Vector2(Random.Range(-mapSize / 2f, mapSize / 2f), Random.Range(-mapSize / 2f, mapSize / 2f));

            // Check if the position is too close to any existing item
            bool tooClose = false;
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("items"))
            {
                if (Vector2.Distance(position, item.transform.position) < minDistance)
                {
                    tooClose = true;
                    break;
                }
            }


            int randomItem = 0;
            GameObject toSpawn;
            MeshCollider c = quad.GetComponent<MeshCollider>();

            randomItem = Random.Range(0, itemPrefab.Count);
            toSpawn = itemPrefab[randomItem];

            // If the position is not too close, spawn an item there
            if (!tooClose)
            {
                Instantiate(toSpawn, position, Quaternion.identity);
            }
        }
    }

    private void detroyItems()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("items"))
        {
            Destroy(o);
        }
    }
}
