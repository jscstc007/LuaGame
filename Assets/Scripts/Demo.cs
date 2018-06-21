using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using UnityEngine.UI;

public class C1
{
    int i1 = 100;
    string s1 = "123123";
}

public class Demo : MonoBehaviour {

    LuaEnv luaEnv;

    private Transform Root;

    private C1 c1;

    private void Awake()
    {
        Root = GameObject.Find("/UI").transform;
    }

    // Use this for initialization
    void Start () {
        luaEnv = new LuaEnv();


        //call cs
        //DoCSMethod();
        //call lua
        DoLuaMethod();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void DoCSMethod ()
    {
        GameObject bg = Resources.Load<GameObject>("UI/BG_P");
        GameObject btn = Resources.Load<GameObject>("UI/Btn_B");

        GameObject bgGo = Instantiate(bg);
        bgGo.transform.SetParent(Root);
        bgGo.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        bgGo.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        bgGo.transform.localScale = Vector3.one;
        for (int i = 0;i < 10;i ++)
        {
            GameObject btnGo = Instantiate(btn);
            btnGo.transform.SetParent(bgGo.transform);
            btnGo.transform.localScale = Vector3.one;
            
            int index = i;
            btnGo.GetComponent<Button>().onClick.AddListener( ()=> { ClickMethod(index); } );
        }
    }

    private void ClickMethod (int index)
    {
        Debug.Log("Click:" + index);
    }

    private void DoLuaMethod ()
    {
        //string luaTxt = Resources.Load<TextAsset>("lua.lua").text;

        //luaEnv.DoString(luaTxt);

        luaEnv.DoString("require 'lua'");
    }

    private void OnDestroy()
    {
        luaEnv.Dispose();
    }
}
