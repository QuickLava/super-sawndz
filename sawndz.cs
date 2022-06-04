using System;
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
		public static void insert(int groupID, int collID, int wavID, int frequency, bool loop)
		{
			runWithArgs("insert " + groupID + " " + collID + " "
				+ wavID + " " + frequency + " " + (loop ? "1": "0") + " \"" + brsar.RSAR_FileName + "\"");
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
			if( File.Exists( "sawnd.sawnd" ) )
				File.Delete( "sawnd.sawnd" );
			File.Copy( fileName, "sawnd.sawnd" );
			runWithArgs( "sawnd" + " \"" + brsar.RSAR_FileName + "\"" );
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
		public static void insertWav( string fileName, int groupID, int collID, int wavID )
		{
			if( !File.Exists( "VGAudioCli.exe" ) )
			{
				Console.WriteLine("Missing VGAudioCli.exe: unable to convert wav file");
				return;
			}
			//TextWriter writer = File.CreateText("sawnd.txt");
			//writer.Write( "BEGIN a\r\nFile sound.wav\r\nOUTPUT ADPCM\r\nEND" );
			//writer.Close();

			//In the case that someone wants to insert the temp file "sound.wav", no need to delete or copy.
			if( fileName.CompareTo( "sound.wav" ) != 0 )
			{
				File.Delete( "sound.wav" );
				File.Copy( fileName, "sound.wav" );
			}

			System.Audio.IAudioStream wav = System.Audio.WAV.FromFile( "sound.wav" );

			bool loop = wav.IsLooping;
			int frequency = wav.Frequency;
			wav.Dispose();

			p = new Process();
			try
			{
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.CreateNoWindow = true;
				p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				p.StartInfo.RedirectStandardOutput = true;
				p.StartInfo.FileName = "VGAudioCli.exe";
				p.StartInfo.Arguments = "-c -i:0 sound.wav -o sound.dsp";
				p.Start();
				while( ( !p.HasExited || !p.StandardOutput.EndOfStream ) )
				{
					char[] buffer = new char[ 10 ];
					int count = p.StandardOutput.Read( buffer, 0, 10 );
					Console.Write( buffer );
				}
				if( !p.HasExited )
					p.WaitForExit();
				insert( groupID, collID, wavID, frequency, loop );
			}
			catch( Exception e )
			{
				Console.WriteLine( e.ToString() );
				//If the process is still running kill it
				if( p != null && !p.HasExited )
				{
					p.Kill();
					p = null;
				}
			}
		}

	}

}