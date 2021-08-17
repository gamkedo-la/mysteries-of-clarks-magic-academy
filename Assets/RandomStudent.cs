using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomStudent : MonoBehaviour
{
    public bool isIdle;

    int chooseGender;
    public GameObject male, female;


    int chooseHouse;
    int chooseSkin;
    public Material[] skin;
    public Material EE, DL, HH, GD;
    public GameObject FhouseMaterial, MhouseMaterial;
    public SkinnedMeshRenderer femaleRenderer, maleRenderer;
    public Material[] mats; 

    float sizeMultiplier;
    int hairstyle;
    public GameObject[] femaleHairStyle, maleHairStyle;
    int hairColorChoice;
    public Material[] hairColor;

    float animationSpeed;
    public Animator maleAnimation, femaleAnimation;

    public GameObject[] startingPositions;
    public GameObject[] endingPositions;
    int chooseEnd;

    NavMeshAgent agent;

    public Material semiTransparent, Transparent;
    void Start()
    {
        if (GetComponent<NavMeshAgent>() != null)
        {
            agent = GetComponent<NavMeshAgent>();
        }

        if (!isIdle)
        {
            startingPositions = GameObject.FindGameObjectsWithTag("ComeFrom");
            endingPositions = GameObject.FindGameObjectsWithTag("GoTo");
            int chooseStart = Random.Range(0, startingPositions.Length);
            chooseEnd = Random.Range(0, endingPositions.Length);
            this.GetComponent<NavMeshAgent>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            transform.position = startingPositions[chooseStart].transform.position;
            this.GetComponent<NavMeshAgent>().enabled = true;
            this.GetComponent<BoxCollider>().enabled = true;

        }

        animationSpeed = Random.Range(.5f, 1.5f);
        this.GetComponent<NavMeshAgent>().speed *= animationSpeed;

        sizeMultiplier = Random.Range(.85f, 1.3f);
        chooseGender = Random.Range(0, 2);

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
    }

    private void Update()
    {
        if (!isIdle)
        {
            agent.SetDestination(endingPositions[chooseEnd].transform.position);

            float distance = Vector3.Distance(this.transform.position, endingPositions[chooseEnd].transform.position);

            if (distance <= 1)
            {
                Destroy(this.gameObject);
            }


            float distanceToMC = Vector3.Distance(this.transform.position, GameObject.FindWithTag("Player").transform.position);

            if (GameObject.FindWithTag("Player") != null)
            {
                if (distanceToMC <= 5 && distanceToMC > 1.5f)
                {
                    GetComponent<BoxCollider>().enabled = true;
                    if (chooseGender == 0)
                    {
                        maleHairStyle[hairstyle].GetComponent<Renderer>().material = semiTransparent;
                        mats[0] = semiTransparent;
                        maleRenderer.GetComponent<SkinnedMeshRenderer>().material = mats[0];
                        male.SetActive(true);
                    }
                    if (chooseGender == 1)
                    {
                        femaleHairStyle[hairstyle].GetComponent<Renderer>().material = semiTransparent;
                        mats[0] = semiTransparent;
                        femaleRenderer.GetComponent<SkinnedMeshRenderer>().material = mats[0];
                        female.SetActive(true);
                    }
                }
                else if (distanceToMC <= 1.5f)
                {
                    GetComponent<BoxCollider>().enabled = false;
                    if (chooseGender == 0)
                    {
                        male.SetActive(false);
                    }
                    if (chooseGender == 1)
                    {
                        female.SetActive(false);
                    }
                }
                else
                {
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
                }
            }

        }

        else
        {
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
        }
    }
}
