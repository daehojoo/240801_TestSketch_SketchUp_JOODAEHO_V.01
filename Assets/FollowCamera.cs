using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float Height = 5.0f;//카메라 높이
    [SerializeField] private float distance = 7.0f;//타겟과 카메라 거리
    [SerializeField] private float movedamping = 10f;//카메라가 이동 회전시 떨림을 부드럽게 완화하는 값
    [SerializeField] private float rotdamping = 15f;
    [SerializeField] private Transform CameraTr;//카메라 트랜스폼
    [SerializeField] private float targetoffset = 2.0f;//타겟에서의 카메라 높이값



    public void Start()
    {
        CameraTr=transform;
        
      
    }
  


    void LateUpdate()//update가 먼저된다음 lateupdate로 따라간다. FixedUpdate
    {                       //타겟 포지션에서 distance만큼뒤에위치 + Height높이만큼 위에위치
        var Campos = target.position - (target.forward * distance) + (target.up * Height);
        CameraTr.position = Vector3.Slerp(CameraTr.position, Campos, Time.deltaTime*movedamping);
                            //곡면보간 (자기자신 위치에서, campos까지, damping 시간 만큼 부드럽게 움직임)
        CameraTr.rotation = Quaternion.Slerp(CameraTr.rotation,target.rotation, Time.deltaTime*rotdamping);
                            //곡면보간으로 회전 (자지자신부터 타켓로테이션까지)damping시간 만큼 부드럽게 회전함)
        CameraTr.LookAt(target.position+(target.up*targetoffset));
                            //타겟 포지션에서 2만큼 위로 올림
    }
   
}
