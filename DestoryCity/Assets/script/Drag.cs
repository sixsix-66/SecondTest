using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    GameObject nowparent;
   
    public GameObject go;
    private GameObject wupinobj;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 colliderHitPoint;


    GameObject guanghuan;
    
    LineRenderer LineRender;
    float R=2;//半径
    int N=200;   //描点个数
    float width=4;  //圆的粗细
    public Material CircleMaterial; //材质

    

    void Start()
    {

        nowparent = GameObject.Find("Terrain");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //生成攻击范围圈
        guanghuan = new GameObject("kong");
        guanghuan.transform.SetParent(nowparent.transform);
        guanghuan.AddComponent<LineRenderer>();
        LineRender =guanghuan.GetComponent<LineRenderer>();
        LineRender.positionCount = (N + 1);


        Debug.Log("开始拖拽" + wupinobj.transform.parent);
        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        //将屏幕坐标转换为世界坐标
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        //使3D物体跟随鼠标移动
        if(Physics.Raycast(ray,out hit))
        {
            //将世界坐标转换为本地坐标
            colliderHitPoint = hit.collider.transform.InverseTransformPoint(hit.point);
            
            Debug.Log("拖拽中");

            //绘制范围圈
            drawCircle(colliderHitPoint);


        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //光环消失
        Destroy(guanghuan);
        Createobj();
        Debug.Log("拖拽结束" );
        

    }

    void Createobj()
    {
        //生成3d物体
        wupinobj = Instantiate(go);
        wupinobj.transform.SetParent(nowparent.transform);
        wupinobj.transform.localPosition = new Vector3(colliderHitPoint.x, colliderHitPoint.y + 1, colliderHitPoint.z);
        Destroy(wupinobj, 2.0f);
    }

    //绘制攻击范围
    void drawCircle(Vector3 pos)
    {
        
        LineRender.startWidth = width;
        LineRender.material = CircleMaterial;

        for (int i = 0; i < N + 1; i++)
        {
            float x = R * Mathf.Cos((360f / N * i) * Mathf.Deg2Rad) + pos.x; //确定x坐标
            float z = R * Mathf.Sin((360f / N * i) * Mathf.Deg2Rad) + pos.z; //确定z坐标
            LineRender.SetPosition(i,new Vector3(x, pos.y, z));
            
        }
    }  
}
