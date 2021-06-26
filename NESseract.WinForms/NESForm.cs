using NESseract.Core;
using System.Diagnostics;
using System.Windows.Forms;

namespace NESseract.WinForms
{
   public partial class NESForm : Form
   {
      private readonly NESSystem nesSystem;

      public NESForm()
      {
         InitializeComponent();

         nesSystem = new NESSystem();
      }
   }
}
