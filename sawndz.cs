using System;
using System.IO;
using System.Collections.Generic;
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
		public static bool createWAV(int groupID, int collID, int wavID, string fileName)
		{
			bool result = false;
			Console.Write("Creating WAV File (\"" + Path.GetFileName(fileName) + "\")... ");
			BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode targetNode = brsar.GetNode(groupID, collID, wavID) as BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode;
			if (targetNode != null)
			{
				targetNode.Export(fileName);
			}
			if (File.Exists(fileName))
			{
				Console.WriteLine("Success!");
				result = true;
			}
			else
			{
				Console.WriteLine("Failure! File failed to export!");
			}
			return result;
		}
		public static void insertWav(string fileName, int groupID, int collID, int wavID)
		{
			Console.Write("Inserting WAV File (\"" + Path.GetFileName(fileName) + "\")... ");
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
				if (currRsar.IsDirty)
				{
					Console.WriteLine("Success!\n");
					currRsar.Export(currRsar._origPath);
				}
				else
				{
					Console.WriteLine("Operation Cancelled!\n");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
		public static void multiInsertWAV(string mapFileName)
		{
			if (File.Exists(mapFileName))
			{
				System.Xml.XmlDocument mapDoc = new System.Xml.XmlDocument();
				string mapFolder = Path.GetDirectoryName(mapFileName) + "\\";
				mapDoc.Load(mapFileName);
				BrawlLib.SSBB.ResourceNodes.RSARNode currRsar = brsar.GetRSAR();
				foreach (System.Xml.XmlNode mapChild in mapDoc.ChildNodes)
				{
					if (mapChild.Name == "superSawndzWAVEMap" && mapChild.Attributes != null)
					{
						string version = null;
						int groupID = -1;
						int collID = -1;
						foreach (System.Xml.XmlAttribute mapChildAttr in mapChild.Attributes)
						{
							if (mapChildAttr.Name == "version")
								version = mapChildAttr.Value;
							else if (mapChildAttr.Name == "targetGroup")
								int.TryParse(mapChildAttr.Value, out groupID);
							else if (mapChildAttr.Name == "targetCollection")
								int.TryParse(mapChildAttr.Value, out collID);
						}
						foreach (System.Xml.XmlNode wave in mapChild.ChildNodes)
						{
							string filename = null;
							int wavID = -1;
							foreach (System.Xml.XmlNode waveChild in wave.ChildNodes)
							{
								if (waveChild.Attributes != null)
								{
									string value = null;
									foreach (System.Xml.XmlAttribute waveChildAttr in waveChild.Attributes)
									{
										if (waveChildAttr.Name == "val")
											value = waveChildAttr.Value;
									}
									if (waveChild.Name == "filename")
										filename = value;
									else if (waveChild.Name == "wavID")
										int.TryParse(value, out wavID);
								}
							}
							if (filename != null)
							{
								Console.Write("Inserting WAV File (\"" + Path.GetFileName(mapFolder + filename) + "\")... ");
								if (File.Exists(mapFolder + filename))
								{
									BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode targetNode = brsar.GetNode(groupID, collID, wavID) as BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode;
									targetNode.HeadlessReplace(mapFolder + filename);
									if (currRsar.IsDirty)
									{
										Console.WriteLine("Success!");
									}
									else
									{
										Console.WriteLine("Operation Cancelled!");
									}
								}
								else
								{
									Console.WriteLine("Failure! File doesn't exist!");
								}
							}
							else
							{
								Console.WriteLine("Unable to import \"" + filename + "\", no filename was specified!");
							}
						}
					}
				}
				currRsar = brsar.GetRSAR();
				brsar.ReloadRSAR();
			}
			else
			{
				Console.WriteLine("Unable to insert WAVs, \"" + mapFileName + "\" doesn't exist!");
			}
		}
		public static bool createBRWSD(int groupID, int fileID, string fileName)
		{
			bool result = false;

			BrawlLib.SSBB.ResourceNodes.RSARFileNode currColl = brsar.GetNode(groupID, fileID) as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
			if (currColl != null)
			{
				currColl.Export(fileName);
				if (File.Exists(fileName))
				{
					Console.WriteLine("Successfully exported \"" + fileName + "\"!");
					result = true;
				}
				else
				{
					Console.WriteLine("Failed to export!");
				}
			}
			else
			{
				Console.WriteLine("Failed! Specified Collection doesn't exist!");
			}

			return result;
		}
		public static void insertBRWSD(string fileName, int groupID, int fileID)
		{
			Console.Write("Inserting BRWSD File (\"" + Path.GetFileName(fileName) + "\")... ");
			if (!File.Exists(fileName))
			{
				Console.WriteLine("Failure! Specified file doesn't exist!\n");
				return;
			}
			try
			{
				BrawlLib.SSBB.ResourceNodes.RSARFileNode targetNode = brsar.GetNode(groupID, fileID) as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
				targetNode.Replace(fileName);
				brsar.ReloadRSAR();
				Console.WriteLine("Success!\n");

				//if (brsar.GetRSAR().IsDirty)
				//{
				//	brsar.ReloadRSAR();
				//}
				//else
				//{
				//	Console.WriteLine("Failed to import!\n");
				//}
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

		public static string getDefaultWAVEName(int groupID, int collID, int wavID)
		{
			return "Audio[" + groupID.ToString("D3") + "_" + collID.ToString("D3") + "_" + wavID.ToString("D3") + "].wav";
		}
		public static bool createWAVEMap(string fileName, int groupID, int collID, List<int> targetWAVIDs = null, bool includeExtraInfo = false)
		{
			bool result = false;

			BrawlLib.SSBB.ResourceNodes.RSARGroupNode targetGroup = brsar.GetNode(groupID) as BrawlLib.SSBB.ResourceNodes.RSARGroupNode;
			BrawlLib.SSBB.ResourceNodes.RSARFileNode targetFile = brsar.GetNode(groupID, collID) as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
			if (targetFile != null)
			{
				bool allowAllWaves = false;
				if (targetWAVIDs == null)
				{
					allowAllWaves = true;
					targetWAVIDs = new List<int>();
				}
				BrawlLib.SSBB.ResourceNodes.ResourceNode audioFolder = (BrawlLib.SSBB.ResourceNodes.ResourceNode)targetFile.FindChild("audio", false);
				BrawlLib.SSBB.ResourceNodes.RWSDDataGroupNode dataFolder = (BrawlLib.SSBB.ResourceNodes.RWSDDataGroupNode)targetFile.FindChild("data", false);

				List<MappingItem> collectedEntries = new List<MappingItem>();

				if (audioFolder != null && audioFolder.Children.Count > 0 && dataFolder != null && dataFolder.Children.Count > 0)
				{
					for (int i = 0; i < audioFolder.Children.Count; i++)
					{
						string elementName = "Audio_" + groupID.ToString("D3") + "_" + collID.ToString("D3") + "_" + i.ToString("D3");
						MappingItem soundMap = new MappingItem(elementName, groupID, collID, i, -1, false);
						collectedEntries.Add(soundMap);
					}
					for (int i = 0; i < dataFolder.Children.Count; i++)
					{
						if (!(dataFolder.Children[i] is BrawlLib.SSBB.ResourceNodes.RWSDDataNode))
							continue;
						BrawlLib.SSBB.ResourceNodes.RWSDDataNode data = (BrawlLib.SSBB.ResourceNodes.RWSDDataNode)dataFolder.Children[i];
						int waveIndex = data._part3._waveIndex;
						if (collectedEntries.Count <= waveIndex)
							continue;
						
						MappingItem soundMap = new MappingItem(data.Name, groupID, collID, waveIndex, -1, false);
						collectedEntries[waveIndex].Nodes.Add(soundMap);
					}
					System.Xml.XmlWriterSettings waveMapSettings = new System.Xml.XmlWriterSettings();
					waveMapSettings.Indent = true;
					waveMapSettings.IndentChars = "\t";
					System.Xml.XmlWriter waveMap = System.Xml.XmlWriter.Create(fileName, waveMapSettings);
					if (includeExtraInfo)
					{
						waveMap.WriteComment("For Group #" + groupID.ToString("D3") + " (\"" + targetGroup.Name + "\"):");
					}
					waveMap.WriteStartElement("superSawndzWAVEMap");
					waveMap.WriteAttributeString("version", Properties.Resources.Version);
					waveMap.WriteAttributeString("targetGroup", groupID.ToString("D3"));
					waveMap.WriteAttributeString("targetCollection", collID.ToString("D3"));
					foreach (MappingItem waveEntry in collectedEntries)
					{
						if (!allowAllWaves && !targetWAVIDs.Contains(waveEntry.wavID))
							continue;
						string elementName = "Audio_" + waveEntry.groupID.ToString("D3") + "_" + waveEntry.collectionID.ToString("D3") + "_" + waveEntry.wavID.ToString("D3");
						waveMap.WriteStartElement("wave");
						waveMap.WriteAttributeString("name", elementName);
						waveMap.WriteStartElement("filename");
						waveMap.WriteAttributeString("val", getDefaultWAVEName(waveEntry.groupID, waveEntry.collectionID, waveEntry.wavID));
						waveMap.WriteEndElement();
						waveMap.WriteStartElement("wavID");
						waveMap.WriteAttributeString("val", waveEntry.wavID.ToString("D3"));
						waveMap.WriteEndElement();
						if (includeExtraInfo)
						{
							if (waveEntry.Nodes.Count > 1)
							{
								waveMap.WriteComment("Used by:");
								foreach (MappingItem dataNode in waveEntry.Nodes)
								{
									waveMap.WriteComment("\"" + dataNode.name + "\"");
								}
							}
							else
							{
								MappingItem dataNode = (waveEntry.Nodes[0] as MappingItem);
								waveMap.WriteComment("Used by: \"" + dataNode.name + "\"");
							}
						}
						waveMap.WriteEndElement();
					}
					waveMap.WriteEndElement();
					waveMap.Close();
					result = File.Exists(fileName);
				}
			}
			return result;
		}
		public static bool createSAWNDToImportList(string listFileName, string[] sawndFileNames)
		{
			bool result = false;

			StreamWriter importList = File.CreateText(listFileName);
			foreach (string str in sawndFileNames)
			{
				importList.WriteLine(str);
			}
			importList.Close();
			if (File.Exists(listFileName))
			{
				result = true;
			}

			return result;
		}
	}
}