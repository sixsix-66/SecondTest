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
    //private Vector3 colliderHitPoint;

    void Start()
    {
        nowparent = GameObject.Find("Terrain");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //生成3d物体
        if (go != null)
        {
            wupinobj = Instantiate(go);
            wupinobj.transform.SetParent(nowparent.transform);
            Debug.Log("开始拖拽" + wupinobj.transform.parent);
            wupinobj.transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //将屏幕坐标转换为世界坐标
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //使3D物体跟随鼠标移动
        if(Physics.Raycast(ray,out hit))
        {
            //将世界坐标转换为本地坐标
            var colliderHitPoint = hit.collider.transform.InverseTransformPoint(hit.point);
            wupinobj.transform.localPosition = new Vector3(colliderHitPoint.x, colliderHitPoint.y+1, colliderHitPoint.z);
            Debug.Log("拖拽中");
            Debug.Log(colliderHitPoint);
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        Debug.Log("拖拽结束" );
        //实现特效伤害功能

    }

   
}
