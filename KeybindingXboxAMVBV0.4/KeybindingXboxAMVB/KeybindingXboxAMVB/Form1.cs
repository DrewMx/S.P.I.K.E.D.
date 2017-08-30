using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Gaming.Input;
using Hotkeys;

/********************************
// PROJECT S.P.I.K.E.D.
// Special
// Project:
// Improve
// Keybinding
// Environment
// Development
// V.3.0
// AUSTIN MICHAEL VAN BOCKERN
// 
// ANDREW ROCKFORD MADDOX
********************************/

namespace KeybindingXboxAMVB
{
    public partial class frmMain : Form
    {
        // New controller
        Gamepad Controller;
        // New timer
        Timer t = new Timer();    

        //Creating hotkey boject
        private Hotkeys.GlobalHotkey ghk;
       


        public frmMain()
        {
            InitializeComponent();

            //Setting the hotKey's hot key
            ghk = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.M, this);
            // Examples of event handlers made
            Gamepad.GamepadAdded += Gamepad_GamepadAdded;
            Gamepad.GamepadRemoved += Gamepad_GamepadRemoved;

            #region Original input code
            //if (Gamepad.Gamepads.Count > 0)
            //{
            //    Controller = Gamepad.Gamepads.First();
            //    var Reading = Controller.GetCurrentReading();
            //    if (Reading.Buttons == GamepadButtons.A)
            //    {
            //        A.Click += APressed;
            //    }
            //}
#endregion

            // Timer setup
            t.Tick += T_Tick;
            t.Interval = 10;
            t.Start();
        }
        //method acatavating the hotkey
        private void HandleHotkey()
        {
            SendKeys.Send("d");
        }
        //I think the event code to work while out of focus
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkeys.Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }

        private void T_Tick(object sender, EventArgs e)
        {

            // CODE FOR SENDING KEY PRESS SIGNALS
            // SendKeys.Send("{A}");

            // Evaluates if a gamepad is connected to the system.
            if (Gamepad.Gamepads.Count > 0)
            {
                Controller = Gamepad.Gamepads.First();
                var Reading = Controller.GetCurrentReading();

                bool APress = false;
                bool BPress = false;
                bool XPress = false;
                bool YPress = false;
                bool DPadLeft = false;
                bool DPadUp = false;
                bool DPadRight = false;
                bool DPadDown = false;
                bool Start = false;
                bool Select = false;
                bool LeftBumper = false;
                bool RightBumper = false;
                bool LeftStickButton = false;
                bool RightStickButton = false;

                // Code for "A" Button
                if (Reading.Buttons == GamepadButtons.A)
                {
                    APress = true;
                }
                else
                {
                    APress = false;
                }

                if (APress)
                {
                    lblAButton.Text = "A is Pressed";
                    SendKeys.Send("{" + "A" + "}");
                }
                else
                {
                    lblAButton.Text = "";
                }

                // Code for "B" Button
                if (Reading.Buttons == GamepadButtons.B)
                {
                    BPress = true;
                }
                else
                {
                    BPress = false;
                }

                if (BPress)
                {
                    lblBButton.Text = "B is Pressed";
                }
                else
                {
                    lblBButton.Text = "";
                }

                // Code for "X" Button
                if (Reading.Buttons == GamepadButtons.X)
                {
                    XPress = true;
                }
                else
                {
                    XPress = false;
                }

                if (XPress)
                {
                    lblXButton.Text = "X is Pressed";
                }
                else
                {
                    lblXButton.Text = "";
                }

                // Code for "Y" Button
                if (Reading.Buttons == GamepadButtons.Y)
                {
                    YPress = true;
                }
                else
                {
                    YPress = false;
                }

                if (YPress)
                {
                    lblYButton.Text = "Y is Pressed";
                }
                else
                {
                    lblYButton.Text = "";
                }

                // Code for Left D Pad
                if (Reading.Buttons == GamepadButtons.DPadLeft)
                {
                    DPadLeft = true;
                }
                else
                {
                    DPadLeft = false;
                }

                if (DPadLeft)
                {
                    lblDPadLeft.BackColor = Color.Red;
                }
                else
                {
                    lblDPadLeft.BackColor = Color.White;
                }

                // Code for Up D Pad
                if (Reading.Buttons == GamepadButtons.DPadUp)
                {
                    DPadUp = true;
                }
                else
                {
                    DPadUp = false;
                }

                if (DPadUp)
                {
                    lblDPadUp.BackColor = Color.Red;
                }
                else
                {
                    lblDPadUp.BackColor = Color.White;
                }

                // Code for Right D Pad
                if (Reading.Buttons == GamepadButtons.DPadRight)
                {
                    DPadRight = true;
                }
                else
                {
                    DPadRight = false;
                }

                if (DPadRight)
                {
                    lblDPadRight.BackColor = Color.Red;
                }
                else
                {
                    lblDPadRight.BackColor = Color.White;
                }

                // Code for Down D Pad
                if (Reading.Buttons == GamepadButtons.DPadDown)
                {
                    DPadDown = true;
                }
                else
                {
                    DPadDown = false;
                }

                if (DPadDown)
                {
                    lblDPadDown.BackColor = Color.Red;
                }
                else
                {
                    lblDPadDown.BackColor = Color.White;
                }

                // Code for Start Button
                if (Reading.Buttons == GamepadButtons.Menu)
                {
                    Start = true;
                }
                else
                {
                    Start = false;
                }

                if (Start)
                {
                    lblStart.Text = "Start is Pressed";
                    SendKeys.Send("{ENTER}");
                }
                else
                {
                    lblStart.Text = "";
                }

                // Code for Select Button
                if (Reading.Buttons == GamepadButtons.View)
                {
                    Select = true;
                }
                else
                {
                    Select = false;
                }

                if (Select)
                {
                    lblSelect.Text = "Select is Pressed";
                    SendKeys.Send("{BACKSPACE}");
                }
                else
                {
                    lblSelect.Text = "";
                }

                // Code for Left Bumper
                if (Reading.Buttons == GamepadButtons.LeftShoulder)
                {
                    LeftBumper = true;
                }
                else
                {
                    LeftBumper = false;
                }

                if (LeftBumper)
                {
                    lblLeftBumper.Text = "Left Bumper is Pressed";
                    SendKeys.Send("{LEFT}");
                }
                else
                {
                    lblLeftBumper.Text = "";
                }

                // Code for Right Bumper
                if (Reading.Buttons == GamepadButtons.RightShoulder)
                {
                    RightBumper = true;
                }
                else
                {
                    RightBumper = false;
                }

                if (RightBumper)
                {
                    lblRightBumper.Text = "Right Bumper is Pressed";
                    SendKeys.Send("{RIGHT}");
                }
                else
                {
                    lblRightBumper.Text = "";
                }

                // Code for Left Stick Button
                if (Reading.Buttons == GamepadButtons.LeftThumbstick)
                {
                    LeftStickButton = true;
                }
                else
                {
                    LeftStickButton = false;
                }

                if (LeftStickButton)
                {
                    lblLeftStick.BackColor = Color.Red;
                }
                else
                {
                    lblLeftStick.BackColor = DefaultBackColor;
                }

                // Code for Right Stick Button
                if (Reading.Buttons == GamepadButtons.RightThumbstick)
                {
                    RightStickButton = true;
                }
                else
                {
                    RightStickButton = false;
                }

                if (RightStickButton)
                {
                    lblRightStick.BackColor = Color.Red;
                }
                else
                {
                    lblRightStick.BackColor = DefaultBackColor;
                }

                // Right trigger reading
                lblRightTriggerReading.Text = Reading.RightTrigger.ToString();
                // Left trigger reading
                lblLeftTriggerReading.Text = Reading.LeftTrigger.ToString();

                // Right Stick X/Y reading
                lblRightStick.Text = Reading.RightThumbstickX.ToString() + "\n" + Reading.RightThumbstickY.ToString();
                // Left Stick X/Y reading
                lblLeftStick.Text = Reading.LeftThumbstickX.ToString() + "\n" + Reading.LeftThumbstickY.ToString();

                #region Old Switch
                //switch (Reading.Buttons)
                //{
                //    case GamepadButtons.A:
                //        MessageBox.Show("A is pressed");
                //        break;
                //    case GamepadButtons.B:
                //        MessageBox.Show("B is pressed");
                //        break;
                //    case GamepadButtons.X:
                //        MessageBox.Show("X is pressed");
                //        break;
                //    case GamepadButtons.Y:
                //        MessageBox.Show("Y is pressed");
                //        break;
                //    case GamepadButtons.Menu:
                //        MessageBox.Show("Start is pressed");
                //        break;
                //    case GamepadButtons.View:
                //        MessageBox.Show("Select is pressed");
                //        break;
                //    case GamepadButtons.DPadDown:
                //        MessageBox.Show("DPadDown is pressed");
                //        break;
                //    case GamepadButtons.DPadUp:
                //        MessageBox.Show("DPadUp is pressed");
                //        break;
                //    case GamepadButtons.DPadLeft:
                //        MessageBox.Show("DPadLeft is pressed");
                //        break;
                //    case GamepadButtons.DPadRight:
                //        MessageBox.Show("DPadRight is pressed");
                //        break;
                //    case GamepadButtons.LeftShoulder:
                //        MessageBox.Show("LeftShoulder is pressed");
                //        break;
                //    case GamepadButtons.LeftThumbstick:
                //        MessageBox.Show("LeftThumbstick is pressed");
                //        break;
                //    case GamepadButtons.RightShoulder:
                //        MessageBox.Show("RightShoulder is pressed");
                //        break;
                //    case GamepadButtons.RightThumbstick:
                //        MessageBox.Show("RightThumbstick is pressed");
                //        break;
                //}
#endregion
            }

                
        }

        private void Gamepad_GamepadAdded(object sender, Gamepad e)
        {
            MessageBox.Show("New GamePad Detected", "Alert");
        }

        private void Gamepad_GamepadRemoved(object sender, Gamepad e)
        {
            MessageBox.Show("Lost Connection to GamePad", "Alert");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WriteLine("Trying to register SHIFT+ALT+O");
            if (ghk.Register())
                WriteLine("Hotkey registered.");
            else
                WriteLine("Hotkey failed to register");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ghk.Unregiser())
                MessageBox.Show("Hotkey failed to unregister!");
        }
        private void WriteLine(string text)
        {
            txt_HotKey.Text += text + Environment.NewLine;
        }
    }
}
