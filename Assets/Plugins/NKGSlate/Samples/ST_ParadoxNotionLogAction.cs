//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2021年8月15日 19:30:24
//------------------------------------------------------------


using System.Collections.Generic;
using NKGSlate.Runtime;
using Sirenix.OdinInspector;
using Slate;
using UnityEngine;

namespace NKGSlate.Sample
{
    [Attachable(typeof(ST_ParadoxNotionTrack))]
    [Description("打印一条信息")]
    [Name("打印信息")]
    public class ST_ParadoxNotionLogAction: ST_AParadoxNotionSlateActionBase
    {
        [SerializeField] [HideInInspector] private float m_Reallength = 1;

        public override float length
        {
            get { return m_Reallength; }
            set { m_Reallength = value; }
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            
            BindingDate = new ST_LogActionData();
        }
    }
}