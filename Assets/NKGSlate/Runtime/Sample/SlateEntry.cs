//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2021年8月12日 21:10:15
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

namespace NKGSlate.Runtime
{
    public class SlateEntry : MonoBehaviour
    {
        public static Dictionary<Type, Type> TypeInfos = new Dictionary<Type, Type>()
        {
            {typeof(ST_LogActionData), typeof(ST_LogAction)},
        };

        public ST_Director Director = new ST_Director();
        public ST_CutSceneData CutSceneData;

        private ST_CutSceneData DeserializeFromFile()
        {
            ST_CutSceneData sceneData = new ST_CutSceneData();
            ST_GroupData stGroupData = new ST_GroupData() {RelativelyStartTime = 0, RelativelyEndTime = 20000};
            ST_TrackData stTrackData = new ST_TrackData() {RelativelyStartTime = 2000, RelativelyEndTime = 15000};

            stTrackData.ActionDatas.Add(new ST_LogActionData()
                {RelativelyStartTime = 5000, RelativelyEndTime = 10000, LogInfo = "测试"});
            stGroupData.TrackDatas.Add(stTrackData);
            sceneData.GroupDatas.Add(stGroupData);

            return sceneData;
        }

        private void Awake()
        {
            CutSceneData = DeserializeFromFile();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Director.HasPaused)
                    Director.Resume();
                else
                {
                    Director.Pause();
                }
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Director.BeginPlay(Director.CurrentFrame, CutSceneData);
            }
        }

        private void FixedUpdate()
        {
            if (!Director.HasPaused && Director.HasInited)
            {
                Director.CurrentFrame += 1;
            }

            Director.Sample(Director.CurrentFrame);
        }
    }
}