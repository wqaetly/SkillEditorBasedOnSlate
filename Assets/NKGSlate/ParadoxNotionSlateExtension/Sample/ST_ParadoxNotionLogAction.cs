﻿//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2021年8月15日 19:30:24
//------------------------------------------------------------


using System.Collections.Generic;
using NKGSlate.Runtime;
using Sirenix.OdinInspector;
using Slate;
using UnityEngine;

namespace NKGSlate.Editor.Sample
{
    [Attachable(typeof(ST_ParadoxNotionTrack))]
    [Description("打印一条信息")]
    public class ST_ParadoxNotionLogAction: ST_AParadoxNotionSlateActionBase
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            BindingDate = new ST_LogActionData();
        }
    }
}