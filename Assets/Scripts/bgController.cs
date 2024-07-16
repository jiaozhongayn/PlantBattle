using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgController : MonoBehaviour
{
    public GameObject bg;
    void Start()
    {
        StartCoroutine(BgStartRemove());
    }

    void RemoveBg()
    {
        float y = bg.transform.position.y;
        if (y >= 9.98f)
        {
            bg.transform.position = new Vector3(0, 0.05f, 0);
            return;
        }
        bg.transform.position = new Vector3(0, y+0.05f, 0);
    }

    IEnumerator BgStartRemove()
    {
        while (true)
        {
            RemoveBg();
            yield return new WaitForSeconds(0.05f);
        }
    }
}
