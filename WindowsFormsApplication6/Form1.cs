using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;
namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {   public string filepath;
        public string folderpath;
        public int space = 0;
        public string val;
        public string path;
        public string lang = "qps_ploc";
        public string savepath;
        public string savefolderpath;
        public int savemode = 0;
        public Form1()
        {
            
            
            InitializeComponent();
        }
        public string Out(string input)
        {
            //Console.WriteLine(input);

            Regex regex = new Regex(@":\s*""((?:\\""|[^""])*)""");
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                if (match.Success )
                {
                    string value = match.Groups[1].Value;
                   // Console.WriteLine(value);
                    string replaced = value
           .Replace("\\n", "占")
           .Replace("§2", "吗")
           .Replace("§3", "没")// 替换 \n
           .Replace("§a", "篇") // 替换 \n
           .Replace("§b", "长") // 替换 \n
           .Replace("§c", "涨") // 替换 \n
           .Replace("§d", "张") // 替换 \n
           .Replace("§e", "帐") // 替换 \n
           .Replace("§f", "章") // 替换 \n
           .Replace("§k", "掌") // 替换 \n
           .Replace("§l", "在") // 替换 \n
           .Replace("§m", "中") // 替换 \n
           .Replace("§n", "这") // 替换 \n
           .Replace("§o", "啊")
           .Replace("§r", "阿") // 替换 \n
           .Replace("§A", "吖") // 替换 \n
           .Replace("§B", "锕") // 替换 \n
           .Replace("§C", "腌") // 替换 \n
           .Replace("§D", "呵") // 替换 \n
           .Replace("§E", "了") // 替换 \n
           .Replace("§F", "来") // 替换 \n
           .Replace("§K", "零") // 替换 \n
           .Replace("§L", "啦") // 替换 \n
           .Replace("§M", "怕") // 替换 \n
           .Replace("§N", "人") // 替换 \n
           .Replace("§O", "我")
           .Replace("§R", "为") // 替换 \n
           .Replace("%i", "五") // 替换 \n
           .Replace("%f", "去") // 替换 \n
           .Replace("%d", "哎") // 替换 \n
           .Replace("%s", "站"); // 替换 %s

                    // Console.WriteLine(value);
                    string tmp1 = LineCover(replaced);

                    string tmp2 = input
                         .Replace("\"" + match.Groups[1].Value + "\"", "\"" + tmp1 + "\"");
                    replaced = tmp2
         .Replace("占", "\\n")
.Replace("吗", "§2")
.Replace("没", "§3") // 替换 \n
.Replace("篇", "§a") // 替换 \n
.Replace("长", "§b") // 替换 \n
.Replace("涨", "§c") // 替换 \n
.Replace("张", "§d") // 替换 \n
.Replace("帐", "§e") // 替换 \n
.Replace("章", "§f") // 替换 \n
.Replace("掌", "§k") // 替换 \n
.Replace("在", "§l") // 替换 \n
.Replace("中", "§m") // 替换 \n
.Replace("这", "§n") // 替换 \n
.Replace("啊", "§o")
.Replace("阿", "§r") // 替换 \n
.Replace("吖", "§A") // 替换 \n
.Replace("锕", "§B") // 替换 \n
.Replace("腌", "§C") // 替换 \n
.Replace("呵", "§D") // 替换 \n
.Replace("了", "§E") // 替换 \n
.Replace("来", "§F") // 替换 \n
.Replace("零", "§K") // 替换 \n
.Replace("啦", "§L") // 替换 \n
.Replace("怕", "§M") // 替换 \n
.Replace("人", "§N") // 替换 \n
.Replace("我", "§O")
.Replace("为", "§R") // 替换 \n
.Replace("五", "%i") // 替换 \n
.Replace("去", "%f") // 替换 \n
.Replace("哎", "%d") // 替换 \n
.Replace("站", "%s"); // 替换 %s
                    // Console.WriteLine(input + "Debug:" + tmp2);
                    return replaced;
                }
                

            }
            return input;
        }
        public static class UnicodeVariants
        {
            public static string[] a = new string[] { "ä", "ā", "á", "ǎ", "à", "ă", "å", "ǻ", "ã", "ǟ", "ǡ", "ǻ", "ȁ", "ȃ", "ȧ", "ᶏ", "ḁ", "ẚ", "ạ", "ả", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ắ", "ằ", "ẳ", "ẵ", "ặ", "ɑ", "α", "ά", "ὰ", "ἀ", "ἁ", "ἂ", "ἃ", "ἆ", "ἇ", "ᾂ", "ᾃ", "ᾰ", "ᾱ", "ᾲ", "ᾳ", "ᾴ", "ᾶ", "ᾷ", "ⱥ", "𐓘", "𐓙", "𐓚" };
            public static string[] A = new string[] { "Ā", "Á", "Ǎ", "À", "Â", "Ã", "Ä", "Å", "Ǻ", "Ά", "Ă", "Δ", "Λ", "Д", "Ą" };
            public static string[] b = new string[] { "b", "ь", "в", "Ъ", "Б", "б", "β", "ƀ", "ƃ", "ɓ", "ᵬ", "ᶀ", "ḃ", "ḅ", "ḇ", "ꞗ" };
            public static string[] B = new string[] { "ß", "฿" };
            public static string[] c = new string[] { "c", "ç", "ς", "ĉ", "č", "ċ", "ć", "ĉ", "ċ", "ƈ", "ȼ", "¢", "ɕ", "ḉ", "ꞓ", "ꞔ" };
            public static string[] C = new string[] { "Č", "Ç", "Ĉ", "Ć", "€" };
            public static string[] d = new string[] { "d", "ď", "đ", "₫", "ð", "δ" };
            public static string[] D = new string[] { "Ď", "Ð" };
            public static string[] e = new string[] { "e", "ē", "é", "ě", "è", "ê", "ĕ", "ė", "ë", "ę", "з", "ε", "έ", "э", "℮" };
            public static string[] E = new string[] { "E", "Ē", "É", "Ě", "È", "Ĕ", "Ё", "Σ", "Έ", "Є", "Э", "З" };
            public static string[] f = new string[] { "f", "ƒ" };
            public static string[] F = new string[] { "F", "₣" };
            public static string[] g = new string[] { "ḡ", "ģ", "ǧ", "ĝ", "ğ", "ġ", "ǥ", "ǵ", "ɠ", "ᶃ", "ꞡ" };
            public static string[] G = new string[] { "Ḡ", "Ǵ", "Ǧ", "Ĝ", "Ğ", "Ģ", "Ġ", "Ɠ", "Ǥ", "Ꞡ" };
            public static string[] h = new string[] { "ĥ", "ħ", "ђ", "н" };
            public static string[] H = new string[] { "H", "Ĥ", "Ħ" };
            public static string[] i = new string[] { "ı", "ī", "í", "ǐ", "ì", "ĭ", "î", "ï", "ί", "į", "ΐ", "ι" };
            public static string[] I = new string[] { "Ī", "Í", "Ǐ", "Ì", "Î", "Ï", "Ĭ", "Ί" };
            public static string[] j = new string[] { "j", "ĵ" };
            public static string[] J = new string[] { "J", "Ĵ" };
            public static string[] k = new string[] { "ƙ", "κ" };
            public static string[] K = new string[] { "К", "Ķ", "Ǩ" };
            public static string[] l = new string[] { "ŀ", "ļ", "ℓ", "ĺ", "ļ", "ľ", "ł" };
            public static string[] L = new string[] { "Ŀ", "£", "Ļ", "Ł", "Ĺ" };
            public static string[] m = new string[] { "m", "₥", "м", "ṁ" };
            public static string[] M = new string[] { "M", "Ṁ" };
            public static string[] n = new string[] { "ń", "ň", "ŉ", "η", "ή", "и", "й", "ñ", "л", "п", "π" };
            public static string[] N = new string[] { "Ń", "Ň", "И", "Й", "Π", "Л" };
            public static string[] o = new string[] { "ō", "ó", "ŏ", "ò", "ô", "õ", "ö", "ő", "σ", "ø", "ǿ" };
            public static string[] O = new string[] { "Ō", "Ó", "Ǒ", "Ò", "Ô", "Õ", "Ö", "Ό", "Θ", "Ǿ" };
            public static string[] p = new string[] { "p", "ρ", "ƥ", "φ" };
            public static string[] P = new string[] { "P", "Þ", "₽" };
            public static string[] q = new string[] { "q", "ʠ", "ɋ" };
            public static string[] Q = new string[] { "Q", "Ɋ", "ℚ" };
            public static string[] r = new string[] { "ř", "ŗ", "г", "ѓ", "ґ", "я" };
            public static string[] R = new string[] { "Ř", "Я", "Г", "Ґ" };
            public static string[] s = new string[] { "ś", "š", "ŝ", "ș", "ş", "ƨ" };
            public static string[] S = new string[] { "Š", "Ş", "Ș", "§" };
            public static string[] t = new string[] { "ț", "ţ", "ť", "ŧ", "т", "τ" };
            public static string[] T = new string[] { "Ť", "Ţ", "Ț", "Ŧ" };
            public static string[] u = new string[] { "ū", "ú", "ǔ", "ù", "û", "ũ", "ů", "ų", "ü", "ǖ", "ǘ", "ǚ", "ǜ", "ύ", "ϋ", "ΰ", "µ", "ц", "џ" };
            public static string[] U = new string[] { "Ū", "Ǔ", "Ǖ", "Ǘ", "Ǚ", "Ǜ", "Ц" };
            public static string[] v = new string[] { "ν" };
            public static string[] V = new string[] { "V", "V", "Ṽ", "Ṿ", "V̇", "Ꝟ" };
            public static string[] w = new string[] { "ẃ", "ẁ", "ẅ", "ŵ", "ш", "щ", "ω", "ώ" };
            public static string[] W = new string[] { "Ẁ", "Ẃ", "Ẅ", "Ŵ", "Ш", "Щ" };
            public static string[] x = new string[] { "x", "ж", "ẋ", "×" };
            public static string[] X = new string[] { "X", "Ж", "Ẋ", "χ" };
            public static string[] y = new string[] { "y", "ỳ", "ŷ", "ч", "γ" };
            public static string[] Y = new string[] { "Ϋ", "Ÿ", "Ŷ", "Ỳ", "Ύ", "Ψ", "￥", "У", "Ў", "Ч" };
            public static string[] z = new string[] { "z", "ź", "ż", "ž", "ƶ", "ȥ", "ʐ", "ᵶ", "ᶎ", "ẑ", "ẓ", "ẕ", "ⱬ" };
            public static string[] Z = new string[] { "Z", "Ź", "Ż", "Ž", "Ƶ", "Ȥ", "Ẓ", "Ẕ", "Ẑ", "Ⱬ", "ℤ" };

            // 字体缺少
            public static string[] _2 = new string[] { "↊" };

            // 字体缺少
            public static string[] _3 = new string[] { "↋" };

            public static string[] alphabet = new string[] { "A", "a", "B", "b", "C", "c", "D", "d", "E", "e", "F", "f", "G", "g", "H", "h", "I", "i", "J", "j", "K", "k", "L", "l", "M", "m", "N", "n", "O", "o", "P", "p", "Q", "q", "R", "r", "S", "s", "T", "t", "U", "u", "V", "v", "W", "w", "X", "x", "Y", "y", "Z", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            public static string[] enNumber = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty" };
        }

        public string Conver(string ab)
        {
       
            
            // 动态字段名

            try
            {
                Type type = typeof(UnicodeVariants);

                // 处理数字开头的字段名
                string fieldName = ab;
                if (!string.IsNullOrEmpty(ab) && char.IsDigit(ab[0]))
                {
                    fieldName = "_" + ab;
                }
                if (ab == " ")
                { space++; }

                // 获取字段信息
                FieldInfo field = type.GetField(
                    fieldName,
                    BindingFlags.Public | BindingFlags.Static
                );

                if (field == null)
                {
                    return ab;
                    throw new ArgumentException("字段不存在");
                    
                }

                if (field.FieldType != typeof(string[]))
                {
                    throw new InvalidCastException("字段类型不是字符串数组");
                }

                // 获取值
                string[] variants = (string[])field.GetValue(null);

                // 输出结果
                
                int n = GenerateRandomNumberInRange(0, variants.Length);
                return variants[n]; 
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("错误: {ex.Message}" + ex.Message);
                return null;
            }

            return null;
        }
        static int GenerateRandomNumberInRange(int minValue, int maxValue)
        {
            if (minValue >= maxValue)
                throw new ArgumentException("minValue 必须小于 maxValue");

            // 计算范围大小
            int range = maxValue - minValue;

            // 生成随机字节数组
            byte[] randomBytes = new byte[4]; // 4 字节 = 32 位
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            // 将字节数组转换为无符号整数
            uint randomUInt = BitConverter.ToUInt32(randomBytes, 0);

            // 通过取模运算映射到指定范围
            int result = (int)(randomUInt % range) + minValue;
            return result;
        }
         private static string ProcessSingleChar(char c)
    {
        
         return c.ToString();
    }

        public string LineCover(string input)
         {
             space = 0;
            
             string tmp="";
             
           
                
                foreach (char b in input)
                {
                    try
                    {
                        tmp = tmp + Conver(b.ToString());
                    }
                    catch
                    { }
            
                }
               // Console.WriteLine(tmp +" "+space);
                string f="";
                int tmp1 = 0;
                int tmp2 = 0;
                //Console.WriteLine(input.Length);
                for (int a = 0; a < input.Length; a++)
                {
                    
                    if (input.Length > 2 && tmp1 == 0)
                    { f = f + " !";
                    tmp1++;
                    tmp2 = 1;
                    }
                    if ((a % 7) == 0 && a != 0)
                    {
                        f = f + "!";
                        tmp2++;
                        if (tmp2 >= 3)
                        { f = f + " ";
                        tmp2 = 0;
                        }

                    }
                    
                }
                
                
                tmp = FakeHash(tmp) + "[" + tmp + f + "]"; 
                    return tmp;
            

        }
        static string GetMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input); // 将字符串转换为字节数组
                byte[] hashBytes = md5.ComputeHash(inputBytes); // 计算哈希值

                // 将字节数组转换为十六进制字符串
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2")); // "x2" 表示两位十六进制
                }
                return sb.ToString();
            }
        }
        public static string FakeHash(string input)
        {   string tmp ="";
            string hash = GetMD5Hash(input);
            for (int a=0; a < 5; a++)
            {
                tmp = tmp + hash[a];
            }
            tmp = "[" + tmp + "]";
            return tmp;
        
        
        }
        private static string[] GetStringArray(string fieldName)
        {
            try
            {
                Type type = typeof(UnicodeVariants);
                FieldInfo field = type.GetField(
                    fieldName,
                    BindingFlags.Public | BindingFlags.Static
                );

                if (field != null && field.FieldType == typeof(string[]))
                {
                    return (string[])field.GetValue(null);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
          
           
        }

     
    static void CopyDirectory(DirectoryInfo source, DirectoryInfo target)
    {
        // 如果目标文件夹不存在，则创建
        if (!target.Exists)
        {
            target.Create();
        }

        // 复制所有文件
        foreach (FileInfo file in source.GetFiles())
        {
            file.CopyTo(Path.Combine(target.FullName, file.Name), overwrite: true); // 允许覆盖
        }

        // 递归复制子文件夹
        foreach (DirectoryInfo subDir in source.GetDirectories())
        {
            DirectoryInfo destSubDir = target.CreateSubdirectory(subDir.Name);
            CopyDirectory(subDir, destSubDir); // 递归调用
        }
    }


     private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text Files|*.txt;*.ini;*.log;*.cmd;*.bat;*.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = Path.GetDirectoryName(openFileDialog.FileName);
                    filepath = openFileDialog.FileName;

                }
            }
            if (radioButton2.Checked)
            {
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    // 设置对话框标题和初始路径（可选）
                    folderDialog.Description = "请选择目标文件夹";


                    // 显示对话框并检查用户是否点击“确定”
                    DialogResult result = folderDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        folderpath = folderDialog.SelectedPath;
                       // Console.WriteLine("选择的文件夹路径: " + folderpath);
                    }
                    else
                    {
                       // Console.WriteLine("用户取消了选择");
                    }
                }
            }
            
}
     public static bool ContainsSubstring(string input, string substring)
     {
         return input.Contains(substring);
     }
    public void DoFolder (string rootDir)
    {
        var dirQueue = new Queue<string>();
        dirQueue.Enqueue(rootDir);

        while (dirQueue.Count > 0)
        {
            string currentDir = dirQueue.Dequeue();

            try
            {
                try
                {
                    foreach (string file in Directory.GetFiles(currentDir))
                    {
                        
                        if (ContainsSubstring(file, "en_us.json"))
                        {
                            path = file.Replace("en_us.json","");
                            filepath = file;
                            Console.WriteLine(file + filepath); //FindFiles
                           
                            textBox2.Text = textBox2.Text +"\r\n正在处理："+ file + "\r\n";
                           // Console.WriteLine(file);
                            build();
                        }
                    }
                }
                catch
                { break; }

                // 2. 将子文件夹加入队列
                foreach (string subDir in Directory.GetDirectories(currentDir))
                {
                    dirQueue.Enqueue(subDir);
                }
            }
            catch (UnauthorizedAccessException)
            {
                //Console.WriteLine("无权限访问目录: "+currentDir);
            }
            catch (DirectoryNotFoundException)
            {
               // Console.WriteLine("目录不存在:"+currentDir);
            }
        }
    }
private void ReplaceLineEndings(StreamReader reader)
    {string outputFilePath = null;
        if (savemode == 0)
        {
           outputFilePath = Path.Combine(path, lang + ".json");
        }
        if (savemode == 1)
        { outputFilePath = savepath; }
        if (savemode == 2)
        {
            outputFilePath = Path.Combine(path, lang + ".json");
        }

    // 使用 StreamWriter 写入文件（一次性打开文件）
    using (StreamWriter writer = new StreamWriter(outputFilePath, false, Encoding.UTF8))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            try
            {
                
                writer.WriteLine(Out(line)); // 写入处理后的行
            }
            catch { writer.WriteLine(line); }
        }
    }

    textBox2.Text =textBox2.Text+"\r\n处理完成\r\n";
}
public void build()
{
    try
    {
        Console.WriteLine("Building...");
        // 使用 StreamReader 逐行读取文件
        using (StreamReader reader = new StreamReader(filepath, Encoding.UTF8, detectEncodingFromByteOrderMarks: true))
        {
            ReplaceLineEndings(reader);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("错误:" + ex.Message);
    }
}

public void MainBuild()
{
    if (radioButton1.Checked)
    {
        if (checkBox1.Checked)
        { lang = textBox1.Text; }
        else
        { lang = "qps_ploc"; }
        build();
    }
    if (radioButton2.Checked)
    {
        if (checkBox1.Checked)
        { lang = textBox1.Text; }
        else
        { lang = "qps_ploc"; }
        // Console.WriteLine(folderpath);
        if (savemode == 0)
        {DoFolder(folderpath);}
        if (savemode == 1 || savemode == 2)
        { DoFolder(savefolderpath); }
    }
}
private void 生成ToolStripMenuItem_Click(object sender, EventArgs e)
{
    savemode = 0;
    if (path != null || folderpath != null)
    {
        MainBuild();
    }
    else
    { MessageBox.Show("请先打开文件"); }
}

private void checkBox1_CheckedChanged(object sender, EventArgs e)
{
   
}

private void 生成并另存为ToolStripMenuItem_Click(object sender, EventArgs e)
{
    savemode = 1;
    if (radioButton1.Checked)
    {
        if (path != null)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "保存语言文件文件";
                saveDialog.Filter = "json语言文件|*.json";
                saveDialog.DefaultExt = "json";


                if (saveDialog.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        savepath = saveDialog.FileName;
                        MainBuild();
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
            }
        }
        else
        { MessageBox.Show("请先打开文件"); }
        
    }
    if (radioButton2.Checked)
    {
        savemode = 2;
        if (folderpath != null)
    { using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    // 设置对话框标题和初始路径（可选）
                    folderDialog.Description = "请选择另存为文件夹";


                    // 显示对话框并检查用户是否点击“确定”
                    DialogResult result = folderDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        savefolderpath = folderDialog.SelectedPath;
                       
                       // Console.WriteLine("选择的文件夹路径: " + folderpath);
                    }
                    else
                    {
                       // Console.WriteLine("用户取消了选择");
                    }
                }
         try
        {
            CopyDirectory(new DirectoryInfo(folderpath), new DirectoryInfo(savefolderpath));
            
            Console.WriteLine("文件夹复制完成！");
        }
        catch (Exception ex)
        {
            Console.WriteLine("错误: "+ex.Message);
        }
         MainBuild();
    }
    else
    { MessageBox.Show("请先打开"); }
        
    }
    
    
    
}

private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
{
    Form f2 = new Form2();
    f2.ShowDialog();
}


        
        

            

    }
}
