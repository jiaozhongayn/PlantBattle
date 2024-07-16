using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public Sprite endSprite;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestorySelf());
    }

    IEnumerator DestorySelf()
    {
        while (true)
        {
            Sprite curSprite = GetComponent<SpriteRenderer>().sprite;
            if (curSprite == endSprite)
            {
                Destroy(gameObject);
                yield break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
