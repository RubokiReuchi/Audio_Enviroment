using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolBell : MonoBehaviour
{
    float cd;

    // Start is called before the first frame update
    void Start()
    {
        cd = Random.Range(60, 180);
    }

    // Update is called once per frame
    void Update()
    {
        cd -= Time.deltaTime;

        if (cd < 0)
        {
            cd = Random.Range(60, 180);
            GetComponent<AudioSource>().Play();
        }
    }
}
