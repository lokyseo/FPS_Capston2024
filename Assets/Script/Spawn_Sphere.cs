using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Sphere : MonoBehaviour
{
    [SerializeField] Text timeText;
    public GameObject target_Sphere;

    int count_Spawn;
    public static int count_Score;

    float spawnInterval;

    public bool isReady; 
    public bool isSpawnStart;//���� ����
    public bool iscoroutine;

    void Start()
    {
        timeText.text = "";
        count_Spawn = 20;
        count_Score = 0;
        spawnInterval = 2.0f;
        isReady = false;
        isSpawnStart = false;
        iscoroutine = false;
    }

    void Update()
    {
        if(isReady)
        {
            if(!iscoroutine)
            {
                StartCoroutine("ReadyToStart");
            }
        }
        else
        {
            isSpawnStart = false;
            iscoroutine = false;

            count_Spawn = 20;
            count_Score = 0;
            StopCoroutine("ReadyToStart");
            this.GetComponent<Renderer>().material.color = Color.green;
            timeText.text = "";
        }

        if (isSpawnStart)
        {          
            spawnInterval -= Time.deltaTime;
            timeText.text = "���� : " + count_Score.ToString() + "\t ���� : " + count_Spawn.ToString();

            if (spawnInterval < 0)//2�ʸ��� ��ȯ
            {
                count_Spawn--;

                if (count_Spawn >= 0)//20������ ��ȯ
                {

                    Instantiate(target_Sphere,
                        new Vector3(Random.Range(-15.0f, 15.0f), Random.Range(0, 10.0f), transform.position.z), Quaternion.identity);
                    spawnInterval = 2.0f;
                }
                else
                {
                    count_Spawn = 20;
                    this.GetComponent<Renderer>().material.color = Color.green;
                    isSpawnStart = false;
                    isReady = false;
                    timeText.text = "";
                    iscoroutine = false;

                }


            }
        }
       
    }

    IEnumerator ReadyToStart()
    {
        iscoroutine = true;

        timeText.text = "3";
        yield return new WaitForSeconds(1.0f);
        timeText.text = "2";
        yield return new WaitForSeconds(1.0f);
        timeText.text = "1";
        yield return new WaitForSeconds(1.0f);
        timeText.text = "Start";
        yield return new WaitForSeconds(1.0f);
        timeText.text = "���� : 0\t ���� : 20";

        
        isSpawnStart = true;

    }
}
