using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBornController : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnEnable()
    {
        StartCoroutine(CreateEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator CreateEnemy()
    {
        while(true)
        {
            float randomX = Random.Range(-1.85f, 1.85f);
            GameObject enemyIns = Instantiate(enemy,
                new Vector3(randomX, transform.position.y, transform.position.z), Quaternion.identity, transform);
            yield return new WaitForSeconds(2f);
        }
    }
}
