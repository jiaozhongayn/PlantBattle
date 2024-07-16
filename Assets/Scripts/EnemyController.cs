using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public GameObject kill;

    public GameObject bullet;

    public GameObject bullet1;

    public GameObject bullet2;

    public int score;

    public Text text;
    
    public ScoreController ScoreController;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine($"Fire{Random.Range(1, 4)}");
        StartCoroutine(DestorySelf());
        text = GameObject.Find("Canvas").GetComponentInChildren<Text>();
        ScoreController = GameObject.Find("Canvas").GetComponentInChildren<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Bullet") && transform.position.y <= 5)
        {
            Destroy(target.gameObject);
            GameObject effect = Instantiate(kill, transform.position - new Vector3(0, 0, 1), quaternion.identity);
            //text.text = $"得分： {++score}";
            ScoreController.AddScore();
            Destroy(transform.gameObject);
        }
    }

    void CreateBullet1()
    {
        GameObject bulletIns = Instantiate(bullet, transform.position - new Vector3(0, 0.5f, 0), bullet.transform.rotation, transform.parent);
    }

    IEnumerator Fire1()
    {
        while (true)
        {
            CreateBullet1();
            yield return new WaitForSeconds(2f);
        }
    }
    
    IEnumerator DestorySelf()
    {
        while (true)
        {
            transform.position += Vector3.down * 0.1f;
            if(transform.position.y <= -5.5f)
                Destroy(gameObject);
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    void CreateBullet2()
    {
        GameObject bulletIns = Instantiate(bullet1, transform.position - new Vector3(0, 0.5f, 0), bullet.transform.rotation, transform.parent);
        bulletIns.transform.Rotate(0, 0, 18);
        GameObject bulletIns2 = Instantiate(bullet2, transform.position - new Vector3(0, 0.5f, 0), bullet.transform.rotation, transform.parent);
        bulletIns2.transform.Rotate(0, 0, -18);
        GameObject bulletIns3 = Instantiate(bullet, transform.position - new Vector3(0, 0.5f, 0), bullet.transform.rotation, transform.parent);
    }

    IEnumerator Fire2()
    {
        while (true)
        {
            CreateBullet2();
            yield return new WaitForSeconds(2f);
        }
    }
    
    void CreateBullet3()
    {
        GameObject bulletIns = Instantiate(bullet, transform.position - new Vector3(-0.1f, 0.5f, 0), bullet.transform.rotation, transform.parent);
        GameObject bulletIns2 = Instantiate(bullet, transform.position - new Vector3(0.1f, 0.5f, 0), bullet.transform.rotation, transform.parent);
    }

    IEnumerator Fire3()
    {
        while (true)
        {
            CreateBullet3();
            yield return new WaitForSeconds(2f);
        }
    }

}
