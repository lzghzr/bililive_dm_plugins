using System;
using System.Text.RegularExpressions;
using BilibiliDM_PluginFramework;

namespace ShowInfo
{
    public class ShowInfo : DMPlugin
    {
        public ShowInfo()
        {
            ReceivedDanmaku += B_ReceivedDanmaku;
            PluginAuth = "lzblzr";
            PluginName = "用户信息";
            PluginDesc = "显示投喂用户的隐藏信息";
            PluginCont = "lzggzr@gmail.com";
            PluginVer = "v1.0.0";
        }
        private void B_ReceivedDanmaku(object sender, ReceivedDanmakuArgs e)
        {
            if (e.Danmaku.MsgType == MsgTypeEnum.GiftSend)
            {
                string rawData = e.Danmaku.RawData;

                string defaultLog;
                string userLog = defaultLog = e.Danmaku.UserName + " 剩余";

                Regex gold = new Regex("\"gold\":\"?(\\d+)");
                Match hasGold = gold.Match(rawData);
                if (hasGold.Success)
                {
                    string value = hasGold.Groups[1].Value;
                    if (value != "0")
                        userLog += String.Format(" {0}金瓜子", value);
                }

                Regex silver = new Regex("\"silver\":\"?(\\d+)");
                Match hasSilver = silver.Match(rawData);
                if (hasSilver.Success)
                {
                    string value = hasSilver.Groups[1].Value;
                    if (value != "0")
                        userLog += String.Format(" {0}银瓜子", value);
                }

                Regex package = new Regex("\"eventNum\":\"?(\\d+)");
                Match hasPackage = package.Match(rawData);
                if (hasPackage.Success)
                {
                    string value = hasPackage.Groups[1].Value;
                    if (value != "0")
                        userLog += String.Format(" {0}{1}", value, e.Danmaku.GiftName);
                }

                Regex normalCapsule = new Regex("\"normal\":{ \"coin\":\"?(\\d+)");
                Match hasNormalCapsule = normalCapsule.Match(rawData);
                if (hasNormalCapsule.Success)
                {
                    string value = hasNormalCapsule.Groups[1].Value;
                    if (value != "0")
                        userLog += String.Format(" {0}普通扭蛋", value);
                }

                Regex colorfulCapsule = new Regex("\"colorful\":{ \"coin\":\"?(\\d+)");
                Match hascClorfulCapsule = colorfulCapsule.Match(rawData);
                if (hascClorfulCapsule.Success)
                {
                    string value = hascClorfulCapsule.Groups[1].Value;
                    if (value != "0")
                        userLog += String.Format(" {0}梦幻扭蛋", value);
                }

                if (userLog != defaultLog)
                    Log(userLog);
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
