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
		public static string VGAudioExePath = "VGAudio/VGAudioCli.exe";
		public static string lavaResawndzExePath = "lavaResawndz.exe";
		public static string soundExchangePath = "SoX/sox.exe";
		static bool runWithArgs( string args )
		{
			bool result = false;
			if (!File.Exists(Path.GetFullPath(lavaResawndzExePath)))
			{
				Console.WriteLine("[ERROR] Unable to launch lavaResawndz!");
				Console.WriteLine("Couldn't locate executable (should be at \"" + Path.GetFullPath(lavaResawndzExePath) + "\")");
			}
			else
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
					p.StartInfo.FileName = Path.GetFullPath(lavaResawndzExePath);
					p.StartInfo.Arguments = args;
					p.Start();
					while ((!p.HasExited || !p.StandardOutput.EndOfStream))
					{

						char[] buffer = new char[1];
						int count = p.StandardOutput.Read(buffer, 0, 1);
						Console.Write(buffer);
					}
					if (!p.HasExited)
						p.WaitForExit();
					result = true;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
					//If the process is still running kill it
					if (p != null && !p.HasExited)
					{
						p.Kill();
						p = null;
					}
				}
			}
			return result;
		}
		static bool runVGAudio(string args)
		{
			bool result = false;
			if (!File.Exists(Path.GetFullPath(VGAudioExePath)))
			{
				Console.WriteLine("[ERROR] Unable to launch VGAudio!");
				Console.WriteLine("Couldn't find VGAudio executable (should be at \"" + Path.GetFullPath(VGAudioExePath) + "\") ");
			}
			else
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
					p.StartInfo.FileName = Path.GetFullPath(VGAudioExePath);
					p.StartInfo.Arguments = args;
					p.Start();
					while ((!p.HasExited || !p.StandardOutput.EndOfStream))
					{

						char[] buffer = new char[1];
						int count = p.StandardOutput.Read(buffer, 0, 1);
						Console.Write(buffer);
					}
					if (!p.HasExited)
						p.WaitForExit();
					result = true;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
					//If the process is still running kill it
					if (p != null && !p.HasExited)
					{
						p.Kill();
						p = null;
					}
				}
			}
			return result;
		}
		public static bool runSoX(string args)
		{
			bool result = false;
			if (!File.Exists(Path.GetFullPath(soundExchangePath)))
			{
				Console.WriteLine("[ERROR] Unable to launch Sound eXchange!");
				Console.WriteLine("Couldn't find SoX executable (should be at \"" + Path.GetFullPath(soundExchangePath) + "\") ");
			}
			else
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
					p.StartInfo.FileName = Path.GetFullPath(soundExchangePath);
					p.StartInfo.Arguments = args;
					p.Start();
					while ((!p.HasExited || !p.StandardOutput.EndOfStream))
					{

						char[] buffer = new char[1];
						int count = p.StandardOutput.Read(buffer, 0, 1);
						Console.Write(buffer);
					}
					if (!p.HasExited)
						p.WaitForExit();
					result = true;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
					//If the process is still running kill it
					if (p != null && !p.HasExited)
					{
						p.Kill();
						p = null;
					}
				}
			}
			return result;
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
			brsar.CloseRSAR();
			if (!File.Exists(fileName))
			{
				Console.WriteLine("Specified file doesn't exist!\n");
				return;
			}
			runWithArgs("sawnd \"" + brsar.RSAR_FileName + "\" \"" + fileName + "\"");
		}

		public static int findFirstRSARHexTag(byte[] arrIn, int startingFrom)
		{
			int loc = int.MaxValue;

			if (startingFrom <= (arrIn.Length - 4))
			{
				bool foundTag = false;
				int index = startingFrom;
				while (!foundTag && index <= (arrIn.Length - 4))
				{
					if (arrIn[index] == 0x52)
					{
						string possibleTag = "";
						for (int i = index; i < (index + 4); i++)
						{
							possibleTag += (char)arrIn[i];
						}
						switch (possibleTag)
						{
							case "RWSD":
							case "RBNK":
							case "RSEQ":
								{
									foundTag = true;
									break;
								}
							default:
								break;
						}
						if (foundTag)
						{
							loc = index;
						}
					}
					index++;
				}
			}

			return loc;
		}
		public static List<int> getSawndFileInfo(string fileName, bool getFileIDs = false)
		{
			List<int> info = new List<int>();

			if (File.Exists(fileName))
			{
				byte[] sawndBytes = File.ReadAllBytes(fileName);
				info.Add(0);
				if (sawndBytes.Length >= 9 && sawndBytes[0] == 2)
				{
					// Store group ID
					info[0] |= ((int)sawndBytes[1]) << 0x18;
					info[0] |= ((int)sawndBytes[2]) << 0x10;
					info[0] |= ((int)sawndBytes[3]) << 0x08;
					info[0] |= ((int)sawndBytes[4]) << 0x00;
				}

				if (getFileIDs)
				{
					int firstFile = findFirstRSARHexTag(sawndBytes, 0x09);
					if (firstFile != int.MaxValue)
					{
						int lengthOfFileSummarySection = firstFile - 0x09;
						if ((lengthOfFileSummarySection % 0x0C) == 0)
						{
							int numFileTriples = lengthOfFileSummarySection / 0x0C;
							int addr = 0x09;
							for (int i = 0; i < numFileTriples; i++)
							{
								int currFileID = 0;
								currFileID |= ((int)sawndBytes[addr]) << 0x18;
								currFileID |= ((int)sawndBytes[addr + 1]) << 0x10;
								currFileID |= ((int)sawndBytes[addr + 2]) << 0x08;
								currFileID |= ((int)sawndBytes[addr + 3]) << 0x00;
								addr += 0x0C;
								info.Add(currFileID);
							}
						}
						else
						{
							Console.WriteLine("Couldn't find File IDs for Sawnd ID");
						}
					}
				}
			}

			return info;
		}

		public static void multiInsertSawnd()
		{
			if (File.Exists("toImport.txt"))
			{
				brsar.CloseRSAR();
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
		public static bool hasSoundExtension(string filePath)
		{
			bool result = false;

			if (File.Exists(filePath))
			{
				string extension = Path.GetExtension(filePath);
				result = extension == ".wav";
				result |= extension == ".mp3";
				result |= extension == ".ogg";
				result |= extension == ".flac";
			}

			return result;
		}
		public static bool convertAudioToTempWav(string audioPath)
		{
			bool success = false;

			if (hasSoundExtension(audioPath))
			{
				if (Path.GetExtension(audioPath) != (".wav"))
				{
					Console.WriteLine("Converting file:");
					Console.WriteLine("\t\"" + audioPath + "\"");
					Console.Write("to WAV... ");
					Sawndz.runSoX("\"" + audioPath + "\" -b 16 \"" + Path.GetFullPath(Properties.Resources.tempAudioTypeConvPath) + "\"");
					if (File.Exists(Properties.Resources.tempAudioTypeConvPath))
					{
						success = true;
						Console.WriteLine("Success! Converted file created at:");
						Console.WriteLine("\t\"" + Properties.Resources.tempAudioTypeConvPath + "\"");
						Console.WriteLine("File will be deleted when the program closes.");
					}
					else
					{
						Console.WriteLine("Failure, unable to convert file!");
					}
				}
			}

			return success;
		}
		public static void doInsertWithRespectToChannelCount(string filePath, BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode targetNode, bool headless)
		{
			if (targetNode != null && File.Exists(filePath))
			{
				BrawlLib.Internal.Audio.IAudioStream incomingAudio = BrawlLib.Internal.Audio.WAV.FromFile(filePath);

				bool doMixToMono = Properties.Settings.Default.ConvertToMono == 2;
				doMixToMono |= (Properties.Settings.Default.ConvertToMono == 1) && (targetNode.Channels < 2);
				doMixToMono &= incomingAudio.Channels > 1;

				bool doResample = Properties.Settings.Default.MatchSampleRate == 2;
				doResample |= (Properties.Settings.Default.MatchSampleRate == 1) && (incomingAudio.Frequency > targetNode.SampleRate);
				int targetSampleRate = int.MaxValue;
				if (doResample)
				{
					targetSampleRate = targetNode.SampleRate;
				}
				else
				{
					targetSampleRate = incomingAudio.Frequency;
				}
				if (Properties.Settings.Default.MaximumSampleRate > 0 && targetSampleRate > Properties.Settings.Default.MaximumSampleRate)
				{
					targetSampleRate = Math.Min(targetSampleRate, Properties.Settings.Default.MaximumSampleRate);
					doResample = true;
				}

				bool doConvert = doMixToMono || doResample;
				bool convertFailed = false;
				if (doConvert)
				{
					Console.WriteLine("");
					Console.WriteLine("Processing audio to:");
					if (doMixToMono)
					{
						Console.WriteLine("\t- Mix audio down to mono");
					}
					if (doResample)
					{
						Console.WriteLine("\t- Resample audio from " + incomingAudio.Frequency.ToString() + "hz to " + targetSampleRate.ToString() + "hz");
					}

					string arguments = " ";
					if (doMixToMono)
					{
						arguments += "remix - ";
					}
					if (doResample)
					{
						arguments += "rate " + targetSampleRate.ToString();
					}
					runSoX("-V3 \"" + filePath + "\" \"" + Properties.Resources.tempAudioResamplePath + "\"" + arguments);
					if (File.Exists(Properties.Resources.tempAudioResamplePath))
					{
						filePath = Properties.Resources.tempAudioResamplePath;
						Console.WriteLine("Processed audio!");
					}
					else
					{
						convertFailed = true;
						Console.WriteLine("Unable to process audio! Aborting import!	");
					}
				}
				if (!convertFailed)
				{
					if (headless)
					{
						targetNode.HeadlessReplace(filePath);
					}
					else
					{
						targetNode.Replace(filePath);
					}
					if (doConvert)
					{
						File.Delete(filePath);
					}
				}
			}
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

				WAVPreprocessingForm processingForm = new WAVPreprocessingForm(groupID, fileName);
				if (processingForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					fileName = Properties.Resources.tempAudioResamplePath;
					doInsertWithRespectToChannelCount(fileName, targetNode, true);
					BrawlLib.SSBB.ResourceNodes.RSARNode currRsar = brsar.GetRSAR();
					if (targetNode.IsDirty)
					{
						Console.WriteLine("Success!\n");
						currRsar.Export(currRsar._origPath);
					}
					else
					{
						Console.WriteLine("Overwrite Failed!\n");
					}
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
				bool validMapNodeReached = false;
				foreach (System.Xml.XmlNode mapChild in mapDoc.ChildNodes)
				{
					if (mapChild.Name == "superSawndzWAVEMap" && mapChild.Attributes != null)
					{
						validMapNodeReached = true;
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
									if (hasSoundExtension(filename) && Path.GetFileName(filename) != ".wav")
									{
										if (convertAudioToTempWav(mapFolder + filename))
										{
											doInsertWithRespectToChannelCount(Properties.Resources.tempAudioTypeConvPath, targetNode, true);
										}
									}
									else
									{
										doInsertWithRespectToChannelCount(mapFolder + filename, targetNode, true);
									}

									if (targetNode.IsDirty)
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
				if (validMapNodeReached)
				{
					currRsar = brsar.GetRSAR();
					brsar.ReloadRSAR();
				}
				else
				{
					Console.WriteLine("Unable to find any Map nodes in this file (\"" + mapFileName + "\"), it likely isn't a WAVE Map. No WAVs were imported.");
				}

				if (File.Exists(Properties.Resources.tempAudioTypeConvPath))
				{
					File.Delete(Properties.Resources.tempAudioTypeConvPath);
				}
			}
			else
			{
				Console.WriteLine("Unable to insert WAVs, \"" + mapFileName + "\" doesn't exist!");
			}
		}
		public static bool reloopWAV(int groupID, int collID, int wavID)
		{
			bool result = false;

			Console.Write("Re-looping WAV... ");
			BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode targetNode = brsar.GetNode(groupID, collID, wavID) as BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode;
			if (targetNode != null)
			{
				targetNode.Export("__relooptemp__.wav");
				if (File.Exists("__relooptemp__.wav"))
				{
					targetNode.Replace("__relooptemp__.wav");
					if (brsar.GetRSAR().IsDirty)
					{
						Console.WriteLine("Success!\n");
						result = true;
					}
					else
					{
						Console.WriteLine("Operation Cancelled!\n");
					}
					File.Delete("__relooptemp__.wav");
				}
				else
				{
					Console.WriteLine("Failed, unable to export WAV!");
				}
			}

			return result;
		}
		public static bool createBRSARSubfile(int groupID, int fileID, string fileName)
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
		public static void replaceBRSARSubfile(string fileName, int groupID, int fileID)
		{
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
				BrawlLib.SSBB.ResourceNodes.ResourceNode dataFolder = targetFile.FindChild("data", false);

				List<MappingItem> collectedEntries = new List<MappingItem>();

				if (audioFolder != null && audioFolder.Children.Count > 0)
				{
					for (int i = 0; i < audioFolder.Children.Count; i++)
					{
						string elementName = "Audio_" + groupID.ToString("D3") + "_" + collID.ToString("D3") + "_" + i.ToString("D3");
						MappingItem soundMap = new MappingItem(elementName, groupID, collID, i, -1, false);
						collectedEntries.Add(soundMap);
					}
					if (dataFolder != null && dataFolder.Children.Count > 0 && dataFolder.NodeType == "BrawlLib.SSBB.ResourceNodes.RWSDDataGroupNode")
					{
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
					}
					System.Xml.XmlWriterSettings waveMapSettings = new System.Xml.XmlWriterSettings();
					waveMapSettings.Indent = true;
					waveMapSettings.IndentChars = "\t";
					System.Xml.XmlWriter waveMap = System.Xml.XmlWriter.Create(fileName, waveMapSettings);
					if (includeExtraInfo)
					{
						string groupName;
						if (Properties.Settings.Default.EnableFullLengthNames)
						{
							groupName = targetGroup.TreePath.Replace('/', '_');
						}
						else
						{
							groupName = targetGroup.Name;
						}
						waveMap.WriteComment("For Group #" + groupID.ToString("D3") + " (\"" + groupName + "\"):");
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
							else if (waveEntry.Nodes.Count == 1)
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