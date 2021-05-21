using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.IO;

namespace Folder_Lock_2._0
{
    static class folderLock
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

       public static void Lock(string lockPath)
        {
            if (lockPath == "")
            {
                MessageBox.Show("Please Enter A Valid Folder Path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                FileSecurity fileSystem = File.GetAccessControl(lockPath);
                fileSystem.AddAccessRule(new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny));
                File.SetAccessControl(lockPath, fileSystem);
                MessageBox.Show("Folder Successfully Locked!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static FileSystemRights file()
        {
            return FileSystemRights.FullControl;
        }
        public static void Unlock(string unlockPath)
        {
            if (unlockPath == "")
            {
                MessageBox.Show("Please Enter A Valid Folder Path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                file();
                FileSecurity fileSystem = File.GetAccessControl(unlockPath);
                fileSystem.RemoveAccessRule(new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Allow));
                File.SetAccessControl(unlockPath, fileSystem);
                MessageBox.Show("Folder Unlocked Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       public static void Hide(string hidePath)
        {
            if (hidePath == "")
            {
                MessageBox.Show("Please Provide A Valid Path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                File.SetAttributes(hidePath, FileAttributes.Hidden);
                MessageBox.Show("File Hidden Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void Unhide(string unhidePath)
        {
            if (unhidePath == "")
            {
                MessageBox.Show("Please Provide A Valid Path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                File.SetAttributes(unhidePath, FileAttributes.Normal);
                MessageBox.Show("File Retrieved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
