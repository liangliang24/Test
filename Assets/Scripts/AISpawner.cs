using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    [SerializeField]
    GameObject TargetPlayer;

    [SerializeField]
    Knight AI;

    // Start is called before the first frame update
    void Start()
    {
        if (TargetPlayer == null)
            Debug.LogError("Please Set TargetPlayer!!!");

        //AI = new Knight();
        InvokeRepeating("SpawnAI", 1, 0.05f);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SpawnAI()
    {
        //Quaternion quaternion
        Vector3 position = TargetPlayer.transform.position;
        bool isChange = false;
        if (Random.Range(0, 2) == 1)
        {
            isChange = true;
            position.x += Random.Range(0, 2) == 1 ? 10 : -10;
        }
        if (Random.Range(0, 2) == 1)
        {
            isChange = true;
            position.y += Random.Range(0, 2) == 1 ? 10 : -10;
        }
        if(!isChange)
        {
            return false;
        }
        position.x *= 2;
        position.y *= 2;
        Knight temp = Instantiate<Knight>(AI, position, Quaternion.identity);
        if (temp == null)
        {
            return false;
        }
        temp.TargetPlayer = TargetPlayer;
        //Debug.Log("Spawn Success");
        return true;
    }

}
