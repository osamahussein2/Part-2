using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject axeWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnWeapon(float timer)
    {
        if (timer > 0)
        {
            Instantiate(axeWeapon, transform.position, Quaternion.identity);
        }
    }
}
