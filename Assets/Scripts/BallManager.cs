using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public Transform spawnGroup;
    public List<Transform> spawnPosition;
    public List<GameObject> template;
    private List<GameObject> ballList;
    public int maxBall;
    public int spawnInterval;
    private float timer;

    void Start()
    {
        ballList = new List<GameObject>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > spawnInterval)
        {
            GenerateBall();
            timer -= spawnInterval;
        }
    }

    void GenerateBall()
    {
        if (ballList.Count >= maxBall)
        {
            return;
        }

        int randIndex = Random.Range(0, spawnPosition.Count);
        Transform result = spawnPosition[randIndex];

        //Agar tidak tabrakan dengan objek yang ada di tiap sudut
        int offset = 2;
        Vector3 spawnOffset = Vector3.zero;

        if (result == spawnPosition[0])
        {
            spawnOffset = new Vector3(result.position.x + offset, result.position.y, result.position.z - offset);
        } 
        if (result == spawnPosition[1])
        {
            spawnOffset = new Vector3(result.position.x - offset, result.position.y, result.position.z - offset);
        } 
        if (result == spawnPosition[2])
        {
            spawnOffset = new Vector3(result.position.x + offset, result.position.y, result.position.z + offset);
        } 
        if (result == spawnPosition[3])
        {
            spawnOffset = new Vector3(result.position.x - offset, result.position.y, result.position.z + offset);
        }

        GameObject ball = Instantiate(template[0], spawnOffset, Quaternion.identity, spawnGroup);
        ball.SetActive(true);
        ballList.Add(ball);
    }

    public void RemoveBall(GameObject ball)
    {
        ballList.Remove(ball);
        Destroy(ball);
    }
}
