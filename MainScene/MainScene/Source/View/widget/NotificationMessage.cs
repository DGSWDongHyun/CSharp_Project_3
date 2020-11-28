using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MainScene.widget
{
    class NotificationMessage
    {
        private readonly NotifyIcon notifyIcon;

        public NotificationMessage()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.BalloonTipClosed += (s, e) => notifyIcon.Visible = false;
        }

        public void ShowNotification(string title, string message)
        {
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(500, title, message, ToolTipIcon.Info);
        }
    }
}
