using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI2 : MonoBehaviour
{
    public float random_direction;
    public int dir;

    public Material body_color1;
    public Material body_color2;
    public Material body_color3;
    public Material body_color4;

    private bool change_color;

    void Start()
    {
        change_color = true;
        InvokeRepeating("wait_5_sec_before_turn", 1, 1);    
    }

    // Update is called once per frame
    void Update()
    {
        change_color_body();
        move();           
    }


    void change_color_body()
    {
        if (change_color == true)
        {
            if (gameObject.tag == "Player1")
            {
                //dir = 0;
                this.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
            else if (gameObject.tag == "Player2")
            {
                //dir = 1;
                this.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            }
            else if (gameObject.tag == "Player3")
            {
                //dir = 2;
                this.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            }
            else if (gameObject.tag == "Player4")
            {
                //dir = 3;
                this.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
            }
            change_color = false;
        }
    }
    void wait_5_sec_before_turn()
    {
        random_direction = Random.Range(0.0f, 1.0f);     
    }

    void move()
    {
        if (random_direction < 0.25f) // up
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
        else if (random_direction >= 0.25f && random_direction < 0.5f) // right
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
        else if (random_direction >= 0.5f && random_direction < 0.75f) // down
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
        else if (random_direction >= 0.75f && random_direction <= 1.0f) // left
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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Environment")
        {
            //Debug.Log("Env");

            if (collision.transform.name == "Wall")
            {
                //Debug.Log("wall"); //left wall
                random_direction = 0.3f; //move right
                
            }
            else if (collision.transform.name == "Wall (1)")
            {
                //Debug.Log("wall 1"); //top wall
                random_direction = 0.6f; //move down
            }
            else if (collision.transform.name == "Wall (2)")
            {
                //Debug.Log("wall 2"); //right wall
                random_direction = 0.9f; //move left
            }
            else if (collision.transform.name == "Wall (3)")
            {
                //Debug.Log("wall 3"); //bottom wall
                random_direction = 0.1f; //move up
            }
        }
    }
}
