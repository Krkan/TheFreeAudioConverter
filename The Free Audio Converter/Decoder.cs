using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;


namespace The_Free_Audio_Converter
{
    class Decoder
    {
        private Process p = new Process();

        public string DecodeFLAC_WAV(string fileName)
        {




            p.StartInfo.FileName = "encoders\\flac.exe";
            p.StartInfo.Arguments = "-d " + '"' + fileName + '"';
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            p.WaitForExit();

            string wavfile = fileName.Replace(".flac", ".wav");
            return wavfile;
        }

        public string getFLACMetadata(string fileName, string datatype)
        {
            p.StartInfo.FileName = "encoders\\metaflac.exe";
            p.StartInfo.Arguments = "--show-tag=ARTIST --show-tag=ALBUM --show-tag=DATE --show-tag=TITLE --show-tag=TRACKNUMBER " + '"' + fileName + '"';
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;

            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();

            string tag = "";
            string[] sarr = { "", "", "", "", "" };
      
            while (!p.StandardOutput.EndOfStream)
            {
                tag = p.StandardOutput.ReadLine();
                string temp = tag.Substring(tag.IndexOf("=") + 1, (tag.Length) - (tag.IndexOf("=") + 1)).Trim();

                if (tag.Contains("ARTIST"))
                {
                    sarr[0] = temp;

                }
                else if (tag.Contains("ALBUM"))
                {
                    sarr[1] = temp;
                }
                else if (tag.Contains("DATE"))
                {
                    sarr[2] = temp;
                }
                else if (tag.Contains("TITLE"))
                {
                    sarr[3] = temp;
                }
                else if (tag.Contains("TRACKNUMBER"))
                {
                    sarr[4] = temp;
                }



                //sarr[i] = tag.Substring(tag.IndexOf("=") + 1, (tag.Length) - (tag.IndexOf("=") + 1)).Trim();

                // i++;

            }
            p.WaitForExit();
            string metadata = "";
            if (datatype.Equals("mp3"))
            {
                metadata = "--tt \"" + sarr[3] + "\" --ta \"" + sarr[0] + "\" --tl \"" + sarr[1] + "\" --ty \"" + sarr[2] + "\" --tn \"" + sarr[4] + "\"";
            }else if (datatype.Equals("m4a"))
                {
                metadata = "--title \"" + sarr[3] + "\""+" --artist \"" + sarr[0] + "\""+ " --album \"" + sarr[1] + "\"" + " --date \"" + sarr[2] + "\""+ " --track \"" + sarr[4]+ "\"";

            }
            return metadata.Trim();
        }



    }
}
