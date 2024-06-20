using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projectPBO
{
    internal class model
    {
        public class Book
        {
            public int bookId { get; set; }
            public string title { get; set; }
            public string author { get; set; }
            public string publisher { get; set; }
            public DateTime yearPublished { get; set; }
            public string status { get; set; }
        }
        public class BookRepository
        {
            public string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=dimas;Database=onlineLibrary;";

            public void InsertBook(Book book)
            {
                try
                {

                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "INSERT INTO BUKU (book_id,title, author, publisher, year_published, status) " +
                                     "VALUES (@book_id, @title, @author, @publisher, @year_published, @status)";
                        using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@book_id", book.bookId);
                            command.Parameters.AddWithValue("@title", book.title);
                            command.Parameters.AddWithValue("@author", book.author);
                            command.Parameters.AddWithValue("@publisher", book.publisher);
                            command.Parameters.AddWithValue("@year_published", book.yearPublished);
                            command.Parameters.AddWithValue("@status", book.status);
                            command.ExecuteNonQuery();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            public List<Book> GetAllBooks()
            {
                List<Book> books = new List<Book>();

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT book_id, title, author, publisher, year_published, status FROM BUKU";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(new Book
                            {
                                bookId = int.Parse(reader["book_id"].ToString()),
                                title = reader["title"].ToString(),
                                author = reader["author"].ToString(),
                                publisher = reader["publisher"].ToString(),
                                yearPublished = DateTime.Parse(reader["year_published"].ToString()),
                                status = reader["status"].ToString(),
                            });
                        }
                    }
                }

                return books;
            }

            public void UpdateBook(Book book)
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE BUKU SET title = @title, author = @author, publisher = @publisher, year_published = @year_published WHERE book_id = @book_id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("book_id", book.bookId);
                        cmd.Parameters.AddWithValue("title", book.title);
                        cmd.Parameters.AddWithValue("author", book.author);
                        cmd.Parameters.AddWithValue("publisher", book.publisher);
                        cmd.Parameters.AddWithValue("year_published", book.yearPublished);
                       
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        public class Pengguna
        {
            public int MemberId { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
        }

        public class PenggunaRepository
        {
            public string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=dimas;Database=onlineLibrary;";

            public List<Pengguna> GetAllPengguna()
            {
                List<Pengguna> penggunaList = new List<Pengguna>();

                try
                {
                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "SELECT member_id, name, address, phone FROM pengguna";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Pengguna pengguna = new Pengguna
                                {
                                    MemberId = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Address = reader.GetString(2),
                                    Phone = reader.GetString(3)
                                };
                                penggunaList.Add(pengguna);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving data: " + ex.Message);
                }

                return penggunaList;
            }
            public void AddPengguna(Pengguna pengguna)
            {
                try
                {
                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "INSERT INTO PENGGUNA (member_id, name, address, phone) VALUES (@member_id, @name, @address, @phone)";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("member_id", pengguna.MemberId);
                            cmd.Parameters.AddWithValue("name", pengguna.Name);
                            cmd.Parameters.AddWithValue("address", pengguna.Address);
                            cmd.Parameters.AddWithValue("phone", pengguna.Phone);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding data: " + ex.Message);
                }
            }
        }
    }
}
