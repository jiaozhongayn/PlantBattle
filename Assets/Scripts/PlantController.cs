using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    public GameObject[] bullet;
    private ArrayList bullets = new();
    public GameObject kill;
    public GameObject bg;
    public GameObject enemyBornPoint;

    public Canvas canvas;
    public int curPlant = 0;

    public ScoreController ScoreController;
    //public GameObject UiTree;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4.33f, -1);
        StartCoroutine(Fire());
        ScoreController = GameObject.Find("Canvas").GetComponentInChildren<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        Remove();
    }

    void Remove()
    {
        Vector3 tarPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tarPos.z = -1;
        tarPos.x = Mathf.Clamp(tarPos.x, -1.85f, 1.85f);
        tarPos.y = Mathf.Clamp(tarPos.y, -4.33f, 4.33f);
        transform.position = tarPos;
    }

    GameObject CreatBullets()
    {
        GameObject bulletGameObject;
        Vector3 oriPos = transform.position + new Vector3(0, 1, 0);
        foreach (GameObject bullet in bullets)
        {
            if (bullet != null && !bullet.activeSelf)
            {
                bullet.transform.position = oriPos;
                bullet.SetActive(true);
                return bullet;
            }
        }

        bulletGameObject = Instantiate(bullet[curPlant], oriPos, quaternion.identity);
        bullets.Add(bulletGameObject);
        return bulletGameObject;
    }

    IEnumerator Fire()
    {
        while (true)
        {
            CreatBullets();
            yield return new WaitForSeconds(0.2f);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Enemy"))
        {
            GameObject effect = Instantiate(kill, transform.position - new Vector3(0, 0, 1), quaternion.identity, transform);
            // gameObject.GetComponent<PlantController>().enabled = false;
            // gameObject.SetActive(false);
            StartCoroutine(Ins());
        }
    }

    void Reset()
    {
        ScoreController.ResetScore();
        bg = GameObject.Find("BG");
        enemyBornPoint = GameObject.Find("EnemyBornPoint");
        var Bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bul in bullets)
        {
            Destroy(bul);
        }
        bg.SetActive(false);
        foreach (Transform child in enemyBornPoint.transform)
        {
            Destroy(child.gameObject);
        }
        enemyBornPoint.SetActive(false);
        //var UiTree = GameObject.Find("Canvas").GetComponentInChildren<CanvasGroup>();
        var UiTree = GameObject.Find("Canvas").GetComponentInChildren<CanvasGroup>();
        UiTree.alpha = 1;
    }
    
    IEnumerator WaitForNextFrame()
    {
        yield return new WaitForEndOfFrame();
    }

    public void setPlant(int i)
    {
        curPlant = i;
    }

    IEnumerator Ins()
    {
        // yield return new WaitForSeconds(3);
        Reset();
        //Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        //canvas.enabled = true;
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }
}
