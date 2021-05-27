using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{

    private GameObject unitychan;

    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("UnityChan2D");
    }

    // Update is called once per frame
    void Update()
    {
        if (unitychan != null && unitychan.transform.position.x < -10)
        {
            GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            GetComponent<AudioSource>().volume = 0.15f;
        }
    }
}
