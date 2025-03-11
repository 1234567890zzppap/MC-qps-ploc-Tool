using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
namespace WindowsFormsApplication6
{
    public partial class langjsontool : Form
    {
        public string fileinput;
        public string fileoutput;
        public int mode = 0;
        public langjsontool()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mode = 0;
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
                        writer.WriteLine("{");
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            try
                            {
                                if (line != "\u000A")
                                {
                                writer.WriteLine(LangJson(line));}
                                
                            }
                            catch
                            {
                                if (line != "\u000A")
                                {
                                    writer.WriteLine(LangJson(line));
                                }
                            }
                        }
                        writer.WriteLine("}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("错误:" + ex.Message);
            }
            LangJsonPart2();
            File.Delete(fileoutput);
            File.Move(fileoutput+"_tmp",fileoutput);
        }
        public string LangJson(string input)
        {
            if (mode == 0)
            {
                string tmp1;
                bool check = false;
                tmp1 = input.Trim();
                tmp1 = tmp1
                .Replace("=", "\"" + ":" + "\"");
                if (input == "\u0020" || input == "\u0009" || input == "\u000A" || input == "\u000D" || input == "\u000B" || input == "\u000C" || input == "\u00A0")
                { check = true;
                input = "";
                }
                if (input != null && !check)
                {
                    tmp1 = "\"" + tmp1 + "\",";
                    return tmp1;
                }
                else
                { return input; }
            }
            if (mode == 1)
            {
                string tmp1 = input.Replace("\"\",","");
                

                    return tmp1;
               
            }

            return input;
        }
        public void LangJsonPart2()
        {   int c,b = 0;

        c = File.ReadAllLines(fileoutput).Count();
            mode = 1;
            try
            {
                Console.WriteLine("Building Part2...");
                // 使用 StreamReader 逐行读取文件
                using (StreamReader reader = new StreamReader(fileoutput, Encoding.UTF8, detectEncodingFromByteOrderMarks: true))
                {

                    using (StreamWriter writer = new StreamWriter(fileoutput+"_tmp", false, Encoding.UTF8))
                    {
                        
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            b++;
                            try
                            {
                                if (c - 2 == b)
                                {
                                    string a = LangJson(line).Replace("\",", "\"");

                                    writer.WriteLine(a);
                                }
                                else
                                { writer.WriteLine(LangJson(line)); }

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
        public void jsontolang ()
    {try
            {
                Console.WriteLine("Building...");
                // 使用 StreamReader 逐行读取文件
                using (StreamReader reader = new StreamReader(fileinput, Encoding.UTF8, detectEncodingFromByteOrderMarks: true))
                {
                    
                    using (StreamWriter writer = new StreamWriter(fileoutput, false, Encoding.UTF8))
                    {
                        writer.WriteLine("{");
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            try
                            { writer.WriteLine(JsonLang(line));
                            }
                            catch
                            {writer.WriteLine(JsonLang(line)); 
                            }
                        }
                        writer.WriteLine("}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("错误:" + ex.Message);
            }
            
        }
        public string JsonLang(string input)
        {
            string b = input
               .Replace("\": \"", "=")
               .Replace("\":\"", "=")
               .Replace("\",", "")
               .Replace("{", " ")
               .Replace("}", " ")
               .Replace("  \"", "");
              
            
            b = b.TrimEnd('"');
            b = b.TrimStart('"');
            b = b.TrimStart('{');
            b = b.TrimStart('}');
            string pattern = @"[{}]";
            b = Regex.Replace(b, pattern, "");
            return b;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json格式的语言文件|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileinput = openFileDialog.FileName;

            }
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "保存Lang格式的语言文件";
                saveDialog.Filter = "lang语言文件|*.lang";
                saveDialog.DefaultExt = "lang";
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

                jsontolang();
            }
        }
    }
}
