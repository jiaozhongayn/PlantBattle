using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    public GameObject bg;

    public GameObject enemyBornPoint;

    public GameObject[] plants;

    public GameObject UiTree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset(int i)
    {
        Instantiate(plants[i], new Vector3(0, -4.33f, -1), quaternion.identity);
        bg.SetActive(true);
        enemyBornPoint.SetActive(true);
        //gameObject.GetComponent<Canvas>().enabled = false;
        UiTree.GetComponent<CanvasGroup>().alpha = 0;
        //UiTree.gameObject.SetActive(false);
    }
}
