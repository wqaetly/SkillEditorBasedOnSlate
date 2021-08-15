//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2021年8月15日 19:11:02
//------------------------------------------------------------

using NKGSlate.Runtime;
using Sirenix.OdinInspector;
using Slate;
using UnityEngine;

namespace NKGSlate.Editor
{
    /// <summary>
    /// 表现在Slate编辑器中的Action基类
    /// </summary>
    public abstract class ST_AParadoxNotionSlateActionBase : ActionClip
    {
        [SerializeField] [HideInInspector] private float _length = 1;

        public override string info => "Log";

        public override float length
        {
            get { return _length; }
            set { _length = value; }
        }

        /// <summary>
        /// 绑定的数据，用于数据预览和导出
        /// </summary>
        [BoxGroup("绑定的数据", CenterLabel = true)] [HideLabel] public ST_DirectableData BindingDate;

#if UNITY_EDITOR

        /// <summary>
        /// 初始化绑定数据
        /// </summary>
        [Button("初始化绑定数据", 35), GUIColor(0.78f, 0.23f, 0.56f)]
        public void InitBingdingData()
        {
            BindingDate.RelativelyStartTime = (long) (this.startTime * 1000);
            BindingDate.RelativelyEndTime = (long) (this.endTime * 1000);
        }

#endif
    }
}