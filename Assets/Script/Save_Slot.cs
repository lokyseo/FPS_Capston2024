using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save_Slot : MonoBehaviour
{
    private static bool hasInstance = false;
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(scene.name);
        if (scene.name.Contains("In"))
        {
            gameObject.SetActive(true);

        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    //void OnDisable()
    //{
    //    // 델리게이트 체인 제거
    //    SceneManager.sceneLoaded -= OnSceneLoaded;
    //}

    void Awake()
    {
        if (hasInstance)
        {
            // 이미 인스턴스가 존재하므로 이 인스턴스를 파괴합니다.
            Destroy(gameObject);
        }
        else
        {
            // 이 인스턴스가 유일하다는 것을 표시합니다.
            hasInstance = true;
            // 다른 씬으로 이동할 때 파괴되지 않도록 설정합니다.
            DontDestroyOnLoad(gameObject);
        }
    }

}
