using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;
    private void Awake()
    {
        Instance = this;
    }

    public GameObject obstaclePrefab;
    public List<GameObject> obstacleList = new List<GameObject>();


    public GameObject lastObstacle;

    public List<GameObject> groundList;
    public GameObject firstGround, midGround, lastGround;

    public int obstacleCount;
    public int lineWidth;

    // Start is called before the first frame update
    void Start()
    {
        InitializeObstacles();
    }

    void InitializeObstacles()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleList.Add(Instantiate(obstaclePrefab));
            obstacleList[i].transform.position = i == 0 ?
                new Vector3(Random.Range(-lineWidth , lineWidth )+.5f, 0, 5) :
                obstacleList[i - 1].transform.position + Vector3.forward * 10 + Vector3.right * (.5f-obstacleList[i - 1].transform.position.x+Random.Range(-lineWidth , lineWidth ));
        }
        lastObstacle = obstacleList[obstacleCount - 1];
    }

    private void Update()
    {
        if (FindObjectOfType<CarController>().transform.position.z-firstGround.transform.position.z>30)
        {
            firstGround.transform.position = lastGround.transform.position + 
                (-firstGround.transform.position + midGround.transform.position);
            var l = lastGround;

            lastGround = firstGround;
            firstGround = midGround;
            midGround = l;
        }
    }
}
