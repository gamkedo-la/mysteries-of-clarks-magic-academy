using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintingChoice : MonoBehaviour
{
    public Image[] paintings;
    public Material[] paintingSpots;
    public int min, max;

    private void Start()
    {
        for (int i = 0; i < paintings.Length; i++)
        {
            int RandomRangeItem = Random.Range(0, paintingSpots.Length);
            paintings[i].GetComponent<Image>().material = paintingSpots[RandomRangeItem];
        }

        /*
        int paintingsToTurnOn = Random.Range(min, max);

        for (int i = 0; i < paintingsToTurnOn; i++)
        {

        }
        */
    }
}
