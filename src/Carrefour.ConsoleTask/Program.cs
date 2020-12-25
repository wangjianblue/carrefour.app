using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ImageMagick;
using System.Collections;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Threading;

namespace Carrefour.ConsoleTask
{
    class Program
    {
        static async Task Main(string[] args)
        { 
            // var demo1=new LinkedList<int>(3);
            // var demo2=new LinkedList<int>(1);
            // var demo3=new LinkedList<int>(2);
            // demo1.next=demo2;
            // demo2.next=demo3;

            // //Console.WriteLine(demo1.val+"-"+demo1.next.val+"-"+demo1.next.next.val+"-"+demo1.next.next.next?.val);

            // Stack  stack=new System.Collections.Stack (); 
            // stack.Push("2");
            // stack.Push("5");
            // stack.Push("3");
        
            // Console.WriteLine("-------------");
            // for(int i=0;i<=stack.Count+1;i++)
            // {
            //     Console.WriteLine(stack.Pop());
            // }    
            // Queue queue=new System.Collections.Queue();
            // queue.Enqueue("2");
            // queue.Enqueue("5");
            // queue.Enqueue("3");   
            // for(int i=0;i<=queue.Count+1;i++)
            // {
            //     Console.WriteLine(queue.Dequeue());
            // }  

            // TreeNode treenode1 =new TreeNode(3);
            // TreeNode treenode2 =new TreeNode(4);
            // TreeNode treenode3 =new TreeNode(5);
            // TreeNode treenode4 =new TreeNode(1);
            // TreeNode treenode5 =new TreeNode(2);
            // TreeNode treenode6 =new TreeNode(6);
            // treenode1.leftNextNode=treenode2;
            // treenode1.rightNextNodel=treenode3;
            // treenode2.leftNextNode=treenode4;
            // treenode2.rightNextNodel=treenode5;
            // treenode3.rightNextNodel=treenode6;
         
            //MaginckMethod();

             string cc = Encrypt("8F6ACA1453829D52ECB4CE5DC7DACE7501463ED97372EE0DD9A8071B52095E3F", "");

             string cc1 = Decrypt("8F6ACA1453829D52ECB4CE5DC7DACE7501463ED97372EE0DD9A8071B52095E3F", "9vgCyZ8pEVP1t0joTueScIzF9LFUdV9n");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Task<string> res=null;
         
            var result= await  Info();
           
          
            Console.WriteLine("休息好看了11111");
            Write1();
            //Console.WriteLine(res.Result);
            Console.WriteLine(result);
            Console.WriteLine("休息好看了1122122");

            Console.ReadKey();
        }
        static void Write(int i)
        {
            Console.WriteLine(i);
        }
/// <summary>
        /// sha256加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string sha256(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] hash = SHA256Managed.Create().ComputeHash(bytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("X2"));
            }

            return builder.ToString();
        }

        public static string Encrypt(string encryptStr, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(encryptStr);
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB; //加密模式
            rDel.Padding = PaddingMode.PKCS7;   //填充模式
            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="decryptStr">密文</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string Decrypt(string decryptStr, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = Convert.FromBase64String(decryptStr);
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        static async void GetInfo()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("开始休息");
                Thread.Sleep(3000);
                Console.WriteLine("结束休息");
            });


            await Task.Run(() =>
            {
                Console.WriteLine("3333休息");
                Thread.Sleep(3000);
                Console.WriteLine("3333休息3333");
            });

        }

        static  void Write()
        {
            Console.WriteLine("浪里个浪");
            
        }

        static async Task<string> Info()
        {
            Console.WriteLine("又要休息");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            var res = await Task.Run(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {

                }; 
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                 Console.WriteLine("休息好看了"); 
                 return "success";
            });
            
            Console.WriteLine(res+"111111111111111111111");
            
            return res;
        }

        static  void Write1()
        {
            Console.WriteLine("浪里个浪");
           
        }
        private static void MaginckMethod()
        {
            string path = @"D:\huatek\演练项目\Carrefour.WebApp\src\Carrefour.ConsoleTask\images\20200807172706.jpg";
            MagickReadSettings settings = new MagickReadSettings(); 
            //settings.Density = new Density(300, 300); //设置质量
            using (MagickImageCollection images = new MagickImageCollection())
            {
                try
                {
                    images.Read(path, settings);
                    for (int i = 0; i < images.Count; i++)
                    {
                        MagickImage image = (MagickImage)images[i];
                        image.Format = MagickFormat.Jpg;
                        image.Quality=40;
                        image.Write(path.Replace(Path.GetExtension(path), "") + "-" + i + ".jpg");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
