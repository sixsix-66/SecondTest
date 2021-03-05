using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 
 * 控制摄像机的视野范围
 *
 */
public class CameraControl : MonoBehaviour
{
     private Transform player;
     private Vector3 offsetPosition;
     private float distance;
     private float scrollSpeed = 10; //鼠标滚轮速度
     private bool isRotating; //开启摄像机旋转
     private float rotateSpeed = 2; //摄像机旋转速度
 
     private float speed = 10;
     private float endZ = -8;
   
     private Camera came;


    private void Awake()
    {
        player = GameObject.FindWithTag("player").transform;
        //came = this.GetComponent<Camera>();
        came = Camera.main;

    }
    // Start is called before the first frame update
    void Start()
    {
        //摄像机朝向player
        transform.LookAt(player.position);

        //获取摄像机与player的位置偏移
        offsetPosition = transform.position = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        //摄像机跟随player与player保持相对位置偏移
        transform.position = offsetPosition + player.position;

        //摄像机视野范围控制 
        ScrollView();
        //摄像机的旋转
        RotateView();
    }

    void ScrollView()
    {
        //放大视野
        if(Input.GetKey(KeyCode.PageUp))
        {
            if (came.fieldOfView <= 70)
            {
                came.fieldOfView += 5;
            }
        }
        //缩小视野
        if(Input.GetKey(KeyCode.PageDown))
        {
            if (came.fieldOfView >= 30)
            {
                came.fieldOfView -= 5;
            }
        }
    }

     void RotateView()
    {
         //获取鼠标在水平方向的滑动
         Debug.Log(Input.GetAxis("Mouse X"));
        //获取鼠标在垂直方向的滑动
        Debug.Log(Input.GetAxis("Mouse Y"));

        //按下鼠标右键开启旋转摄像机
         if (Input.GetMouseButtonDown(1))
        {
             isRotating = true;
         }

         //抬起鼠标右键关闭旋转摄像机
         if (Input.GetMouseButtonUp(1))
        {
             isRotating = false;
         }

         if (isRotating)
        {

             //获取摄像机初始位置
             Vector3 pos = transform.position;
             //获取摄像机初始角度
             Quaternion rot = transform.rotation;

             //摄像机围绕player的位置延player的Y轴旋转,旋转的速度为鼠标水平滑动的速度
             transform.RotateAround(player.position, player.up, Input.GetAxis("Mouse X") * rotateSpeed);

             //摄像机围绕player的位置延自身的X轴旋转,旋转的速度为鼠标垂直滑动的速度
             transform.RotateAround(player.position, transform.right, Input.GetAxis("Mouse Y") * rotateSpeed);

             //获取摄像机x轴向的欧拉角
             float x = transform.eulerAngles.x;

             //如果摄像机的x轴旋转角度超出范围,恢复初始位置和角度
             if (x < 10 || x > 80)
            {
                 transform.position = pos;
                 transform.rotation = rot;
             }
         }

         //更新摄像机与player的位置偏移
         offsetPosition = transform.position - player.position;
     }
}
