using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecallSaveFile : MonoBehaviour
{
    public bool Skye, Jameel, GracieMay, Harper, Sullivan;

    private void Start()
    {
        //Play rewind animation
        StartCoroutine(RewindTime());
    }

    IEnumerator RewindTime()
    {
        yield return new WaitForSeconds(4f);
        if (Skye)
        {
            //Recall Save file
        }
        if (Jameel)
        {
            //Recall Save file
        }
        if (GracieMay)
        {
            //Recall Save file
        }
        if (Harper)
        {
            //Recall Save file
        }
        if (Sullivan)
        {
            //Recall Save file
        }
    }
}
