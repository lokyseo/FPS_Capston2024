using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_Shot : MonoBehaviour
{
    public Image hit_Image;
    public Text textbulletCount;

    public ParticleSystem gunFire;
    public GameObject Gun;
    Animator fire_anim;

    int curBulletCount;
    int maxBulletCount;

    void Start()
    {
        maxBulletCount = 6;
        curBulletCount = maxBulletCount;
        fire_anim = Gun.GetComponent<Animator>();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward* 100, Color.red);
        if (Input.GetKeyDown(KeyCode.Mouse0) && curBulletCount > 0)
        {
            curBulletCount--;
            textbulletCount.text = curBulletCount + " / " + maxBulletCount;
            fire_anim.SetTrigger("IsFire");
            gunFire.Play();

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitData;

            if (Physics.Raycast(ray, out hitData))
            {
                if(hitData.transform.name == "Start_Button") 
                {
                    if(hitData.transform.GetComponent<Spawn_Sphere>().isReady)//종료함
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

                if(hitData.transform.tag == "Target")
                {
                    hit_Image.color = new Color(1, 1, 1, 1);
                }

                if(hitData.transform.name.Contains("Sphere"))
                {
                    Destroy(hitData.transform.gameObject);
                    Spawn_Sphere.count_Score++;
                }
    
            }
        }

       if(Input.GetKeyDown(KeyCode.R))
        {
            curBulletCount = maxBulletCount;
            textbulletCount.text = curBulletCount + " / " + maxBulletCount;

        }
    }
    /*
    void Fire()
    {
        aimControl.Fire();
        if (fireTime >= fireRate) // 연사속도 시간을 넘으면
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position,  // 에임 정확도에 따라 레이를 쏨
                Camera.main.transform.forward + // 현재 카메라가 보는 방향을 시작점으로 에임의 정확도 범위 중 랜덤한 위치로 발사
                new Vector3(Random.Range(-aimControl.accuracy, aimControl.accuracy), Random.Range(-aimControl.accuracy, aimControl.accuracy), 0f),
                out hit, range))
            {
                if (hit.transform.tag == "Head") // 머리에 맞으면 2배의 데미지
                {
                    BotControl bot = hit.transform.gameObject.GetComponent<BotControl>();
                    bot.Damaged(10);
                }
                else if (hit.transform.gameObject.tag == "Bot") // 몸통일 경우 일반 데미지
                {
                    BotControl bot = hit.transform.gameObject.GetComponent<BotControl>();
                    bot.Damaged(5);
                }
            }
            Instantiate(bulletEffect, hit.point * 1.001f, Quaternion.LookRotation(hit.normal)); // 총 맞은 위치 표현
            GameObject effect_L = Instantiate(shootEffect, shootPoint_L); // 좌우 총 이펙트
            GameObject effect_R = Instantiate(shootEffect, shootPoint_R);

            Destroy(effect_L, 0.1f); Destroy(effect_R, 0.1f); // 이펙트 삭제
            currentBullet--; // 총알 감소
            fireTime = 0f;
        }
    }
    */
}
