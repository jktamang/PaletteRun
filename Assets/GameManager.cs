using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public GameObject player;
    [SerializeField]Transform playerSpawnPoint;
    [SerializeField]Transform blockSpawnPoint;
    
    void Start()
    {
    	block.GetComponent<Rigidbody2D>().isKinematic = true;
        player.transform.position = playerSpawnPoint.position;
        block.transform.position = blockSpawnPoint.position;
        Debug.Log("New Game!");
    }

    public void Reset()
    {
    	Start();
    }
}
