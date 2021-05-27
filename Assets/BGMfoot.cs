using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMfoot : MonoBehaviour
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
        if (unitychan.transform.position.y < -3.7  || - 3.4 < unitychan.transform.position.y )
        {
            GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            GetComponent<AudioSource>().volume = 1;
        }
    }
}
