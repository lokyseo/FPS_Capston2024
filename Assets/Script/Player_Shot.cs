using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;


public class Player_Shot : MonoBehaviour
{

    [Header("이미지")]
    public Image hit_Image;
    public Image zoom_Image;
    public Image zoom_x4Image;
    public GameObject bulletMarks;//탄흔
    public Text textbulletCount;

    [Header("게임 오브젝트")]
    public GameObject spawnSphere;
    public GameObject sphere;
    public GameObject anim_Gun;
    public GameObject esc_Menu;

    [Header("파티클")]
    public ParticleSystem gunFire;
    public ParticleSystem arFire;
    public ParticleSystem srFire;
    Animator fire_anim;

    [Header("펀치킹")]
    public Text textScore;

    float curBulletCount;
    float maxBulletCount;
    float gunScope;
    float arScope;
    float srScope;
    float gunDamage;
    float arDamage;
    float srDamage;


    public static int weaponType; //권총 : 0, AR : 1, SR : 2


    private float lookSensitivity_V; //수직감도

    private float cameraRotationLimit;
    private float currentCameraRotationX;

    private float recoil_Vertical; //수직반동
    private float recoil_Horizontal;//수평반동



    void Start()
    {
        recoil_Vertical = 0;
        recoil_Horizontal = 0;
        lookSensitivity_V = 2;
        cameraRotationLimit = 50;

        weaponType = 0;

        maxBulletCount = 8 + PlayerPrefs.GetFloat("GunSlot1", 0);
        curBulletCount = maxBulletCount;
        fire_anim = anim_Gun.GetComponent<Animator>();

        lookSensitivity_V = PlayerPrefs.GetFloat("HorizontalSensitivity", 1.8f);
        PlayerPrefs.SetFloat("SRSlot2", 8);

        //파츠 손잡이 적용
        fire_anim.SetFloat("ArReloadSpeed", PlayerPrefs.GetFloat("ARSlot3", 0) + 1.0f);
        fire_anim.SetFloat("SrReloadSpeed", PlayerPrefs.GetFloat("SRSlot3", 0) + 1.0f);
        //파츠 조준경 적용
        gunScope = 5 * PlayerPrefs.GetFloat("GunSlot2", 0);
        arScope = 5 * PlayerPrefs.GetFloat("ARSlot2", 0);
        srScope = 5 * PlayerPrefs.GetFloat("SRSlot2", 0);
        //파츠 총알 적용
        gunDamage = 10 + PlayerPrefs.GetFloat("GunSlot0", 0);
        arDamage = 5 + PlayerPrefs.GetFloat("ARSlot0", 0);
        srDamage = 30 + PlayerPrefs.GetFloat("SRSlot0", 0);
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
        //if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("GlockSet") &&
        //   fire_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)

        if(esc_Menu.activeSelf == true)
        {
            return;
        }
        CameraRotation();
        

        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ 권 총 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("GlockIdle") && fire_anim.GetBool("isGunZoom") == false||
            fire_anim.GetCurrentAnimatorStateInfo(0).IsName("GlockZoomIdle") && fire_anim.GetBool("isGunZoom") == true) 
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && curBulletCount > 0)
            {
                curBulletCount--;
                textbulletCount.text = curBulletCount + " / " + maxBulletCount;

                fire_anim.SetTrigger("isGunShot");

                recoil_Vertical += 5.0f;
                recoil_Horizontal = Random.Range(-0.2f, 0.21f);
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

                            //hitData.transform.GetComponent<Renderer>().material.color = Color.green;
                        }
                        else//시작함
                        {
                            hitData.transform.GetComponent<Spawn_Sphere>().isReady = true;

                            //hitData.transform.GetComponent<Renderer>().material.color = Color.red;

                        }
                    }

                    if (hitData.transform.tag == "LevelTrigger")
                    {
                        //hitData.transform.GetComponent<Renderer>().material.color = Color.black;

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
                        PunchKingManager.curScore += gunDamage;
                    }
                    else if (hitData.transform.tag == "Head")
                    {
                        hit_Image.color = new Color(1, 0, 0, 1);
                        PunchKingManager.curScore += (gunDamage * 2);
                    }
                    else if(hitData.transform.GetComponent<Collider>() != null)
                    {
                        Instantiate(bulletMarks, hitData.point, Quaternion.FromToRotation(Vector3.forward, hitData.normal));
                    }

                    if (hitData.transform.name.Contains("Sphere"))
                    {
                        Destroy(hitData.transform.gameObject);
                        spawnSphere.GetComponent<Spawn_Sphere>().count_Score++;
                    }

                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                curBulletCount = maxBulletCount;
                textbulletCount.text = curBulletCount + " / " + maxBulletCount;
                fire_anim.SetTrigger("isGunReload");

                if(fire_anim.GetCurrentAnimatorStateInfo(0).IsName("GlockZoomIdle"))
                {
                    zoom_Image.gameObject.SetActive(false);
                    this.GetComponent<Camera>().fieldOfView = 60;
                }

            }
            
        }

        if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("GlockReload"))
        {
            fire_anim.SetBool("isGunZoom", false);
        }


        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ A R @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("AssaultRifleIdle") && fire_anim.GetBool("isArZoom") == false ||
            fire_anim.GetCurrentAnimatorStateInfo(0).IsName("AssaultRifleZoomIdle") && fire_anim.GetBool("isArZoom") == true ||
            fire_anim.GetCurrentAnimatorStateInfo(0).IsName("AssaultRifleIdleAddGrip") && fire_anim.GetBool("isArZoom") == false)
        {
            if (Input.GetKey(KeyCode.Mouse0) && curBulletCount > 0)
            {
                curBulletCount--;
                textbulletCount.text = curBulletCount + " / " + maxBulletCount;


                if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("AssaultRifleIdle"))
                {
                    fire_anim.SetTrigger("isArShot");

                }
                else if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("AssaultRifleZoomIdle"))
                {
                    fire_anim.SetTrigger("isArShot");

                }
                else if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("AssaultRifleIdleAddGrip"))
                {
                    fire_anim.SetTrigger("isArShot");
                }

                //반동
                recoil_Vertical += 2.0f;
                recoil_Horizontal = Random.Range(-0.2f, 0.21f);
                arFire.Play();

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

                            //hitData.transform.GetComponent<Renderer>().material.color = Color.green;
                        }
                        else//시작함
                        {
                            hitData.transform.GetComponent<Spawn_Sphere>().isReady = true;

                            //hitData.transform.GetComponent<Renderer>().material.color = Color.red;

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
                        PunchKingManager.curScore += arDamage;
                    }
                    else if (hitData.transform.tag == "Head")
                    {
                        hit_Image.color = new Color(1, 0, 0, 1);
                        PunchKingManager.curScore += (arDamage * 2);
                    }
                    else if (hitData.transform.GetComponent<Collider>() != null)
                    {
                        Instantiate(bulletMarks, hitData.point, Quaternion.FromToRotation(Vector3.forward, hitData.normal));
                    }

                    if (hitData.transform.name.Contains("Sphere"))
                    {
                        Destroy(hitData.transform.gameObject);
                        spawnSphere.GetComponent<Spawn_Sphere>().count_Score++;
                    }


                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                curBulletCount = maxBulletCount;
                textbulletCount.text = curBulletCount + " / " + maxBulletCount;
                if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("AssaultRifleIdle"))
                {
                    fire_anim.SetTrigger("isArReload");

                }
                else if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("AssaultRifleZoomIdle"))
                {

                    fire_anim.SetTrigger("isArReload");

                    zoom_Image.gameObject.SetActive(false);
                    this.GetComponent<Camera>().fieldOfView = 60;
                }
                else if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("AssaultRifleIdleAddGrip"))
                {
                    fire_anim.SetTrigger("isArReload");
                }
            }


        }
        if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("AssaultRifleReload") ||
            fire_anim.GetCurrentAnimatorStateInfo(0).IsName("AssaultRifleReloadAddGrip"))
        {
            fire_anim.SetBool("isArZoom", false);
        }

        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ S  R  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("SniperRifleIdle") && fire_anim.GetBool("isSrZoom") == false ||
            fire_anim.GetCurrentAnimatorStateInfo(0).IsName("SniperRifleZoomIdle") && fire_anim.GetBool("isSrZoom") == true ||
            fire_anim.GetCurrentAnimatorStateInfo(0).IsName("SniperRifleIdleAddGrip") && fire_anim.GetBool("isSrZoom") == false)

        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && curBulletCount > 0)
            {
                curBulletCount--;
                textbulletCount.text = curBulletCount + " / " + maxBulletCount;
                if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("SniperRifleIdle"))
                {
                    fire_anim.SetTrigger("isSrShot");

                }
                else if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("SniperRifleZoomIdle"))
                {
                    fire_anim.SetTrigger("isSrShot");
                    fire_anim.SetBool("isSrZoom", false);

                    zoom_x4Image.gameObject.SetActive(false);
                    this.GetComponent<Camera>().fieldOfView = 60;

                }
                else if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("SniperRifleIdleAddGrip"))
                {
                    fire_anim.SetTrigger("isSrShot");
                }

                recoil_Vertical += 10.0f;
                recoil_Horizontal = Random.Range(-0.2f, 0.21f);
                srFire.Play();

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
                        PunchKingManager.curScore += srDamage;
                    }
                    else if (hitData.transform.tag == "Head")
                    {
                        hit_Image.color = new Color(1, 0, 0, 1);
                        PunchKingManager.curScore += (srDamage * 2);
                    }
                    else if (hitData.transform.GetComponent<Collider>() != null)
                    {
                        Instantiate(bulletMarks, hitData.point, Quaternion.FromToRotation(Vector3.forward, hitData.normal));
                    }

                    if (hitData.transform.name.Contains("Sphere"))
                    {
                        Destroy(hitData.transform.gameObject);
                        spawnSphere.GetComponent<Spawn_Sphere>().count_Score++;
                    }

                    
                }
            }
    

            if (Input.GetKeyDown(KeyCode.R))
            {
                curBulletCount = maxBulletCount;
                textbulletCount.text = curBulletCount + " / " + maxBulletCount;

                fire_anim.SetTrigger("isSrReload");

                if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("SniperRifleZoomIdle"))
                {
                    zoom_x4Image.gameObject.SetActive(false);

                    this.GetComponent<Camera>().fieldOfView = 60;

                }

            }

        }

        if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("SniperRifleReload") ||
            fire_anim.GetCurrentAnimatorStateInfo(0).IsName("SniperRifleReloadAddGrip"))
        {
            fire_anim.SetBool("isSrZoom", false);
        }


        // 무기 줌 우클릭
        if (fire_anim.GetCurrentAnimatorStateInfo(0).IsName("SniperRifleIdle")||
            fire_anim.GetCurrentAnimatorStateInfo(0).IsName("SniperRifleZoomIdle") &&
           fire_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f ||
            fire_anim.GetCurrentAnimatorStateInfo(0).IsName("SniperRifleIdleAddGrip") ||
            fire_anim.GetCurrentAnimatorStateInfo(0).IsName("AssaultRifleIdle") ||
            fire_anim.GetCurrentAnimatorStateInfo(0).IsName("AssaultRifleZoomIdle") &&
           fire_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f ||
            fire_anim.GetCurrentAnimatorStateInfo(0).IsName("AssaultRifleIdleAddGrip") || 
            fire_anim.GetCurrentAnimatorStateInfo(0).IsName("GlockIdle") ||
            fire_anim.GetCurrentAnimatorStateInfo(0).IsName("GlockZoomIdle") &&
           fire_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
        {
            
            ZoomWeapon();

        }
        //------------------------------------------------------------무기 스왑

        SwapWeapon();
    }


    void ZoomWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            switch (weaponType)
            {
                case 1:
                    if (PlayerPrefs.GetFloat("ARSlot2", 0) == 0) return;
                    else
                    {
                        if (zoom_Image.gameObject.activeSelf)
                        {
                            fire_anim.SetBool("isArZoom", false);

                            zoom_Image.gameObject.SetActive(false);
                            this.GetComponent<Camera>().fieldOfView = 60;

                        }
                        else
                        {
                            fire_anim.SetBool("isArZoom", true);

                        }

                    }


                    break;
                case 2:
                    if (PlayerPrefs.GetFloat("SRSlot2", 0) == 0) return;
                    else
                    {
                        if (zoom_x4Image.gameObject.activeSelf)
                        {
                            fire_anim.SetBool("isSrZoom", false);
                            fire_anim.SetBool("isSrNoZoom", true);

                            zoom_x4Image.gameObject.SetActive(false);
                            this.GetComponent<Camera>().fieldOfView = 60;

                        }
                        else
                        {
                            fire_anim.SetBool("isSrZoom", true);
                        }
                    }

                    break;
                case 0:
                    if (PlayerPrefs.GetFloat("GunSlot2", 0) == 0) return;
                    else
                    {
                        if (zoom_Image.gameObject.activeSelf)
                        {
                            fire_anim.SetBool("isGunZoom", false);
                            zoom_Image.gameObject.SetActive(false);
                            this.GetComponent<Camera>().fieldOfView = 60;
                        }
                        else
                        {
                            fire_anim.SetBool("isGunZoom", true);
                        }
                    }
                    
                    break;
            }
        }

    }


    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity_V;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        recoil_Vertical = Mathf.Lerp(recoil_Vertical, 0, Time.deltaTime/ recoil_Vertical * 10);


        this.transform.localEulerAngles = new Vector3(currentCameraRotationX - recoil_Vertical, recoil_Horizontal, 0f);

    }
    void SwapWeapon()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            fire_anim.SetBool("isArZoom", false);
            fire_anim.SetBool("isGunZoom", false);
            fire_anim.SetBool("isSrZoom", false);
            fire_anim.SetBool("isSrNoZoom", true);

            this.GetComponent<Camera>().fieldOfView = 60;

            if (zoom_Image.gameObject.activeSelf)
            {
                zoom_Image.gameObject.SetActive(false);

            }
            else if (zoom_x4Image.gameObject.activeSelf)
            {
                zoom_x4Image.gameObject.SetActive(false);
            }


            if (PlayerPrefs.GetFloat("ARSlot3", 0) == 0)
            {
                fire_anim.SetBool("isGripSet", false);

            }
            else
            {
                fire_anim.SetBool("isGripSet", true);
            }

            fire_anim.SetTrigger("isArSet");

            weaponType = 1;
            maxBulletCount = 25 + PlayerPrefs.GetFloat("ARSlot1", 0);
            curBulletCount = maxBulletCount;
            textbulletCount.text = curBulletCount + " / " + maxBulletCount;

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            fire_anim.SetBool("isArZoom", false);
            fire_anim.SetBool("isGunZoom", false);
            fire_anim.SetBool("isSrZoom", false);
            fire_anim.SetBool("isSrNoZoom", true);

            this.GetComponent<Camera>().fieldOfView = 60;

            if (zoom_Image.gameObject.activeSelf)
            {
                zoom_Image.gameObject.SetActive(false);

            }
            else if (zoom_x4Image.gameObject.activeSelf)
            {
                zoom_x4Image.gameObject.SetActive(false);
            }


            if (PlayerPrefs.GetFloat("SRSlot3", 0) == 0)
            {
                fire_anim.SetBool("isGripSet", false);
                fire_anim.SetBool("isSrNoZoom", true);

            }
            else
            {
                fire_anim.SetBool("isGripSet", true);
                fire_anim.SetBool("isSrNoZoom", true);

            }

            fire_anim.SetTrigger("isSrSet");

            weaponType = 2;
            maxBulletCount = 5 + PlayerPrefs.GetFloat("SRSlot1", 0);
            curBulletCount = maxBulletCount;
            textbulletCount.text = curBulletCount + " / " + maxBulletCount;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            fire_anim.SetBool("isArZoom", false);
            fire_anim.SetBool("isGunZoom", false);
            fire_anim.SetBool("isSrZoom", false);
            fire_anim.SetBool("isSrNoZoom", true);

            this.GetComponent<Camera>().fieldOfView = 60;

            if (zoom_Image.gameObject.activeSelf)
            {
                zoom_Image.gameObject.SetActive(false);

            }
            else if (zoom_x4Image.gameObject.activeSelf)
            {
                zoom_x4Image.gameObject.SetActive(false);
            }

            fire_anim.SetTrigger("isGunSet");
            weaponType = 0;
            maxBulletCount = 8 + PlayerPrefs.GetFloat("GunSlot1", 0);
            curBulletCount = maxBulletCount;
            textbulletCount.text = curBulletCount + " / " + maxBulletCount;

        }
    }
}
