using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStudent : MonoBehaviour
{
    int chooseGender;
    public GameObject male, female;
    int chooseHouse;
    public Material EE, DL, HH, GD;
    float sizeMultiplier;
    int hairstyle;
    public GameObject[] femaleHairStyle, maleHairStyle;
    int hairColorChoice;
    public Material[] hairColor;

    public GameObject femaleCube001, maleCube001;
    public Material[] femaleColors, maleColors;

    float animationSpeed;
    public Animator maleAnimation, femaleAnimation;
    // Start is called before the first frame update
    void Start()
    {
        animationSpeed = Random.Range(.5f, 1.5f);
        sizeMultiplier = Random.Range(.85f, 1.3f);
        chooseGender = Random.Range(0, 2);
        print(chooseGender);

        hairColorChoice = Random.Range(0, hairColor.Length);

        if (chooseGender == 0)
        {
            male.SetActive(true);

            male.transform.localScale *= sizeMultiplier;

            hairstyle = Random.Range(0, maleHairStyle.Length);
            maleHairStyle[hairstyle].SetActive(true);

            maleHairStyle[hairstyle].GetComponent<Renderer>().material = hairColor[hairColorChoice];

            chooseHouse = Random.Range(0, 5);
            if (chooseHouse == 0)
            {
                maleColors[0] = EE;
            }
            if (chooseHouse == 1)
            {
                maleColors[0] = DL;
            }
            if (chooseHouse == 2)
            {
                maleColors[0] = HH;
            }
            if (chooseHouse == 3)
            {
                maleColors[0] = GD;
            }

            maleAnimation.speed = animationSpeed;
        }
        if (chooseGender == 1)
        {
            female.SetActive(true);

            female.transform.localScale *= sizeMultiplier;

            hairstyle = Random.Range(0, femaleHairStyle.Length);
            femaleHairStyle[hairstyle].SetActive(true);
            femaleHairStyle[hairstyle].GetComponent<Renderer>().material = hairColor[hairColorChoice];

            femaleAnimation.speed = animationSpeed;
        }





    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
