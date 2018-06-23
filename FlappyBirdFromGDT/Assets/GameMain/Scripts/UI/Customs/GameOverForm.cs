﻿using GameFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace FlappyBirdFromGDT
{
    /// <summary>
    /// 游戏结束界面
    /// </summary>
    public class GameOverForm : UGuiForm
    {
        public Text Score;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            //获取分数
            int score = GameEntry.DataNode.GetNode("Score").GetData<VarInt>();
            Score.text = "你的总分：" + score;
        }

        protected override void OnClose(object userData)
        {
            base.OnClose(userData);
            Score.text = string.Empty;
        }

        public void OnRestartButtonClick()
        {
            Close();
            //派发重新开始游戏事件
            GameEntry.Event.Fire(this, ReferencePool.Acquire<RestartEventArgs>());
            GameEntry.Entity.ShowBird(new BirdData(GameEntry.Entity.GenerateSerialId(), 3, 5f));
            GameEntry.Entity.ShowPipe(new PipeData(GameEntry.Entity.GenerateSerialId(), 2, 1f));
        }

        public void OnReturnButtonClick()
        {
            Close(true);
            //派发返回菜单场景事件
            GameEntry.Event.Fire(this,ReferencePool.Acquire<ReturnMenuEventArgs>());
        }
    }
}
