using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
   [SerializeField] private GameObject enemyPrefab;

   private void Start()
   {
      GameObject enemy;
      enemy = Instantiate(enemyPrefab,new Vector3(transform.position.x, transform.position.y + 10, transform.position.z) , Quaternion.identity, this.transform);
   }
}
