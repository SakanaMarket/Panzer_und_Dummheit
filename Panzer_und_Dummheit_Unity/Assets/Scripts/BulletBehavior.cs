using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public int dir;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = .2f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (dir == 0)
        {
            this.transform.position += new Vector3(0f, 0f, speed);
        }
        if (dir == 3)
        {
            this.transform.position += new Vector3(-1 * speed, 0f, 0f);
        }
        if (dir == 2)
        {
            this.transform.position += new Vector3(0f, 0f, -1 * speed);
        }
        if (dir == 1)
        {
            this.transform.position += new Vector3(speed, 0f, 0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Killable")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if ((other.gameObject.tag != "Player1" && this.gameObject.tag == "B1") || (other.gameObject.tag != "Player2" && this.gameObject.tag == "B2") 
            || (other.gameObject.tag != "Player3" && this.gameObject.tag == "B3") || (other.gameObject.tag != "Player4" && this.gameObject.tag == "B4"))
        {
            //other.gameObject.GetComponent<TankBehavior>().Respawn();

            if (other.gameObject.tag != "Environment")
            {
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                //Debug.Log(this.gameObject.name + " killed " + other.gameObject.name);
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }

    }
}
