﻿//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2021年7月25日 16:54:17
//------------------------------------------------------------

using System.Collections.Generic;

namespace NKGSlate.Runtime
{
    public class ST_Track : ST_IDirectable
    {
        public ST_DirectableData DirectableData { get; set; }
        public uint StartFrame { get; set; }
        public uint EndFrame { get; set; }

        public bool Initialize(uint currentFrame, ST_DirectableData stDirectableData)
        {
            this.DirectableData = stDirectableData;
            StartFrame =
                ST_TimeToFrameCaculator.CaculateFrameCountFromTimeLength(this.DirectableData.RelativelyStartTime);
            EndFrame =
                ST_TimeToFrameCaculator.CaculateFrameCountFromTimeLength(this.DirectableData.RelativelyEndTime);
            return OnInitialize(currentFrame);
        }

        void ST_IDirectable.Enter()
        {
            OnEnter();
        }

        void ST_IDirectable.Update(uint currentFrame, uint previousFrame)
        {
            OnUpdate(currentFrame, previousFrame);
        }

        void ST_IDirectable.Exit()
        {
            OnExit();
        }

        public virtual bool OnInitialize(uint currentFrame)
        {
            return true;
        }
        
        public virtual void OnEnter()
        {
        }

        public virtual void OnUpdate(uint currentFrame, uint previousFrame)
        {
        }

        public virtual void OnExit()
        {
        }
    }
}