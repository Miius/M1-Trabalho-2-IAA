using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    private void Start()
    {
        GameObject player;
        player = Instantiate(playerPrefab,new Vector3(transform.position.x, transform.position.y + 10, transform.position.z) , Quaternion.identity, this.transform);
    }
}
