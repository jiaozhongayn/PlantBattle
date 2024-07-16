using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
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
            yield return new WaitForSeconds(0.01f);
        }
    }
    
    void Remove()
    {
        float y = transform.position.y;
        float x = transform.position.x;
        float z = transform.position.z;
        if (y >= 5.6f)
        {
            transform.gameObject.SetActive(false);
            StopCoroutine(RemoveBullet());
        }
        transform.position = new Vector3(x, y+0.6f, z);
    }

    
}
