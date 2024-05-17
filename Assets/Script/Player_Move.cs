using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;

    public float lookSensitivity_H;
    public float lookSensitivity_V;
    private float test;

    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX;

    [SerializeField]
    //private Camera theCamera;
    private Rigidbody myRigid;
    public Vector3 _velocity;

    void Start()
    {

        myRigid = GetComponent<Rigidbody>(); 
        
    }

    void Update()  
    {
        Move();                 // 1️ 키보드 입력에 따라 이동
        CharacterRotation();    // 3️ 마우스 좌우(X) 움직임에 따라 캐릭터 Y 축 회전 


    }

   
    private void Move()
    {
       float _moveDirX = Input.GetAxisRaw("Horizontal");
       float _moveDirZ = Input.GetAxisRaw("Vertical");
       Vector3 _moveHorizontal = transform.right * _moveDirX;
       Vector3 _moveVertical = transform.forward * _moveDirZ;
       
       _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;
       
       myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);

        
        //myRigid.velocity = _velocity;
    }

    

    private void CharacterRotation()  // 좌우 캐릭터 회전
    {
        float _yRotation = Input.GetAxisRaw("Mouse X") * lookSensitivity_H;
       
        test += _yRotation;
        transform.rotation = Quaternion.Euler(0, test, 0);             // 플레이어 캐릭터의 회전을 조절

        // Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        // myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
        //Debug.Log(myRigid.rotation);  // 쿼터니언
        //Debug.Log(myRigid.rotation.eulerAngles); // 벡터
    }

    
}
