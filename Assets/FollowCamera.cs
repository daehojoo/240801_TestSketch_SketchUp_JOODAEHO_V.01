using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float Height = 5.0f;//ī�޶� ����
    [SerializeField] private float distance = 7.0f;//Ÿ�ٰ� ī�޶� �Ÿ�
    [SerializeField] private float movedamping = 10f;//ī�޶� �̵� ȸ���� ������ �ε巴�� ��ȭ�ϴ� ��
    [SerializeField] private float rotdamping = 15f;
    [SerializeField] private Transform CameraTr;//ī�޶� Ʈ������
    [SerializeField] private float targetoffset = 2.0f;//Ÿ�ٿ����� ī�޶� ���̰�



    public void Start()
    {
        CameraTr=transform;
        
      
    }
  


    void LateUpdate()//update�� �����ȴ��� lateupdate�� ���󰣴�. FixedUpdate
    {                       //Ÿ�� �����ǿ��� distance��ŭ�ڿ���ġ + Height���̸�ŭ ������ġ
        var Campos = target.position - (target.forward * distance) + (target.up * Height);
        CameraTr.position = Vector3.Slerp(CameraTr.position, Campos, Time.deltaTime*movedamping);
                            //��麸�� (�ڱ��ڽ� ��ġ����, campos����, damping �ð� ��ŭ �ε巴�� ������)
        CameraTr.rotation = Quaternion.Slerp(CameraTr.rotation,target.rotation, Time.deltaTime*rotdamping);
                            //��麸������ ȸ�� (�����ڽź��� Ÿ�Ϸ����̼Ǳ���)damping�ð� ��ŭ �ε巴�� ȸ����)
        CameraTr.LookAt(target.position+(target.up*targetoffset));
                            //Ÿ�� �����ǿ��� 2��ŭ ���� �ø�
    }
   
}
