using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public InputField team_number;
    public InputField tanks_per;
    public GameObject manager;
    void Start()
    {
        Time.timeScale = 0f;
        //this.gameObject.SetActive(true);
        
    }

    public void resume()
    {
        try
        {
            int team = int.Parse(team_number.text);
            int tanks = int.Parse(tanks_per.text);

            if (team < 2 || team > 4 || tanks < 2 || tanks > 4)
            {
                throw new Exception("You have entered an incorrect value");
            }

            manager.GetComponent<Manager>().num_teams = team;
            manager.GetComponent<Manager>().num_tanks_per = tanks;

            this.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        catch (Exception e)
        {
            Debug.Log(e);
            Debug.Log("Try Again. Input Correct numbers pls.");
        }

        
    }
}
