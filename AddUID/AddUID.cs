using System;
using BilibiliDM_PluginFramework;

namespace AddUID
{
    public class AddUID : DMPlugin
    {
        public AddUID()
        {
            ReceivedDanmaku += B_ReceivedDanmaku;
            PluginAuth = "lzblzr";
            PluginName = "显示UID";
            PluginDesc = "在用户名后添加UID";
            PluginCont = "lzggzr@gmail.com";
            PluginVer = "v1.0.1";
            Start();
        }
        private void B_ReceivedDanmaku(object sender, ReceivedDanmakuArgs e)
        {
            if (e.Danmaku.UserID != 0)
                e.Danmaku.UserName += string.Format(" ({0})", e.Danmaku.UserID);
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
