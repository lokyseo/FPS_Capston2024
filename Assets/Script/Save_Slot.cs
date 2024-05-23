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
    //    // ��������Ʈ ü�� ����
    //    SceneManager.sceneLoaded -= OnSceneLoaded;
    //}

    void Awake()
    {
        if (hasInstance)
        {
            // �̹� �ν��Ͻ��� �����ϹǷ� �� �ν��Ͻ��� �ı��մϴ�.
            Destroy(gameObject);
        }
        else
        {
            // �� �ν��Ͻ��� �����ϴٴ� ���� ǥ���մϴ�.
            hasInstance = true;
            // �ٸ� ������ �̵��� �� �ı����� �ʵ��� �����մϴ�.
            DontDestroyOnLoad(gameObject);
        }
    }

}
