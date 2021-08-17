//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2021年8月17日 22:32:49
//------------------------------------------------------------

using UnityEngine;

namespace NKGSlate.Runtime
{
    public class ST_Event: ST_Action<ST_EventData>
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Debug.LogError($"ST_Event抛出一个事件：{this.BindingData.EventInfo}");
        }
    }
}