using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace Presentation {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        // Importa la función "SendMessage" de la DLL "user32.dll"
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void btnClosed_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnMax_Click(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        private void btnMin_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e) {
            // Llama a la función "ReleaseCapture" para liberar la captura del ratón
            ReleaseCapture();

            // Envía un mensaje a la ventana especificada por "this.Handle"
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
