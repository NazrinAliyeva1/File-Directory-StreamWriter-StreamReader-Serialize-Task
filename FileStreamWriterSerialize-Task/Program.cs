using FileStreamWriterSerialize_Task.Models;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace FileStreamWriterSerialize_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ///Basda yazdigim kodlar tekrar yazdiqlarimdi Yeni, siz yazdiginiz kodun ustunde islememisem.
            //Directory
            //Directory.CreateDirectory(@"C:\Users\99455\Desktop\New folder");          
            //if(Directory.Exists(@"C:\Users\99455\Desktop\New folder"))
            //{
            //    Directory.Delete(@"C:\Users\99455\Desktop\New folder", true);
            //}

            //File



            //if (!File.Exists(@"C:\Users\99455\Desktop\NazrinAliyeva\photo.txt"))
            //{
            //    File.Create(@"C:\Users\99455\Desktop\NazrinAliyeva\photo.txt");
            //}

            //File.Create(@"C:\Users\99455\Desktop\NazrinAliyeva\photo.txt").Close();
            //File.Delete(@"C:\Users\99455\Desktop\NazrinAliyeva\photo.txt");

            //FileInfo file = new FileInfo(@"C:\Users\99455\Desktop\NazrinAliyeva\photo.txt");
            //file.Create().Close();
            //file.Delete();

            //DirectoryInfo directory = new DirectoryInfo(@"C:\Users\99455\Desktop\NazrinAliyeva");

            //directory.Create();
            //directory.Delete();

            //File.Create(@"C:\Users\99455\Desktop\Top\book.txt");

            //Yazi yazmaq
            //StreamWriter sw = new StreamWriter(@"C:\Users\99455\Desktop\Top\book2.txt", true);
            //sw.WriteLine("Nihal");
            //sw.WriteLine("Nuriye");
            //sw.Close();

            //uzun yazilis

            //StreamReader sr = new StreamReader(@"C:\Users\99455\Desktop\Top\book.txt");
            //try
            //{
            //    int result = int.Parse(sr.ReadLine());
            //}
            //catch(Exception m)
            //{
            //    Console.WriteLine(m.Message);
            //}
            //finally
            //{
            //    sr.Close();
            //}


            //StreamWriter sw = new StreamWriter(@"C:\Users\99455\Desktop\Top\book.txt", true);
            //sw.WriteLine("Nuran");
            //sw.WriteLine("Nisa");
            //sw.Close();

            //qisa yazilis

            //using(StreamReader sw = new StreamReader(@"C:\Users\99455\Desktop\Top\book.txt"))
            //{
            //    Console.WriteLine(sw.ReadLine());
            //}
            //using(StreamWriter sw = new StreamWriter(@"C:\Users\99455\Desktop\Top\book.txt"))
            //{
            //    Console.WriteLine("asa");
            //}


            //Category category = new Category { Name = "Mobile" };

            //Product product = new Product { Id = 1, Name = "Iphone 15", Price = 2000, Category = category };
            //Product product2 = new Product { Id = 1, Name = "Samsung s23", Price = 2400, Category = category };
            //Product product3 = new Product { Id = 1, Name = "Xiomi POCO5x 15", Price = 1000, Category = category };

            //List<Product> products = new List<Product> { product, product2, product3 };


            //string json = JsonConvert.SerializeObject(products);
            //using (StreamWriter sw = new StreamWriter(@"C:\Users\99455\source\repos\FileStreamWriterSerialize-Task\FileStreamWriterSerialize-Task\Files\Products.json"))
            //{
            //    sw.Write(json);
            //}

            //jsonda deyisiklib edilibse ilk once stringle yazini oxuyuruq sonra deserelize edirik;
            //string result;
            //using (StreamReader sr = new StreamReader(@"C:\Users\99455\source\repos\FileStreamWriterSerialize-Task\FileStreamWriterSerialize-Task\Files\Products.json"))
            //{
            //    result = sr.ReadToEnd();
            //}
            ////obyektle islemek cetindir , Downcast etmek tehlukelidir ve performansda yorucudur. Ona gore bunu obyektle yazmaq mecburiyyetinde deyilik.
            ////var objects = JsonConvert.DeserializeObject(result); ///des, 1-ci metod

            //var objects = JsonConvert.DeserializeObject<List<Product>>(result);
            //foreach (Product product in objects)
            //{
            //    //product.Price += 10;
            //    Console.WriteLine(product.Name);
            //}



            //!!!!!!!!!!!!!!!!!!!!!!!!!! Ev tapsirigi !!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            List<string> names = new List<string> { "Aliye", "Sefa", "Nergiz" };

            // Mellumati JSON dosyasına yazma
            SerializeToJsonFile(names);

            // JSON faylinda melumati oxumaq
            List<string> readNames = DeseriazlizeJSFile();

            // oxunan melumati ekrana yazaq:
            Console.WriteLine("Names read from JSON file:");
            foreach(string name in readNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("\n");
            ///Search
            bool isFound = Search("Alidye");
            Console.WriteLine($"Is 'Aliye' found? => {isFound}");

            Console.WriteLine("\n");
            int indexToDelete = 0;
            Delete(indexToDelete);

 



        }

        //Metodlari yazma:
        public static void SerializeToJsonFile(List<string> data)
        {
            string json = JsonConvert.SerializeObject(data);
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\99455\source\repos\FileStreamWriterSerialize-Task\FileStreamWriterSerialize-Task\Files\Products.json"))
                {
                    sw.Write(json);
                }
                Console.WriteLine("Data successfully written to JSON file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static List<string> DeseriazlizeJSFile()
        {
            List<string> dataList = new List<string>();
            try
            {
                string jsonData;
                using (StreamReader sr = new StreamReader(@"C:\Users\99455\source\repos\FileStreamWriterSerialize-Task\FileStreamWriterSerialize-Task\Files\Products.json"))
                {
                    jsonData = sr.ReadToEnd();
                }
                dataList = JsonConvert.DeserializeObject<List<string>>(jsonData);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dataList;

        }
        public static void Add(string name)
        {
            List<string> names = DeseriazlizeJSFile();
            names.Add(name);
            SerializeToJsonFile(names);
        }
        public static bool Search(string name)
        {
            List<string> names = DeseriazlizeJSFile();
            return names.Contains(name);//varsa true yoxdursa false
        }
        public static void Delete(int index)
        {
            List<string> names = DeseriazlizeJSFile();

            if (index >= 0 && index < names.Count)
            {
                names.RemoveAt(index);
                SerializeToJsonFile(names);
                Console.WriteLine("After enter index: 0  => Item deleted successfully.");

                Console.WriteLine("\n");

                Console.WriteLine("Updated names in JSON file:");
                foreach(string name in names)
                {
                    Console.WriteLine(name);
                }
            }
            else
            {
                Console.WriteLine("Invalid index. No item deleted.");
            }

        }
    }
}
