using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DBContext;
using DAL.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class ImageService : IImage
    {

        public List<string> ImageChoosing()
        {
            string FilePath = "C:\\aaaלימודים\\C#\\new\\Project_A\\Project_A\\תמונות\\MISC\\AUTXFER.MRK";
            List<string> images = [];
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("FILE NOT FOUND");
                throw new FileNotFoundException("File not found. ", FilePath);

            }
            
            try
            {
                foreach (var line in File.ReadLines(FilePath))
                {
                    if (line.Contains("SRC"))
                    {
                        int index = line.IndexOf("..");
                        if (index >= 0) // בדיקה לשיפור נהול אינדקס
                        {
                            string record = line.Substring(index).TrimEnd('"', '>');
                            record = record.Replace('/', '\\');
                            images.Add(record);
                            Console.WriteLine("try newSavaimg");
                        }
                    }
                    Console.WriteLine("try newSavaimg");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"1111111111111111111111111111111111111111111: {ex.Message}");
            }
                return images;
        }

        public void FindAndKeepDB(string OrderCode, double selectedSize)
        {
            List<string> ImagesPathes = ImageChoosing();
            Console.WriteLine("in FindAndKeepDB");
            foreach (var imagePath in ImagesPathes)
            {
                Console.WriteLine(imagePath);
            }
            using (var context = new ApplicationDbContext())
            {
                foreach (var imagePath in ImagesPathes)
                {
                    
                    Console.WriteLine("try newSavaimg to DB");
                    byte[] imageBytes = Encoding.UTF8.GetBytes(imagePath);

                    SavingImage s = new SavingImage(OrderCode, imageBytes, 1, selectedSize);

                        context.SavingImages.Add(s);
                        Console.WriteLine("try newSavaimg to DB");
                }

              
                try
                {

                    context.SaveChanges(); // Save all changes to the database


                }

                catch (DbUpdateException ex)

                {

                    Console.WriteLine(ex.InnerException?.Message); // Log or handle the inner exception

                }
            }
        }
    }
}