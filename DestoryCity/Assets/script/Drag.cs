using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/*
 * 
 * 拖拽生成粒子特效
 * 
 */

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{  
    public GameObject go;//导入的特效
    private GameObject wupinobj;
    private Ray ray;//射线
    private RaycastHit hit;//碰撞点


    //public Camera newcamera;
    GameObject guanghuan;//光环
    
    LineRenderer LineRender;
    public float R=2;//半径
    public float R1 = 1f;
    int N=50;   //描点个数
    float width=0.4f;  //圆的粗细
    public Material CircleMaterial; //材质

    

    void Start()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //生成攻击范围圈
        guanghuan = new GameObject("kong");
        
        guanghuan.AddComponent<LineRenderer>();
        LineRender =guanghuan.GetComponent<LineRenderer>();
        LineRender.positionCount = (N + 1);


        //Debug.Log("开始拖拽" + wupinobj.transform.parent);
        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        //将屏幕坐标转换为世界坐标
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        //使3D物体跟随鼠标移动
        if(Physics.Raycast(ray,out hit))
        {
            //绘制范围圈
            drawCircle(hit.point);
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //光环消失
        Destroy(guanghuan);

        Createobj();

    }

    void Createobj()
    {
        //生成特效
        wupinobj = Instantiate(go);
        //特效的位置
        wupinobj.transform.position = new Vector3(hit.point.x, hit.point.y+0.5f, hit.point.z);
        //2秒后消失
        Destroy(wupinobj, 2.0f);
    }

    //绘制攻击范围
    void drawCircle(Vector3 pos)
    {
        //float h = 0.1;
        LineRender.startWidth = width;
        LineRender.material = CircleMaterial;

        for (int i = 0; i < N + 1; i++)
        {
            if (go.tag == ("bb"))
            {
                R = 1.0f;
            }
            else if (go.tag == ("aa"))
            {
                R = 2f;

            }
            //确定x坐标
            float x = R * Mathf.Cos((360f / N * i) * Mathf.Deg2Rad) + pos.x; 
            
            //确定z坐标
            float z = R * Mathf.Sin((360f / N * i) * Mathf.Deg2Rad) + pos.z; 

            LineRender.SetPosition(i, new Vector3(x, pos.y + 0.2f, z));
            
        }
    }  
}
