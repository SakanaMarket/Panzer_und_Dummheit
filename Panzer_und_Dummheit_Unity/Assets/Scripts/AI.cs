using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject other_player;
    public float distance_vector = 0;
    public float speed = 5f;
    public float x_distance;
    public float z_distance;
    public float stop_distance;

    public int dir;
    void Start()
    {
        dir = 0;
        stop_distance = 1f;
        find_target();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!other_player) // if target stil exists
        {
            Debug.Log("Found");
            find_target();
        }
        else
        {
            //distance_vector = Vector3.Distance(this.transform.position, other_player.transform.position);
            x_distance = other_player.transform.GetChild(0).position.x - transform.GetChild(0).position.x;
            z_distance = other_player.transform.GetChild(0).position.z - transform.GetChild(0).position.z;
            //if ((0 <= Mathf.Abs(x_distance) && Mathf.Abs(x_distance) <= stop_distance) || (0 <= Mathf.Abs(z_distance) && Mathf.Abs(z_distance) <= stop_distance))
            //{
            //    this.transform.position = this.transform.position;
            //}
            if (Mathf.Abs(x_distance) >= Mathf.Abs(z_distance) && x_distance > 0)
            {//right
                if (0 <= Mathf.Abs(x_distance) && Mathf.Abs(x_distance) <= stop_distance && Mathf.Abs(x_distance) == 0)
                {
                    Debug.Log("stopped on right");
                    this.transform.position = this.transform.position;
                }
                else
                {
                    this.transform.position += new Vector3(0.1f, 0, 0);

                    if (dir == 0)
                    {   //front to right
                        this.transform.Rotate(Vector3.up, 90);
                        this.transform.position += new Vector3(8.985852f, 0f, 22.65333f);
                        dir = 1;
                    }
                    if (dir == 3)
                    {   //left to right
                        this.transform.Rotate(Vector3.up, 180);
                        this.transform.position += new Vector3(-13.667466f, 0f, 31.6392f);
                        dir = 1;
                    }
                    if (dir == 2)
                    {   //back to right
                        this.transform.Rotate(Vector3.up, -90);
                        this.transform.position += new Vector3(-22.653306f, 0f, 8.985902f);
                        dir = 1;
                    }
                }

            }
            else if (Mathf.Abs(x_distance) >= Mathf.Abs(z_distance) && x_distance < 0)
            {//left
                if (0 <= Mathf.Abs(x_distance) && Mathf.Abs(x_distance) <= stop_distance && Mathf.Abs(z_distance) == 0)
                {
                    Debug.Log("stopped on left");
                    this.transform.position = this.transform.position;
                }
                else
                {
                    this.transform.position += new Vector3(-0.1f, 0, 0);

                    if (dir == 0)
                    {   //front to left
                        this.transform.Rotate(Vector3.up, -90);
                        this.transform.position += new Vector3(22.653347f, 0f, -8.98583f);
                        dir = 3;
                    }
                    if (dir == 2)
                    {   //back to left
                        this.transform.Rotate(Vector3.up, 90);
                        this.transform.position += new Vector3(-8.985831f, 0f, -22.653327f);
                        dir = 3;
                    }
                    if (dir == 1)
                    { //right to left
                        this.transform.Rotate(Vector3.up, 180);
                        this.transform.position += new Vector3(13.667533f, 0f, -31.63917f);
                        dir = 3;
                    }
                }
            }
            else if (Mathf.Abs(x_distance) <= Mathf.Abs(z_distance) && z_distance > 0)
            {//up
                if (0 <= Mathf.Abs(z_distance) && Mathf.Abs(z_distance) <= stop_distance && Mathf.Abs(x_distance) == 0)
                {
                    Debug.Log("stopped on up" + Mathf.Abs(z_distance) + " " + stop_distance);
                    this.transform.position = this.transform.position;
                }
                else
                {
                    this.transform.position += new Vector3(0, 0, 0.1f);
                    if (dir == 3)
                    {   //left to front
                        this.transform.Rotate(Vector3.up, 90);
                        this.transform.position += new Vector3(-22.653347f, 0f, 8.98583f);
                        dir = 0;
                    }
                    if (dir == 2)
                    { //back to front
                        this.transform.Rotate(Vector3.up, 180);
                        this.transform.position += new Vector3(-31.63916f, 0f, -13.667517f);
                        dir = 0;
                    }
                    if (dir == 1)
                    { //right to front
                        this.transform.Rotate(Vector3.up, -90);
                        this.transform.position += new Vector3(-8.985806f, 0f, -22.65334f);
                        dir = 0;
                    }
                }

            }
            else if (Mathf.Abs(x_distance) <= Mathf.Abs(z_distance) && z_distance < 0)
            {//down
                if (0 <= Mathf.Abs(z_distance) && Mathf.Abs(z_distance) <= stop_distance && Mathf.Abs(x_distance) == 0)
                {
                    Debug.Log("stopped on down");
                    this.transform.position = this.transform.position;
                }
                else
                {
                    this.transform.position += new Vector3(0, 0, -0.1f);
                    if (dir == 3)
                    {   //left to back
                        this.transform.Rotate(Vector3.up, -90);
                        this.transform.position += new Vector3(8.98583f, 0f, 22.653347f);
                        dir = 2;
                    }
                    if (dir == 0)
                    { //front to back
                        this.transform.Rotate(Vector3.up, 180);
                        this.transform.position += new Vector3(31.63915f, 0f, 13.667534f);
                        dir = 2;
                    }
                    if (dir == 1)
                    { //right to back
                        this.transform.Rotate(Vector3.up, 90);
                        this.transform.position += new Vector3(22.653354f, 0f, -8.985823f);
                        dir = 2;
                    }
                }
            }
        }
        


    }

    public void find_target()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player2"))
        {

            float temp_distance = Vector3.Distance(this.transform.GetChild(0).position, g.transform.GetChild(0).position);
            if (distance_vector == 0)
            {
                other_player = g;
                //Debug.Log(distance_vector);
            }
            else if (temp_distance < distance_vector)
            {
                other_player = g;
            }
        }
    }
    public void find_more()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player2"))
        {
            other_player = GameObject.FindGameObjectWithTag("Player2");
        }
    }
}
