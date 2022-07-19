﻿using System;
using System.IO;
using System.Diagnostics;
using BrawlLib;
namespace BrawlSoundConverter
{
	/// <summary>
	/// interfaces with sawndz app
	/// </summary>
	public class Sawndz
	{
		public static Process p;
		static void runWithArgs( string args )
		{
			try
			{
				p = new Process();
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.CreateNoWindow = true;
				p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				p.StartInfo.RedirectStandardOutput = true;
				p.StartInfo.RedirectStandardError = true;
				p.EnableRaisingEvents = true;
				p.StartInfo.FileName = "lavaResawndz.exe";
				p.StartInfo.Arguments = args;
				p.Start();
				while( ( !p.HasExited || !p.StandardOutput.EndOfStream ) )
				{

					char[] buffer = new char[ 1 ];
					int count = p.StandardOutput.Read( buffer, 0, 1 );
					Console.Write( buffer );
				}
				if( !p.HasExited )
					p.WaitForExit();
				return;
			}
			catch( Exception e )
			{
				Console.WriteLine( e.ToString());
				//If the process is still running kill it
				if( p != null && !p.HasExited )
				{
					p.Kill();
					p = null;
				}
			}
		}
		public static void insert(int groupID, int collID, int wavID, int frequency, bool loop, string WAV_fileName)
		{
			runWithArgs("insert " + groupID + " " + collID + " "
				+ wavID + " " + frequency + " " + (loop ? "1": "0") + " \"" + brsar.RSAR_FileName + "\" \"" + WAV_fileName + "\"");
		}
		public static void createSawnd( int groupID , string fileName)
		{
			runWithArgs( "sawndcreate " + groupID +" \"" + brsar.RSAR_FileName + "\"" );
			if( File.Exists( fileName ) )
				File.Delete( fileName );
			File.Move( "sawnd.sawnd", fileName );
		}
		public static void insertSawnd(string fileName)
		{
			if (!File.Exists(fileName))
			{
				Console.WriteLine("Specified file doesn't exist!\n");
				return;
			}
			runWithArgs("sawnd \"" + brsar.RSAR_FileName + "\" \"" + fileName + "\"");
		}
		public static void multiInsertSawnd()
		{
			if (File.Exists("toImport.txt"))
			{
				runWithArgs("multisawndinsert \"toImport.txt\" \"" + brsar.RSAR_FileName + "\"");
				File.Delete("toImport.txt");
			}
		}
		public static void multiCreateSawnd(string exportDirectory)
		{
			if (File.Exists("toExport.txt"))
			{
				runWithArgs("multisawndcreate \"toExport.txt\" \"" + brsar.RSAR_FileName + "\" \"" + exportDirectory + "\"");
				File.Delete("toExport.txt");
			}
		}
		public static void createWAV(int groupID, int collID, int wavID, string fileName)
		{
			Console.Write("Creating WAV File (\"" + Path.GetFileName(fileName) + "\"... ");
			BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode targetNode = brsar.GetNode(groupID, collID, wavID) as BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode;
			if (targetNode != null)
			{
				targetNode.Export(fileName);
			}
			if (File.Exists(fileName))
			{
				Console.WriteLine("Success!");
			}
			else
			{
				Console.WriteLine("Failure! File failed to export!");
			}
		}
		public static void insertWav(string fileName, int groupID, int collID, int wavID)
		{
			Console.Write("Inserting WAV File (\"" + Path.GetFileName(fileName) + "\"... ");
			if (!File.Exists(fileName))
			{
				Console.WriteLine("Failure! Specified file doesn't exist!\n");
				return;
			}
			try
			{
				BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode targetNode = brsar.GetNode(groupID, collID, wavID) as BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode;
				targetNode.Replace(fileName);
				BrawlLib.SSBB.ResourceNodes.RSARNode currRsar = brsar.GetRSAR();
				currRsar.Export(currRsar._origPath);
				Console.WriteLine("Success!\n");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
		
		public static void emptySpace( int offset, int numberOfBytes )
		{
			runWithArgs("emptyspace " + offset + " " + numberOfBytes);
		}
		public static void removeSpace( int offset, int numberOfBytes )
		{
			runWithArgs( "removespace " + offset + " " + numberOfBytes );
		}
		public static void baseInsert( int groupID, int collID, int wavID, int frequency, bool loop, int baseWavID )
		{
			runWithArgs( "baseinsert " + groupID + " " + collID + " "
				+ wavID + " " + frequency + " " + ( loop ? "1" : "0" ) + " " + baseWavID);
		}
		public static void hex(int groupID, string fileName)
		{
			File.Copy( fileName, "hex.hex" );
			runWithArgs("hex " + groupID );
		}
		
	}
}