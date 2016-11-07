using UnityEngine;
using System.Collections;

public class testWindow : UIWindowBase 
{

    //UI的初始化请放在这里
    public override void OnInit()
    {
        GetButton("Button").onClick.AddListener(onCLick);
    }

    //请在这里写UI的更新逻辑，当该UI监听的事件触发时，该函数会被调用
    public override void OnRefresh()
    {
    }

    //UI的进入动画
    public override IEnumerator EnterAnim(UIAnimCallBack l_animComplete, UICallBack l_callBack, params object[] objs)
    {
        AnimSystem.UguiAlpha(gameObject, 0, 1, 1, callBack:(object[] obj)=>
        {
            base.EnterAnim(l_animComplete, l_callBack, objs);
        });

        yield break;
    }

    //UI的退出动画
    public override IEnumerator ExitAnim(UIAnimCallBack l_animComplete, UICallBack l_callBack, params object[] objs)
    {
        AnimSystem.UguiAlpha(gameObject, 1, 0, 1, callBack: (object[] obj) =>
        {
            base.ExitAnim(l_animComplete, l_callBack, objs);
        });

        yield break;
    }

    public void onCLick()
    {
        Debug.Log("onCLick");
        UIManager.CloseUIWindow(this);
    }
}