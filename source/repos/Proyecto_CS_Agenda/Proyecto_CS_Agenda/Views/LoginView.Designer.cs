namespace Proyecto_CS_Agenda.Views
{
    partial class LoginView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            txtbUser = new Guna.UI2.WinForms.Guna2TextBox();
            txtbPassw = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.CustomizableEdges = customizableEdges1;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(489, 288);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLogin.Size = new Size(143, 49);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Ingresar";
            btnLogin.Click += btnLogin_Click;
            // 
            // txtbUser
            // 
            txtbUser.CustomizableEdges = customizableEdges3;
            txtbUser.DefaultText = "";
            txtbUser.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtbUser.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtbUser.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtbUser.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtbUser.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtbUser.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtbUser.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtbUser.Location = new Point(410, 110);
            txtbUser.Name = "txtbUser";
            txtbUser.PasswordChar = '\0';
            txtbUser.PlaceholderText = "Usuario";
            txtbUser.SelectedText = "";
            txtbUser.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtbUser.Size = new Size(298, 39);
            txtbUser.TabIndex = 1;
            txtbUser.TextAlign = HorizontalAlignment.Center;
            // 
            // txtbPassw
            // 
            txtbPassw.CustomizableEdges = customizableEdges5;
            txtbPassw.DefaultText = "";
            txtbPassw.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtbPassw.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtbPassw.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtbPassw.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtbPassw.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtbPassw.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtbPassw.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtbPassw.Location = new Point(410, 194);
            txtbPassw.Name = "txtbPassw";
            txtbPassw.PasswordChar = '●';
            txtbPassw.PlaceholderText = "Contraseña";
            txtbPassw.SelectedText = "";
            txtbPassw.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtbPassw.Size = new Size(298, 39);
            txtbPassw.TabIndex = 2;
            txtbPassw.TextAlign = HorizontalAlignment.Center;
            txtbPassw.UseSystemPasswordChar = true;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = SystemColors.ControlDark;
            guna2Panel1.BorderColor = Color.Black;
            guna2Panel1.BorderThickness = 2;
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.Location = new Point(0, 1);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(229, 448);
            guna2Panel1.TabIndex = 3;
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(guna2Panel1);
            Controls.Add(txtbPassw);
            Controls.Add(txtbUser);
            Controls.Add(btnLogin);
            MinimizeBox = false;
            Name = "LoginView";
            Text = "Login";
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2TextBox txtbUser;
        private Guna.UI2.WinForms.Guna2TextBox txtbPassw;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}