using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    float x;
    float y;
    float z;

    Object obj11;
    Object obj12;
    Object obj13;

    Object obj21;
    Object obj22;
    Object obj23;

    Object obj31;
    Object obj32;
    Object obj33;

    Object sun;

    bool t11 = false;
    bool t12 = false;
    bool t13 = false;

    bool t21 = false;
    bool t22 = false;
    bool t23 = false;

    bool t31 = false;
    bool t32 = false;
    bool t33 = false;

    bool sunT = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;

        ter();

        new WaitForSeconds(5);
    }

    void ter()
    {
        if (-5000 < x & x < 1000 & 1000 < z & z < 7000 & t11 == false)
        {
            obj11 = Resources.Load("1-1");
            Instantiate(obj11);
            t11 = true;
        }
        if (-5000 > x & x > 1000 & 1000 > z & z > 7000 & t11 == true)
        {
            Destroy(obj11);
            Resources.UnloadAsset(obj11);
            t11 = false;
        }

        if (-1000 < x & x < 4000 & 1000 < z & z < 7000 & t12 == false)
        {
            obj12 = Resources.Load("1-2");
            Instantiate(obj12);
            t12 = true;
        }
        if (-1000 > x & x > 4000 & 1000 > z & z > 7000 & t12 == true)
        {
            Destroy(obj12);
            Resources.UnloadAsset(obj12);
            t12 = false;
        }

        if (2000 < x & x < 8000 & 1000 < z & z < 7000 & t13 == false)
        {
            obj13 = Resources.Load("1-3");
            Instantiate(obj13);
            t13 = true;
        }
        if (2000 > x & x > 8000 & 1000 > z & z > 7000 & t13 == true)
        {
            Destroy(obj13);
            Resources.UnloadAsset(obj13);
            t13 = false;
        }

        if (-5000 < x & x < 1000 & -2000 < z & z < 3000 & t21 == false)
        {
            obj21 = Resources.Load("2-1");
            Instantiate(obj21);
            t21 = true;
        }
        if (-5000 > x & x > 1000 & -2000 > z & z > 3000 & t21 == true)
        {
            Destroy(obj21);
            Resources.UnloadAsset(obj21);
            t21 = false;
        }

        if (-1000 < x & x < 4000 & -2000 < z & z < 3000 & t22 == false)
        {
            obj22 = Resources.Load("2-2");
            Instantiate(obj22);
            t22 = true;
        }
        if (-1000 > x & x > 4000 & -2000 > z & z > 3000 & t22 == true)
        {
            Destroy(obj22);
            Resources.UnloadAsset(obj22);
            t22 = false;
        }

        if (2000 < x & x < 8000 & -2000 < z & z < 3000 & t23 == false)
        {
            obj23 = Resources.Load("2-3");
            Instantiate(obj23);
            t23 = true;
        }
        if (2000 > x & x > 8000 & -2000 > z & z > 3000 & t23 == true)
        {
            Destroy(obj23);
            Resources.UnloadAsset(obj23);
            t23 = false;
        }

        if (-5000 < x & x < 1000 & -6000 < z & z < 0 & t31 == false)
        {
            obj31 = Resources.Load("3-1");
            Instantiate(obj31);
            t31 = true;
        }
        if (-5000 > x & x > 1000 & -6000 > z & z > 0 & t31 == true)
        {
            Destroy(obj31);
            Resources.UnloadAsset(obj31);
            t31 = false;
        }

        if (-1000 < x & x < 4000 & -6000 < z & z < 0 & t32 == false)
        {
            obj32 = Resources.Load("3-2");
            Instantiate(obj32);
            t32 = true;
        }
        if (-1000 > x & x > 4000 & -6000 > z & z > 0 & t32 == true)
        {
            Destroy(obj32);
            Resources.UnloadAsset(obj32);
            t32 = false;
        }

        if (2000 < x & x < 8000 & -6000 < z & z < 0 & t33 == false)
        {
            obj33 = Resources.Load("3-3");
            Instantiate(obj33);
            t33 = true;
        }
        if (2000 > x & x > 8000 & -6000 > z & z > 0 & t33 == true)
        {
            Destroy(obj33);
            Resources.UnloadAsset(obj33);
            t33 = false;
        }
        /*sun
        if (1100 < x & x < 2000 & 250 < y & y < 400 & 600 < z & z < 1500 & sunT == false)
        {
            sun = Resources.Load("Sun_city");
            Instantiate(sun);
            sunT = true;
        }
        if (1100 > x & x > 2000 & 250 > y & y > 400 & 600 > z & z > 1500 & sunT == true)
        {
            Destroy(sun);
            Resources.UnloadAsset(sun);
            sunT = false;
        }*/
    }
}
