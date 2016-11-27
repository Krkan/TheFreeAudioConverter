using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace The_Free_Audio_Converter
{
    public partial class Form1 : Form
    {
        //global variables
        private FileController Files = new FileController();
        private Decoder Decode = new Decoder();
        private Encoder Encode = new Encoder();
        private string wavfile = "";
        string metadata = "";
        private mp3settings mp3s = new mp3settings();
        private mp3settings m4as = new mp3settings(0,127);



        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Remove(checkedListBox1.SelectedItem);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            foreach (string s in openFileDialog1.FileNames)
            {
                //Files.insert(new FileContainer(s));

                if (!checkedListBox1.Items.Contains(s))
                {
                    checkedListBox1.Items.Add(s);
                }




            }


            // MessageBox.Show(Files.getList().ElementAt(2).getFileLocation());
            //checkedListBox1.Items.Add(Files.getList().ElementAt(2).getFileLocation());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ;


            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {

                progressBar1.Maximum = checkedListBox1.CheckedItems.Count * 2;

                if (radioButton1.Checked)
                {


     


                    foreach (string s in checkedListBox1.CheckedItems)
                    {
                        if (s.Contains(".flac"))
                        {
                            wavfile = Decode.DecodeFLAC_WAV(s);
                            metadata = Decode.getFLACMetadata(s, "mp3");

                            progressBar1.Value++;
                            Encode.MP3Setting(mp3s.getTrackBarValue());
                            Encode.MP3_ENCODE(wavfile, metadata, formatOutFileName(wavfile, "mp3"), false);
                            progressBar1.Value++;
                        }
                        else if (s.Contains(".wav"))
                        {
                            Encode.MP3Setting(mp3s.getTrackBarValue());
                            Encode.MP3_ENCODE(s, "", formatOutFileName(s, "mp3"), true);
                            progressBar1.Value++;
                        }
                    }
                   




                }else if (radioButton2.Checked)
                {
                    foreach(string s in checkedListBox1.CheckedItems)
                    {
                        if (s.Contains(".flac"))
                        { 
                        wavfile = Decode.DecodeFLAC_WAV(s);
                        metadata = Decode.getFLACMetadata(s, "m4a");
                            progressBar1.Value++;
                            Encode.M4ASetting(m4as.getTrackBarValue());
                            Encode.M4A_ENCODE(wavfile, metadata, formatOutFileName(wavfile, "m4a"), false);
                            progressBar1.Value++;


                        }
                    }
                }
                MessageBox.Show("Done!");
                progressBar1.Value = 0;
            }

        }

        private string formatOutFileName(string wavfile, string filetype)
        {
            string outpath = folderBrowserDialog2.SelectedPath + "\\" + Path.GetFileName(wavfile);
            if (filetype.Equals("mp3"))
            {
                outpath = outpath.Replace(".wav", ".mp3");
            }
            else if (filetype.Equals("m4a"))
            {
                outpath = outpath.Replace(".wav", ".m4a");
            }
           
            return outpath;
        }

        private void mP3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mp3s.ShowDialog();
         
        }

        private void m4AAACToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m4as.ShowDialog();
            
        }
    }
}
