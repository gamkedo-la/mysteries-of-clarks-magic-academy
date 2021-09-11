using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStudentSitting : MonoBehaviour
{
    public bool isIdle;

    int chooseGender;
    public GameObject male, female, male2, female2;

    int chooseHouse;
    int chooseSkin;
    public Material[] skin;
    public Material EE, DL, HH, GD;
    public GameObject FhouseMaterial, MhouseMaterial;
    public SkinnedMeshRenderer femaleRenderer, maleRenderer, femaleRenderer2, maleRenderer2;
    public Material[] mats;

    float sizeMultiplier;
    int hairstyle;
    public GameObject[] femaleHairStyle, maleHairStyle, femaleHairStyle2, maleHairStyle2;
    int hairColorChoice;
    public Material[] hairColor;

    float animationSpeed;
    public Animator maleAnimation, femaleAnimation, male2Animation, female2Animation;

    void Start()
    {
        animationSpeed = Random.Range(.2f, 1.7f);

        sizeMultiplier = Random.Range(.85f, 1.3f);
        chooseGender = Random.Range(0, 4);

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

            chooseHouse = Random.Range(0, 4);
            if (chooseHouse == 0)
            {
                MhouseMaterial.GetComponent<Renderer>().material = EE;
            }
            else if (chooseHouse == 1)
            {
                MhouseMaterial.GetComponent<Renderer>().material = DL;
            }
            else if (chooseHouse == 2)
            {
                MhouseMaterial.GetComponent<Renderer>().material = GD;
            }
            else if (chooseHouse == 3)
            {
                MhouseMaterial.GetComponent<Renderer>().material = HH;
            }

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

            chooseHouse = Random.Range(0, 4);
            if (chooseHouse == 0)
            {
                FhouseMaterial.GetComponent<Renderer>().material = EE;
            }
            else if (chooseHouse == 1)
            {
                FhouseMaterial.GetComponent<Renderer>().material = DL;
            }
            else if (chooseHouse == 2)
            {
                FhouseMaterial.GetComponent<Renderer>().material = GD;
            }
            else if (chooseHouse == 3)
            {
                FhouseMaterial.GetComponent<Renderer>().material = HH;
            }

            femaleAnimation.speed = animationSpeed;
        }


        if (chooseGender == 3)
        {
            mats = maleRenderer2.GetComponent<Renderer>().materials;

            male2.SetActive(true);

            male2.transform.localScale *= sizeMultiplier;

            hairstyle = Random.Range(0, maleHairStyle2.Length);
            maleHairStyle2[hairstyle].SetActive(true);

            maleHairStyle2[hairstyle].GetComponent<Renderer>().material = hairColor[hairColorChoice];
            mats[0] = skin[chooseSkin];
            maleRenderer2.GetComponent<SkinnedMeshRenderer>().material = mats[0];

            chooseHouse = Random.Range(0, 4);
            if (chooseHouse == 0)
            {
                MhouseMaterial.GetComponent<Renderer>().material = EE;
            }
            else if (chooseHouse == 1)
            {
                MhouseMaterial.GetComponent<Renderer>().material = DL;
            }
            else if (chooseHouse == 2)
            {
                MhouseMaterial.GetComponent<Renderer>().material = GD;
            }
            else if (chooseHouse == 3)
            {
                MhouseMaterial.GetComponent<Renderer>().material = HH;
            }

            male2Animation.speed = animationSpeed;
        }
        if (chooseGender == 2)
        {
            mats = femaleRenderer2.GetComponent<Renderer>().materials;

            female2.SetActive(true);

            female2.transform.localScale *= sizeMultiplier;

            hairstyle = Random.Range(0, femaleHairStyle2.Length);
            femaleHairStyle2[hairstyle].SetActive(true);

            femaleHairStyle2[hairstyle].GetComponent<Renderer>().material = hairColor[hairColorChoice];
            mats[0] = skin[chooseSkin];
            femaleRenderer2.GetComponent<SkinnedMeshRenderer>().material = mats[0];

            chooseHouse = Random.Range(0, 4);
            if (chooseHouse == 0)
            {
                FhouseMaterial.GetComponent<Renderer>().material = EE;
            }
            else if (chooseHouse == 1)
            {
                FhouseMaterial.GetComponent<Renderer>().material = DL;
            }
            else if (chooseHouse == 2)
            {
                FhouseMaterial.GetComponent<Renderer>().material = GD;
            }
            else if (chooseHouse == 3)
            {
                FhouseMaterial.GetComponent<Renderer>().material = HH;
            }

            female2Animation.speed = animationSpeed;
        }
        /*
        if (chooseGender == 0)
        {
            maleHairStyle[hairstyle].GetComponent<Renderer>().material = hairColor[hairColorChoice];
            mats[0] = skin[chooseSkin];
            maleRenderer.GetComponent<SkinnedMeshRenderer>().material = mats[0];
            male.SetActive(true);
        }
        if (chooseGender == 1)
        {
            femaleHairStyle[hairstyle].GetComponent<Renderer>().material = hairColor[hairColorChoice];
            mats[0] = skin[chooseSkin];
            femaleRenderer.GetComponent<SkinnedMeshRenderer>().material = mats[0];
            female.SetActive(true);
        }

        if (chooseGender == 3)
        {
            maleHairStyle[hairstyle].GetComponent<Renderer>().material = hairColor[hairColorChoice];
            mats[0] = skin[chooseSkin];
            maleRenderer.GetComponent<SkinnedMeshRenderer>().material = mats[0];
            male2.SetActive(true);
        }
        if (chooseGender == 2)
        {
            femaleHairStyle[hairstyle].GetComponent<Renderer>().material = hairColor[hairColorChoice];
            mats[0] = skin[chooseSkin];
            femaleRenderer.GetComponent<SkinnedMeshRenderer>().material = mats[0];
            female2.SetActive(true);
        }

        */

    }
}