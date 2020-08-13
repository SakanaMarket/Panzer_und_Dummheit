using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int num_teams;
    public int num_tanks_per;
    private bool spawn;
    private bool no_more;
    public GameObject tanks;
    void Start()
    {
        spawn = false;
        no_more = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (num_teams != 0 && spawn == false && no_more == false)
        {
            spawn = true;         
        }
        else if (num_teams != 0 && spawn == true && no_more == false)
        {
            no_more = true;
            for (int i = 0; i < num_teams; i++)
            {
                for (int x = 0; x < num_tanks_per; x++)
                {
                    int rand_x = Random.Range(-19, -11);
                    int rand_z = Random.Range(-5, -12);
                    GameObject mytank = Instantiate(tanks, new Vector3(rand_x, -12.957f, rand_z), Quaternion.identity);
                    if (i == 0)
                    {
                        //GameObject mytank = Instantiate(tanks, new Vector3(-19f, -12.957f, rand_z), Quaternion.identity);
                        
                        mytank.tag = "Player1";
                        mytank.name = "Team1:" + x;
                    }
                    else if (i == 1)
                    {
                        //GameObject mytank = Instantiate(tanks, new Vector3(rand_x, -12.957f, -5), Quaternion.identity);
                        
                        mytank.tag = "Player2";
                        mytank.name = "Team2:" + x;
                    }
                    else if (i == 2)
                    {
                        //GameObject mytank = Instantiate(tanks, new Vector3(-11f, -12.957f, rand_z), Quaternion.identity);
                        
                        mytank.tag = "Player3";
                        mytank.name = "Team3:" + x;
                    }
                    else if (i == 3)
                    {
                        //GameObject mytank = Instantiate(tanks, new Vector3(rand_x, -12.957f, -12), Quaternion.identity);
                        
                        mytank.tag = "Player4";
                        mytank.name = "Team4:" + x;
                    }
                }
            }

        }
    }
}
