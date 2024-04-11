using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_Shot : MonoBehaviour
{

    [Header("이미지")]
    public Image hit_Image;
    public Image zoom_Image;
    public Image zoom_x4Image;
    public Text textbulletCount;

    [Header("게임 오브젝트")]
    public GameObject spawnSphere;
    public GameObject sphere;
    public GameObject anim_Gun;

    public ParticleSystem gunFire;
    Animator fire_anim;

    int curBulletCount;
    int maxBulletCount;

    int weaponType; //권총 : 0, AR : 1, SR : 2

    void Start()
    {
        weaponType = 2;
        maxBulletCount = 6;
        curBulletCount = maxBulletCount;
        fire_anim = anim_Gun.GetComponent<Animator>();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
        if (Input.GetKeyDown(KeyCode.Mouse0) && curBulletCount > 0)
        {
            curBulletCount--;
            textbulletCount.text = curBulletCount + " / " + maxBulletCount;
            fire_anim.SetTrigger("isGunShot");
            gunFire.Play();

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitData;

            if (Physics.Raycast(ray, out hitData))
            {
                if (hitData.transform.name == "Start_Button")
                {
                    if (hitData.transform.GetComponent<Spawn_Sphere>().isReady)//종료함
                    {
                        hitData.transform.GetComponent<Spawn_Sphere>().isReady = false;
                        hitData.transform.GetComponent<Spawn_Sphere>().isSpawnStart = false;

                        hitData.transform.GetComponent<Renderer>().material.color = Color.green;
                    }
                    else//시작함
                    {
                        hitData.transform.GetComponent<Spawn_Sphere>().isReady = true;

                        hitData.transform.GetComponent<Renderer>().material.color = Color.red;

                    }
                }

                if (hitData.transform.tag == "LevelTrigger")
                {
                    hitData.transform.GetComponent<Renderer>().material.color = Color.black;

                    switch (hitData.transform.name)
                    {
                        case "Easy":
                            spawnSphere.GetComponent<Spawn_Sphere>().spawnLevel = 2.0f;
                            sphere.GetComponent<Sphere_Trigger>().destroyLevel = 1.8f;
                            break;

                        case "Normal":
                            spawnSphere.GetComponent<Spawn_Sphere>().spawnLevel = 1.5f;
                            sphere.GetComponent<Sphere_Trigger>().destroyLevel = 1.3f;
                            break;

                        case "Difficult":
                            spawnSphere.GetComponent<Spawn_Sphere>().spawnLevel = 1.2f;
                            sphere.GetComponent<Sphere_Trigger>().destroyLevel = 1.0f;
                            break;

                    }


                }

                if (hitData.transform.tag == "Target")
                {
                    hit_Image.color = new Color(1, 1, 1, 1);
                }

                if (hitData.transform.tag == "Head")
                {
                    hit_Image.color = new Color(1, 0, 0, 1);
                }

                if (hitData.transform.name.Contains("Sphere"))
                {
                    Destroy(hitData.transform.gameObject);
                    spawnSphere.GetComponent<Spawn_Sphere>().count_Score++;
                }

            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(weaponType != 2)
            {
                if (zoom_Image.gameObject.activeSelf)
                {
                    zoom_Image.gameObject.SetActive(false);
                    this.transform.localPosition += new Vector3(0, 0, -1);
                }
                else
                {
                    zoom_Image.gameObject.SetActive(true);
                    this.transform.localPosition += new Vector3(0, 0, 1);
                }
            }
            else
            {
                if (zoom_x4Image.gameObject.activeSelf)
                {
                    zoom_x4Image.gameObject.SetActive(false);
                    this.transform.localPosition += new Vector3(0, 0, -8);
                }
                else
                {
                    zoom_x4Image.gameObject.SetActive(true);
                    this.transform.localPosition += new Vector3(0, 0, 8);
                }
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            curBulletCount = maxBulletCount;
            textbulletCount.text = curBulletCount + " / " + maxBulletCount;
            fire_anim.SetTrigger("isGunReload");

        }
    }

}
