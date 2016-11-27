using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace The_Free_Audio_Converter
{


    class Encoder
    {
        private Process p = new Process();
        private int MP3_VBR = 5;
        private int M4A_VBR = 109;

        public void MP3_ENCODE(string wavfile, string metadata, string outPath, bool sourceWAV)
        {

            p.StartInfo.FileName = "encoders\\lame.exe";

            p.StartInfo.Arguments = "-V " + MP3_VBR + " " + metadata + " \"" + wavfile + "\" \"" + outPath + "\"";


            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            p.WaitForExit();
            if (!sourceWAV)
            {
                File.Delete(wavfile);
            }


        }

        public void M4A_ENCODE(string wavfile, string metadata, string outPath, bool sourceWAV)
        {
            p.StartInfo.FileName="encoders\\qaac\\qaac.exe";
            p.StartInfo.Arguments= "--tvbr "+M4A_VBR+ " "+metadata+ " " + "\""+wavfile+"\""  + " -o "+ "\""+outPath+"\"";
            //MessageBox.Show(p.StartInfo.Arguments);

            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            p.WaitForExit();
            if (!sourceWAV)
            {
                File.Delete(wavfile);
            }

        }

        public void MP3Setting(int s)
        {
            MP3_VBR = 9 - s;
        }

        public void M4ASetting(int s)
        {
            if (s < 0)
            {
                M4A_VBR = 0;
            }else if (s > 127)
            {
                M4A_VBR = 127;
            }else
            {
                M4A_VBR = s;
            }
        }


    }
}
