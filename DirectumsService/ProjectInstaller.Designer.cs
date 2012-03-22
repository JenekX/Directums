namespace Directums.Service
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.process = new System.ServiceProcess.ServiceProcessInstaller();
            this.service = new System.ServiceProcess.ServiceInstaller();
            // 
            // process
            // 
            this.process.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.process.Password = null;
            this.process.Username = null;
            // 
            // service
            // 
            this.service.Description = "Directums service";
            this.service.ServiceName = "DirectumsService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.process,
            this.service});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller process;
        private System.ServiceProcess.ServiceInstaller service;
    }
}