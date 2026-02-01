using UnityEngine;
using System.Collections.Generic;

public class MapCreator : MonoBehaviour
{
    [Header("Obstacle Prefabs")]
    public GameObject[] obstaclePrefabs;

    [Header("Pool Settings")]
    public int poolSizePerType;
    private List<GameObject> obstaclePool = new List<GameObject>();

    [Header("Obstacle Placement")]
    public float initial_distance;
    public float distance_between_rows;
    public float distance_inside_row;
    public int obstacle_per_row;

    [Header("Obstacle Boundaries")]
    public float bound_left;
    public float bound_right;
    public float bound_top;
    public float bound_bottom;

    private float z_distance;

    private void Start()
    {
        InitializePool();
        z_distance = initial_distance;

        int initial_row_num = (int)(0.8f * obstaclePool.Count / obstacle_per_row);
        for (int i = 1; i <= initial_row_num; i++)
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
    }

    public void createRow()
    {
        z_distance += distance_between_rows;
        for (int j = 0; j < obstacle_per_row; j++)
        {
            GameObject obstacle = GetObjectFromPool();
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
    }
    GameObject GetObjectFromPool()
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
}