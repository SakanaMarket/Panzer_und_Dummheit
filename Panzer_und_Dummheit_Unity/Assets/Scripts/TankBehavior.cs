using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBehavior : MonoBehaviour
{
    public float speed;
    private Rigidbody rigid;
    public int dir;
    private string forward;
    private string backward;
    private string left;
    private string right;
    public Material body_color1;
    public Material body_color2;
    public Vector3 originalpos;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        speed = .1f;
        dir = 0;
        originalpos = gameObject.transform.position;
        if (gameObject.tag == "Player1")
        {
            forward = "w";
            backward = "s";
            left = "a";
            right = "d";
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = body_color1;
        }
        if (gameObject.tag == "Player2")
        {
            forward = "up";
            backward = "down";
            left = "left";
            right = "right";
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = body_color2;
        }
        Physics.IgnoreLayerCollision(8, 8);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if (Input.GetKey(forward)) {
            this.transform.position += new Vector3(0f, 0f, speed);
            if(dir == 3)
            {   //left to front
                this.transform.Rotate(Vector3.up, 90);
                this.transform.position += new Vector3(-22.653347f, 0f, 8.98583f);
                dir = 0;
            }
            if (dir ==2 )
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
        else { if (Input.GetKey(left))
            {
                this.transform.position += new Vector3(-1 * speed, 0f, 0f);
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
            else { if (Input.GetKey(backward)){
                    this.transform.position += new Vector3(0f, 0f, -1 * speed);
                    if (dir == 3)
                    {   //left to back
                            this.transform.Rotate(Vector3.up, -90);
                            this.transform.position += new Vector3( 8.98583f, 0f, 22.653347f);
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
                else { if (Input.GetKey(right)){

                        this.transform.position += new Vector3(speed, 0f, 0f);
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
            }
        }
    }

    public void Respawn()
    {
        if (dir == 3)
        {   //left to front
            this.transform.Rotate(Vector3.up, 90);
            dir = 0;
        }
        if (dir == 2)
        { //back to front
            this.transform.Rotate(Vector3.up, 180);
            dir = 0;
        }
        if (dir == 1)
        { //right to front
            this.transform.Rotate(Vector3.up, -90);   
            dir = 0;
        }
        this.transform.position = originalpos;
    }
}
