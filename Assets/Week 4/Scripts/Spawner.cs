using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float TimerValue;
    float TimerTarget = 5;

    public GameObject[] planeSprites;
    float planeIndex;

    // Start is called before the first frame update
    void Start()
    {
        planeSprites[0].transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        planeSprites[0].transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

        planeSprites[1].transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        planeSprites[1].transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

        planeSprites[2].transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        planeSprites[2].transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

        planeSprites[3].transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        planeSprites[3].transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

        planeSprites[4].transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        planeSprites[4].transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

        planeIndex = Random.Range(0, 5);
    }

    // Update is called once per frame
    void Update()
    {

        planeIndex = Random.Range(0, 5);

        TimerValue += Time.deltaTime;

        if(TimerValue > TimerTarget)
        {
            if (planeIndex == 0)
            {
                planeSprites[0].transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
                planeSprites[0].transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

                Instantiate(planeSprites[0]);
                TimerValue = 0;
                TimerTarget = Random.Range(1, 5);
            }

            if (planeIndex == 1)
            {
                planeSprites[1].transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
                planeSprites[1].transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

                Instantiate(planeSprites[1]);
                TimerValue = 0;
                TimerTarget = Random.Range(1, 5);
            }

            if (planeIndex == 2)
            {
                planeSprites[2].transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
                planeSprites[2].transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

                Instantiate(planeSprites[2]);
                TimerValue = 0;
                TimerTarget = Random.Range(1, 5);
            }

            if (planeIndex == 3)
            {
                planeSprites[3].transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
                planeSprites[3].transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

                Instantiate(planeSprites[3]);
                TimerValue = 0;
                TimerTarget = Random.Range(1, 5);
            }

            if (planeIndex == 4)
            {
                planeSprites[4].transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
                planeSprites[4].transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

                Instantiate(planeSprites[4]);
                TimerValue = 0;
                TimerTarget = Random.Range(1, 5);
            }
        }
    }
}
