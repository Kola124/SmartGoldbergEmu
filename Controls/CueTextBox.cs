// Thanks, Credits to Hans Passant:
// https://stackoverflow.com/questions/4902565/watermark-textbox-in-winforms

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using OSUtility;

class CueTextBox : TextBox
{
    private const int EM_SETCUEBANNER = 0x1501;


    [Localizable(true)]
    public string Cue
    {
        get { return mCue; }
        set { mCue = value; UpdateCue(); }
    }

    private void UpdateCue()
    {
        if (this.IsHandleCreated && mCue != null)
        {
            if (OSDetector.IsWindows())
            {
                SendMessage(this.Handle, EM_SETCUEBANNER, (IntPtr)1, mCue);
            }
            else
            {

            }
        }
    }
    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        UpdateCue();
        if(!OSDetector.IsWindows())
        {
            this.GotFocus += (Object sender, EventArgs ev) =>
            {
                if(Text == mCue)
                {
                    Text = "";
                }
            };

            this.LostFocus += (Object sender, EventArgs ev) =>
            {
                if(Text == "")
                {
                    Text = mCue;
                }
            };
        }
    }
    private string mCue;

    // PInvoke
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);
}