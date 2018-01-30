using System;
using BilibiliDM_PluginFramework;

namespace GoldSilver
{
    public class GoldSilver : DMPlugin
    {
        public GoldSilver()
        {
            ReceivedDanmaku += B_ReceivedDanmaku;
            PluginAuth = "lzblzr";
            PluginName = "金银礼物";
            PluginDesc = "在礼物后添加金银标识";
            PluginCont = "lzggzr@gmail.com";
            PluginVer = "v1.0.1";
            Start();
        }
        private void B_ReceivedDanmaku(object sender, ReceivedDanmakuArgs e)
        {
            if (e.Danmaku.MsgType == MsgTypeEnum.GiftSend)
            {
                string rawData = e.Danmaku.RawData;
                bool isBag = (rawData.Contains("\"gold\":0,") && rawData.Contains("\"silver\":0,")) || !rawData.Contains("\"remain\":0,");
                bool isSilver = rawData.Contains("\"giftId\":1,");
                e.Danmaku.GiftName += string.Format("({0})", isBag ? "包" : isSilver ? "银" : "金");
            }
        }
        public override void Admin()
        {
            base.Admin();
            Console.WriteLine("不要点啦, 没用的");
            Log("不要点啦, 没用的");
            AddDM("不要点啦, 没用的", true);
        }
        public override void Start()
        {
            base.Start();
            Console.WriteLine("插件已启用");
            Log("插件已启用");
            AddDM("插件已启用", true);
        }
        public override void Stop()
        {
            base.Stop();
            Console.WriteLine("插件已禁用");
            Log("插件已禁用");
            AddDM("插件已禁用", true);
        }
    }
}
