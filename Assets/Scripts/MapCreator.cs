using UnityEngine;

public class MapCreator : MonoBehaviour
{
    [Header("Obstacles")]
    public GameObject[] obstacles;
    [Header("Obstacle Placement")]
    public float distance_between_obstacles;
    public int initial_row_num;
    public int obstacle_per_row;
    public int additional_row_num;
    public float additional_row_time;
    [Header("Obstacle Boundaries")]
    public int bound_left;
    public float bound_right;
    public float bound_top;
    public float bound_bottom;

    private int iterator;
    private void Start()
    {
        for (iterator = 1; iterator <= initial_row_num; iterator++)
        {
            createRow(iterator);
        }
        Debug.Log("Ýterator is: " + iterator);
    }
    public void createRow(int rowNum)
    {
        float z_distance = distance_between_obstacles * rowNum;
        for (int j = 0; j < obstacle_per_row; j++)
        {
            int i = Random.Range(0, obstacles.Length); // which obstacle?
            Vector3 location = new Vector3(
                Random.Range(bound_left, bound_right),
                Random.Range(bound_bottom, bound_top),
                z_distance
            );
            
            Instantiate(obstacles[i], location, obstacles[i].transform.rotation);
        }
    }
}
