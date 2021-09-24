using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockPerLevel : MonoBehaviour
{
    public bool MC, Rhys, Skye, Jameel, Harper, Sullivan;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        if (MC)
        {
            if (GameManager.MCLevel >= level)
            {
                this.gameObject.SetActive(true);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }

        if (Rhys)
        {
            if (GameManager.RhysLevel >= level)
            {
                this.gameObject.SetActive(true);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }

        if (Skye)
        {
            if (GameManager.SkyeLevel >= level)
            {
                this.gameObject.SetActive(true);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }

        if (Jameel)
        {
            if (GameManager.JameelLevel >= level)
            {
                this.gameObject.SetActive(true);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }

        if (Harper)
        {
            if (GameManager.HarperLevel >= level)
            {
                this.gameObject.SetActive(true);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }

        if (Sullivan)
        {
            if (GameManager.SullivanLevel >= level)
            {
                this.gameObject.SetActive(true);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
