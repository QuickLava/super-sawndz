using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BrawlSoundConverter
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				if (args.Length > 0)
				{
					if (args[0].ToLower() == "reset")
					{
						Properties.Settings.Default.Reset();
					}
				}
				Application.Run(new Form1());
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
