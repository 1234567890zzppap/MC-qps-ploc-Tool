using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApplication6
{
    public partial class langjsontool : Form
    {
        public string fileinput;
        public string fileoutput;
        public langjsontool()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Lang格式的语言文件|*.lang";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileinput = openFileDialog.FileName;

            }
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "保存Json格式的语言文件";
                saveDialog.Filter = "Json语言文件|*.json";
                saveDialog.DefaultExt = "json";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        fileoutput = saveDialog.FileName;
                        
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("错误: 无权限写入目标路径");
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("错误: 文件写入失败 - " + ex.Message);
                    }
                }

                langtojson();
            }

        }
        public void langtojson()
        {
            try
            {
                Console.WriteLine("Building...");
                // 使用 StreamReader 逐行读取文件
                using (StreamReader reader = new StreamReader(fileinput, Encoding.UTF8, detectEncodingFromByteOrderMarks: true))
                {
                    
                    using (StreamWriter writer = new StreamWriter(fileoutput, false, Encoding.UTF8))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            try
                            {

                                writer.WriteLine(LangJson(line));
                                Console.WriteLine(line);// 写入处理后的行
                            }
                            catch { writer.WriteLine(line); }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("错误:" + ex.Message);
            }
        }
        public string LangJson(string input)
        {
            input = input
            .Replace("=", "\""+":"+"\"");
            if (input != null || input != ""&&input.Length >=2)
            {
                input = "\"" + input + "\"";
            }
            return input;

        
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
