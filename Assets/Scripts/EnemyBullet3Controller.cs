using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet3Controller : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(RemoveBullet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RemoveBullet()
    {
        while (true)
        {
            Remove();
            yield return new WaitForSeconds(0.05f);
        }
    }
    
    void Remove()
    {
        float y = transform.position.y;
        float x = transform.position.x;
        float z = transform.position.z;
        if (y <= -5.5f)
        {
            Destroy(gameObject);
        }
        transform.position += (-new Vector3(0.2f, 1, 0)) * 0.1f;
    }
}