using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFire : MonoBehaviour
{
    public int buldir;
    public GameObject bul;
    private float offset;
    //private string hotkey_fire;
    public Material bulcolor1;
    public Material bulcolor2;
    public Material bulcolor3;
    public Material bulcolor4;
    private Material bulcolor;
    public float x_dis;
    public float z_dis;
    RaycastHit hit;
    Ray ray;

    private string tague;

    void Start()
    {
        tague = this.transform.tag;
        offset = .5f;
        buldir = this.GetComponent<AI2>().dir;
        if(gameObject.tag == "Player1")
        {
            //hotkey_fire = "space";
            bulcolor = bulcolor1;
        }
        if (gameObject.tag == "Player2")
        {
            //hotkey_fire = ".";
            bulcolor = bulcolor2;
        }
        if (gameObject.tag == "Player3")
        {
            bulcolor = bulcolor3;
        }
        if (gameObject.tag == "Player4")
        {
            bulcolor = bulcolor4;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //buldir = this.GetComponent<AI>().dir;
        //x_dis = this.GetComponent<AI>().x_distance;
        //z_dis = this.GetComponent<AI>().z_distance;
        //if (buldir == 0 && Mathf.Abs(z_dis) <= 1)
        //{
        //    GameObject mybullet = Instantiate(bul, this.transform.GetChild(0).position + new Vector3(0, 0, offset), Quaternion.identity);
        //    mybullet.GetComponent<BulletBehavior>().dir = buldir;
        //    mybullet.GetComponent<Renderer>().material = bulcolor;
        //}
        //if (buldir == 1 && Mathf.Abs(x_dis) <= 1)
        //{
        //    GameObject mybullet = Instantiate(bul, this.transform.GetChild(0).position + new Vector3(offset, 0, 0), Quaternion.identity);
        //    mybullet.GetComponent<BulletBehavior>().dir = buldir;
        //    mybullet.GetComponent<Renderer>().material = bulcolor;
        //}
        //if (buldir == 2 && Mathf.Abs(z_dis) <= 1)
        //{
        //    GameObject mybullet = Instantiate(bul, this.transform.GetChild(0).position + new Vector3(0, 0, -1 * offset), Quaternion.identity);
        //    mybullet.GetComponent<BulletBehavior>().dir = buldir;
        //    mybullet.GetComponent<Renderer>().material = bulcolor;
        //}
        //if (buldir == 3 && Mathf.Abs(x_dis) <= 1)
        //{
        //    GameObject mybullet = Instantiate(bul, this.transform.GetChild(0).position + new Vector3(-1 * offset, 0, 0), Quaternion.identity);
        //    mybullet.GetComponent<BulletBehavior>().dir = buldir;
        //    mybullet.GetComponent<Renderer>().material = bulcolor;
        //}

        Ray ray = new Ray(transform.GetChild(0).transform.position, transform.GetChild(0).transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag != tague && (hit.transform.tag == "Player1" || hit.transform.tag == "Player2" || hit.transform.tag == "Player3" || hit.transform.tag == "Player4"))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.blue);
                buldir = this.GetComponent<AI2>().dir;

                if (buldir == 0)
                {
                    GameObject mybullet = Instantiate(bul, this.transform.GetChild(0).position + new Vector3(0, 0, offset), Quaternion.identity);
                    mybullet.GetComponent<BulletBehavior>().dir = buldir;
                    mybullet.GetComponent<Renderer>().material = bulcolor;
                    change_bullet_tag(this.gameObject, mybullet);
                    
                }
                else if (buldir == 1)
                {
                    GameObject mybullet = Instantiate(bul, this.transform.GetChild(0).position + new Vector3(offset, 0, 0), Quaternion.identity);
                    mybullet.GetComponent<BulletBehavior>().dir = buldir;
                    mybullet.GetComponent<Renderer>().material = bulcolor;
                    change_bullet_tag(this.gameObject, mybullet);
                }
                else if (buldir == 2)
                {
                    GameObject mybullet = Instantiate(bul, this.transform.GetChild(0).position + new Vector3(0, 0, -1 * offset), Quaternion.identity);
                    mybullet.GetComponent<BulletBehavior>().dir = buldir;
                    mybullet.GetComponent<Renderer>().material = bulcolor;
                    change_bullet_tag(this.gameObject, mybullet);
                }
                else if (buldir == 3)
                {
                    GameObject mybullet = Instantiate(bul, this.transform.GetChild(0).position + new Vector3(-1 * offset, 0, 0), Quaternion.identity);
                    mybullet.GetComponent<BulletBehavior>().dir = buldir;
                    mybullet.GetComponent<Renderer>().material = bulcolor;
                    change_bullet_tag(this.gameObject, mybullet);
                }   
            }
            else if (hit.transform.tag == "Untagged")
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red);
            }
        }
        else
        {
            Debug.DrawLine(ray.origin, hit.point, Color.green);
        }
    }

    void change_bullet_tag(GameObject g, GameObject b)
    {
        if (g.tag == "Player1")
        {
            b.tag = "B1";
        }
        else if (g.tag == "Player2")
        {
            b.tag = "B2";
        }
        else if (g.tag == "Player3")
        {
            b.tag = "B3";
        }
        else if (g.tag == "Player4")
        {
            b.tag = "B4";
        }
    }

}
