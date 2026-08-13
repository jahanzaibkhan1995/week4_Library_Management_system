using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Library_Management_System
{
    internal class FileManager
    {
        private string folderPath =
            @"E:\Software Development Learning\week4\newfeaturesavedata\week4_Library_Management_system\Library_Management_System\Library_Management_System\Data";

        private string bookFilePath;
        private string memberFilePath;

        public FileManager()
        {
            Directory.CreateDirectory(folderPath);

            bookFilePath = Path.Combine(folderPath, "books.json");
            memberFilePath = Path.Combine(folderPath, "members.json");
        }

        public void SaveBooks(List<Book> books)
        {
            string json = JsonSerializer.Serialize(
                books,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(bookFilePath, json);
        }

        public List<Book> LoadBooks()
        {
            if (!File.Exists(bookFilePath))
            {
                return new List<Book>();
            }

            string json = File.ReadAllText(bookFilePath);

            return JsonSerializer.Deserialize<List<Book>>(json)
                   ?? new List<Book>();
        }
        public void SaveMembers(List<Member> members)
        {
            string json = JsonSerializer.Serialize(
                members,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(memberFilePath, json);
        }

        public List<Member> LoadMembers()
        {
            if (!File.Exists(memberFilePath))
            {
                return new List<Member>();
            }

            string json = File.ReadAllText(memberFilePath);

            return JsonSerializer.Deserialize<List<Member>>(json)
                   ?? new List<Member>();
        }
    }
}