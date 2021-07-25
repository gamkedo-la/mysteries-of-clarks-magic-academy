using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStudent : MonoBehaviour
{
    int chooseGender;
    public GameObject male, female;


    int chooseHouse;
    int chooseSkin;
    public Material[] skin;
    public Material EE, DL, HH, GD;
    public SkinnedMeshRenderer femaleRenderer, maleRenderer;
    public Material[] mats; 

    float sizeMultiplier;
    int hairstyle;
    public GameObject[] femaleHairStyle, maleHairStyle;
    int hairColorChoice;
    public Material[] hairColor;

    float animationSpeed;
    public Animator maleAnimation, femaleAnimation;
    // Start is called before the first frame update
    void Start()
    {
        animationSpeed = Random.Range(.5f, 1.3f);
        sizeMultiplier = Random.Range(.85f, 1.3f);
        //Only on male for now.
        chooseGender = Random.Range(0, 2);
        print(chooseGender);

        hairColorChoice = Random.Range(0, hairColor.Length);

        chooseSkin = Random.Range(0, skin.Length);

        if (chooseGender == 0)
        {
            mats = maleRenderer.GetComponent<Renderer>().materials;

            male.SetActive(true);

            male.transform.localScale *= sizeMultiplier;

            hairstyle = Random.Range(0, maleHairStyle.Length);
            maleHairStyle[hairstyle].SetActive(true);

           maleHairStyle[hairstyle].GetComponent<Renderer>().material = hairColor[hairColorChoice];
            mats[0] = skin[chooseSkin];
            maleRenderer.GetComponent<SkinnedMeshRenderer>().material = mats[0];

          //  chooseHouse = Random.Range(0, 4);
            /*if (chooseHouse == 0)
            {
                mats[0] = EE;
                // maleRenderer.material = EE;
            }
            if (chooseHouse == 1)
            {
                mats[0] = EE;
               // maleRenderer.material = DL;
            }
            if (chooseHouse == 2)
            {
                mats[0] = EE;
               // maleRenderer.material = HH;
            }
            if (chooseHouse == 3)
            {
                mats[0] = EE;
               // maleRenderer.material = GD;
            }*/
            // maleRenderer.GetComponent<Renderer>().material = mats[1];
            maleAnimation.speed = animationSpeed;
        }
        if (chooseGender == 1)
        {
            mats = femaleRenderer.GetComponent<Renderer>().materials;

            female.SetActive(true);

            female.transform.localScale *= sizeMultiplier;

            hairstyle = Random.Range(0, femaleHairStyle.Length);
            femaleHairStyle[hairstyle].SetActive(true);

            femaleHairStyle[hairstyle].GetComponent<Renderer>().material = hairColor[hairColorChoice];
            mats[0] = skin[chooseSkin];
            femaleRenderer.GetComponent<SkinnedMeshRenderer>().material = mats[0];

            femaleAnimation.speed = animationSpeed;
        }
    }
}
