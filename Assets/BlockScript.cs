using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public GameObject parent;
    public bool isCenter, isblank;
    GameObject manager;
    private void Start()
    {
        parent = transform.parent.gameObject;
        manager = GameObject.Find("GameManager").gameObject;

    }
    private void OnMouseDown()
    {Debug.Log("NAme :: " + gameObject.name + "::" + transform.localPosition);
        if (isblank || isCenter) { return; }
        parent.GetComponent<SwipeControl>().onObject = true;
        manager.GetComponent<GameManager>().currentCube = gameObject;
    }
    private void OnMouseOver()
    {
        if (manager.GetComponent<GameManager>().currentCube == null) { return; }
        else if(!isblank && manager.GetComponent<GameManager>().currentCube.name!=gameObject.name)
        { manager.GetComponent<GameManager>().currentCube = null;
            return;
        }
        if (!isblank) { return; }
       


        GameObject cur = manager.GetComponent<GameManager>().currentCube.gameObject;
        Vector3 pos =new Vector3(cur.transform.position.x,cur.transform.position.y,cur.transform.position.z);
        Vector3 p = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        Debug.Log("YAY");
        LeanTween.move(cur, p, 0.1f);
        transform.position = pos;
        manager.GetComponent<GameManager>().currentCube =null;
    }
    private void Update()
    {

    }
}
