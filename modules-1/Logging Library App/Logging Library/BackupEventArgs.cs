using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging_Library
{
    public delegate void BackupEventHandler (object sender, BackupEventArgs e);

    public class BackupEventArgs : EventArgs
    {
        public DateTime Backuptime { get; set; }
    }
}
