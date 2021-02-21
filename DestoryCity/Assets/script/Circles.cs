using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circles : MonoBehaviour
{
    //public GameObject CirclePoint;//圆心
    public float R;//半径
    public int N;   //描点个数
    public float width;  //圆的粗细
    public Material CircleMaterial; //材质

    private GameObject Mousepos;

    void Start()
    {
        gameObject.AddComponent<LineRenderer>();
        GetComponent<LineRenderer>().positionCount = (N + 1);//这里要加1,达成闭合曲线
    }

    void Update()
    {
        //将屏幕坐标转换为世界坐标
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        var colliderHitPoint = Vector3.zero;
        if (Physics.Raycast(ray, out hit))
        {
            //世界转本地
            colliderHitPoint = hit.collider.transform.InverseTransformPoint(hit.point);
            GetComponent<LineRenderer>().startWidth = width;
            GetComponent<LineRenderer>().material = CircleMaterial;

            for (int i = 0; i < N + 1; i++)
            {
                float x = R * Mathf.Cos((360f / N * i) * Mathf.Deg2Rad) + colliderHitPoint.x; //确定x坐标
                float z = R * Mathf.Sin((360f / N * i) * Mathf.Deg2Rad) + colliderHitPoint.z; //确定z坐标
                GetComponent<LineRenderer>().SetPosition(i, new Vector3(x, colliderHitPoint.y, z));
            }
        
        }
        //首先获取到当前物体的屏幕坐标
        //Vector3 pos = Camera.main.WorldToScreenPoint(Mousepos.transform.position);
        //让鼠标的屏幕坐标的Z轴等于当前物体的屏幕坐标的Z轴，也就是相隔的距离
        //Vector3 m_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos.z);
        //将正确的鼠标屏幕坐标换成世界坐标交给物体

        //使3D物体跟随鼠标移动
        //Mousepos.transform.position = Camera.main.ScreenToWorldPoint(m_MousePos);
            
        


    }


}
