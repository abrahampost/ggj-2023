using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    public GameObject bullet;
    public float launchVelocity;
    public string keyBind;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(keyBind))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
