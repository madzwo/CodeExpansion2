using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private SpriteRenderer sr;
    private int lifeSpan;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f, .5f);
        lifeSpan = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeSpan < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifeSpan -= 1;
        }
    }
}
