using UnityEngine;
using System.Collections.Generic;

public class MapCreator : MonoBehaviour
{
    [Header("Coin Prefabs")]
    public GameObject coinPrefab;
    public int coinPoolSize;
    public int howManyRowPerCoin;
    public int coinPlacementDeviation;
    private List<GameObject> coinPool = new List<GameObject>();
    private int next_row_for_coin;

    [Header("Obstacle Prefabs")]
    public GameObject[] obstaclePrefabs;

    [Header("Obstacle Pool Settings")]
    public int poolSizePerType;
    private List<GameObject> obstaclePool = new List<GameObject>();

    [Header("Obstacle Placement")]
    public float initial_distance;
    public float distance_between_rows;
    public float distance_inside_row;
    public int obstacle_per_row;

    [Header("Map Boundaries")]
    public float bound_left;
    public float bound_right;
    public float bound_top;
    public float bound_bottom;

    private float z_distance;
    private int index;

    private void Start()
    {
        next_row_for_coin = howManyRowPerCoin + Random.Range(-coinPlacementDeviation, coinPlacementDeviation);

        InitializePool();
        z_distance = initial_distance;
        index = 1;

        int initial_row_num = (int)(0.8f * obstaclePool.Count / obstacle_per_row);
        while (index <= initial_row_num)
        {
            createRow();
        }
    }

    private void Update()
    {
        if (GetPassiveObstacleCount() >= 3 * obstacle_per_row) // if there is enough obstacle to create a full row
        {
            createRow();
        }
    }

    int GetPassiveObstacleCount() // count how many passive object
    {
        int count = 0;
        for (int i = 0; i < obstaclePool.Count; i++)
        {
            if (!obstaclePool[i].activeInHierarchy)
            {
                count++;
            }
        }
        return count;
    }

    void InitializePool()
    {
        foreach (GameObject prefab in obstaclePrefabs)
        {
            for (int i = 0; i < poolSizePerType; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                obstaclePool.Add(obj);
            }
        }
        for (int i = 0; i < coinPoolSize; i++)
        {
            GameObject obj = Instantiate(coinPrefab);
            obj.SetActive(false);
            coinPool.Add(obj);
        }
    }

    public void createRow()
    {
        for (int j = 0; j < obstacle_per_row; j++) // obstacle
        {
            GameObject obstacle = GetObstacleFromPool();
            if (obstacle != null)
            {
                Vector3 location = new Vector3(
                    Random.Range(bound_left, bound_right),
                    Random.Range(bound_bottom, bound_top),
                    z_distance + Random.Range(-distance_inside_row, distance_inside_row)
                );

                obstacle.transform.position = location;
                obstacle.SetActive(true);
            }
        }
        if (index == next_row_for_coin) // coin
        {
            Debug.Log("coin yapýlýyor!!!");
            GameObject coin = GetCoinFromPool();
            if(coin != null)
            {
                Debug.Log("coin oluþturuldu!");
                Vector3 location = new Vector3(
                    Random.Range(bound_left, bound_right),
                    Random.Range(bound_bottom, bound_top),
                    z_distance + Random.Range(-distance_inside_row, distance_inside_row)
                );
                coin.transform.position = location;
                coin.SetActive(true);
                next_row_for_coin += howManyRowPerCoin + Random.Range(-coinPlacementDeviation, coinPlacementDeviation);
            }
            else
            {
                next_row_for_coin++;
            }
        }

        z_distance += distance_between_rows;
        index++;
    }
    GameObject GetObstacleFromPool()
    {
        int randomIndex = Random.Range(0, obstaclePool.Count);
        for (int i = 0; i < obstaclePool.Count; i++)
        {
            int index = (randomIndex + i) % obstaclePool.Count;
            if (!obstaclePool[index].activeInHierarchy)
            {
                return obstaclePool[index];
            }
        }
        return null;
    }
    GameObject GetCoinFromPool()
    {
        int randomIndex = Random.Range(0, coinPool.Count);
        for (int i = 0; i < coinPool.Count; i++)
        {
            if (!coinPool[i].activeInHierarchy)
            {
                return coinPool[i];
            }
        }
        return null;
    }
}