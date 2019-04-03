using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using HCL.Business.People;
using HCL.Business.Items;
using HCL.Business.Company;
using System.Diagnostics;

namespace HCL.DataAccess
{
    public class InvenControl_DA
    {
        static private string activedir = @"C:\";
        static private string folderlocation = Path.Combine(activedir, @"JooyeonMok_HCL_FinalProject\");
        static private string idlocation = Path.Combine(folderlocation, "Itemid.dat");
        static private string publisherlocation = Path.Combine(folderlocation, "Publisher.dat");
        static private string authorlocation = Path.Combine(folderlocation, "Author.dat");
        static private string inventorylocation = Path.Combine(folderlocation, "Inventory.dat");
        static private string booklocation = Path.Combine(folderlocation, "Book.dat");
        static private string softwarelocation = Path.Combine(folderlocation, "Software.dat");
        static private string tempfilelocation = Path.Combine(folderlocation, "Temp_Data.dat");
        static private string tempfilelocation2 = Path.Combine(folderlocation, "Temp_Data2.dat");
        static private string deletedinvenlocation = Path.Combine(folderlocation, "Deleted_by_InvenController.txt");
        static private string addingitemtemp = Path.Combine(folderlocation, "Adding_Items_List");

        static public void Save_New_Author(Author newone)
        {
            using (StreamWriter wr = new StreamWriter(authorlocation, true))
            {
                wr.WriteLine(newone.AuthorID + "|" + newone.FirstName + "|" + newone.LastName + "|" + newone.Email);
            }
        }
        static public List<Author> List_Authors()
        {
            List<Author> list = new List<Author>();
            Author one;
            using (StreamReader read = new StreamReader(authorlocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    one = new Author();
                    one.AuthorID = col[0];
                    one.FirstName = col[1];
                    one.LastName = col[2];
                    one.Email = col[3];
                    list.Add(one);
                    lines = read.ReadLine();
                }
            }
            return list;
        }
        static public void Save_New_Publisher(Publisher newone)
        {
            using (StreamWriter wr = new StreamWriter(publisherlocation, true))
            {
                wr.WriteLine(newone.PubID + "|" + newone.Pub_Name);
            }
        }
        static public List<Publisher> List_Publishers()
        {
            List<Publisher> list = new List<Publisher>();
            Publisher one;
            using (StreamReader read = new StreamReader(publisherlocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    one = new Publisher();
                    one.PubID = col[0];
                    one.Pub_Name = col[1];
                    list.Add(one);
                    lines = read.ReadLine();
                }
            }
            return list;
        }
        static public string Author_ID_Generator()
        {
            string id = "";
            int idid = 0;
            using (StreamReader read = new StreamReader(authorlocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    idid = Convert.ToInt32(col[0]);
                    lines = read.ReadLine();
                }
                idid += 1;
                id = idid.ToString();
            }
            return id;
        }
        static public void Update_Author(Author upd)
        {
            using (StreamReader read = new StreamReader(authorlocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (upd.AuthorID == col[0])
                    {
                        lines = upd.AuthorID + "|" + upd.FirstName + "|" + upd.LastName + "|" + upd.Email;
                    }
                    using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                    {
                        wr.WriteLine(lines);
                    }
                    lines = read.ReadLine();
                }
            }
            File.Delete(authorlocation);
            File.Move(tempfilelocation, authorlocation);
        }
        static public Author Searched_Author_by_ID(string id)
        {
            Author toreturn = new Author();
            using (StreamReader r = new StreamReader(authorlocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (id == col[0])
                    {
                        toreturn.AuthorID = id;
                        toreturn.FirstName = col[1];
                        toreturn.LastName = col[2];
                        toreturn.Email = col[3];
                        break;
                    }
                    lines = r.ReadLine();
                }
            }
            return toreturn;
        }
        static public string Publisher_ID_Generator()
        {
            string id = "";
            int idid = 0;
            using (StreamReader read = new StreamReader(publisherlocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    idid = Convert.ToInt32(col[0]);
                    lines = read.ReadLine();
                }
                idid += 1;
                id = idid.ToString();
            }
            return id;
        }
        static public Publisher Searched_Publisher_by_ID(string id)
        {
            Publisher toreturn = new Publisher();
            using (StreamReader r = new StreamReader(publisherlocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (id == col[0])
                    {
                        toreturn.PubID = id;
                        toreturn.Pub_Name = col[1];
                        break;
                    }
                    lines = r.ReadLine();
                }
            }
            return toreturn;
        }
        static public void Update_publisher(Publisher upd)
        {
            using (StreamReader read = new StreamReader(publisherlocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (upd.PubID == col[0])
                    {
                        lines = upd.PubID + "|" + upd.Pub_Name;
                    }
                    using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                    {
                        wr.WriteLine(lines);
                    }
                    lines = read.ReadLine();
                }
            }
            File.Delete(publisherlocation);
            File.Move(tempfilelocation, publisherlocation);
        }
        static public void Save_Inventory(string id, string quan)
        {
            using (StreamWriter r = new StreamWriter(inventorylocation, true))
            {
                r.WriteLine(id + "|" + quan);
            }
        }
        static public void Update_Inventory(string id, string quan)
        {
            using (StreamReader r = new StreamReader(inventorylocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[0] == id)
                    {
                        lines = id + "|" + quan;
                    }
                    using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                    {
                        wr.WriteLine(lines);
                    }
                    lines = r.ReadLine();
                }
            }
            File.Delete(inventorylocation);
            File.Move(tempfilelocation, inventorylocation);
        }
        static public string Quantity_of_Item(string id)
        {
            string quan = "";
            using (StreamReader r = new StreamReader(inventorylocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[0] == id)
                    {
                        quan = col[1];
                        break;
                    }
                    lines = r.ReadLine();
                }
            }
            return quan;
        }
        static public string Item_ID_Generator()
        {
            string id = "";
            int idid = 0;
            using (StreamReader r = new StreamReader(idlocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    lines = r.ReadLine();
                    idid = Convert.ToInt32(col[0]);
                }
                idid = idid + 1;
                id = idid.ToString();
            }
            return id;
        }
        static public void Save_New_Book(Book a)
        {
            using (StreamWriter r = new StreamWriter(booklocation, true))
            {
                r.WriteLine
                    (
                        a.ID + "|" +
                        a.Title + "|" +
                        a.AuthorID + "|" +
                        a.ISBN10 + "|" +
                        a.ISBN13 + "|" +
                        a.Category + "|" +
                        a.Type + "|" +
                        a.Pub_Year + "|" +
                        a.PubID + "|" +
                        a.UnitPrice.ToString() + "|" +
                        a.Quantity.ToString()
                    );
            }
            using (StreamWriter rr = new StreamWriter(idlocation, true))
            {
                rr.WriteLine
                    (
                        a.ID + "|" +
                        a.Title + "|" +
                        a.AuthorID + "|" +
                        a.ISBN10 + "|" +
                        a.ISBN13 + "|" +
                        a.Category + "|" +
                        a.Type + "|" +
                        a.Pub_Year + "|" +
                        a.PubID + "|" +
                        a.UnitPrice.ToString() + "|" +
                        a.Quantity.ToString()
                    );
            }
        }
        static public List<Book> Listed_Books()
        {
            List<Book> list = new List<Book>();
            Book a;
            using (StreamReader r = new StreamReader(booklocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    a = new Book();
                    a.ID = col[0];
                    a.Title = col[1];
                    a.AuthorID = col[2];
                    a.ISBN10 = col[3];
                    a.ISBN13 = col[4];
                    a.Category = col[5];
                    a.Type = col[6];
                    a.Pub_Year = col[7];
                    a.PubID = col[8];
                    a.UnitPrice = Convert.ToDouble(col[9]);
                    a.Quantity = Convert.ToInt32(col[10]);
                    list.Add(a);
                    lines = r.ReadLine();
                }
            }
            return list;
        }
        static public void Save_New_Software(Software a)
        {
            using (StreamWriter r = new StreamWriter(softwarelocation, true))
            {
                r.WriteLine
                    (
                        a.ID + "|" +
                        a.Title + "|" +
                        a.AuthorID + "|" +
                        a.Category + "|" +
                        a.Type + "|" +
                        a.Pub_Year + "|" +
                        a.PubID + "|" +
                        a.UnitPrice.ToString() + "|" +
                        a.Software_Type + "|" +
                        a.Quantity.ToString()
                    );
            }
            using (StreamWriter rr = new StreamWriter(idlocation, true))
            {
                rr.WriteLine
                    (
                        a.ID + "|" +
                        a.Title + "|" +
                        a.AuthorID + "|" +
                        a.Category + "|" +
                        a.Type + "|" +
                        a.Pub_Year + "|" +
                        a.PubID + "|" +
                        a.UnitPrice.ToString() + "|" +
                        a.Software_Type + "|" +
                        a.Quantity.ToString()
                    );
            }
        }
        static public List<Software> Listed_Softwares()
        {
            List<Software> list = new List<Software>();
            Software a;
            using (StreamReader r = new StreamReader(softwarelocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    a = new Software();
                    a.ID = col[0];
                    a.Title = col[1];
                    a.AuthorID = col[2];
                    a.Category = col[3];
                    a.Type = col[4];
                    a.Pub_Year = col[5];
                    a.PubID = col[6];
                    a.UnitPrice = Convert.ToDouble(col[7]);
                    a.Software_Type = col[8];
                    a.Quantity = Convert.ToInt32(col[9]);
                    list.Add(a);
                    lines = r.ReadLine();
                }
            }
            return list;
        }
        static public Book Searched_Book_by_ID(string id)
        {
            Book a = new Book();
            using (StreamReader r = new StreamReader(booklocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[0] == id)
                    {
                        a.ID = col[0];
                        a.Title = col[1];
                        a.AuthorID = col[2];
                        a.ISBN10 = col[3];
                        a.ISBN13 = col[4];
                        a.Category = col[5];
                        a.Type = col[6];
                        a.Pub_Year = col[7];
                        a.PubID = col[8];
                        a.UnitPrice = Convert.ToDouble(col[9]);
                        a.Quantity = Convert.ToInt32(col[10]);
                        break;
                    }
                    lines = r.ReadLine();
                }
            }
            return a;
        }
        static public Software Searched_Software_by_ID(string id)
        {
            Software a = new Software();
            using (StreamReader r = new StreamReader(softwarelocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[0] == id)
                    {
                        a.ID = col[0];
                        a.Title = col[1];
                        a.AuthorID = col[2];
                        a.Category = col[3];
                        a.Type = col[4];
                        a.Pub_Year = col[5];
                        a.PubID = col[6];
                        a.UnitPrice = Convert.ToDouble(col[7]);
                        a.Software_Type = col[8];
                        a.Quantity = Convert.ToInt32(col[9]);
                        break;
                    }
                    lines = r.ReadLine();
                }
            }
            return a;
        }
        static public void Update_a_Book(Book a)
        {
            using (StreamReader r = new StreamReader(booklocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[0] == a.ID)
                    {
                        lines = a.ID + "|" +
                        a.Title + "|" +
                        a.AuthorID + "|" +
                        a.ISBN10 + "|" +
                        a.ISBN13 + "|" +
                        a.Category + "|" +
                        a.Type + "|" +
                        a.Pub_Year + "|" +
                        a.PubID + "|" +
                        a.UnitPrice.ToString() + "|" +
                        a.Quantity.ToString();
                    }
                    using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                    {
                        wr.WriteLine(lines);
                    }
                    lines = r.ReadLine();
                }
            }
            File.Delete(booklocation);
            File.Move(tempfilelocation, booklocation);
            using (StreamReader re = new StreamReader(idlocation))
            {
                string lines = re.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[0] == a.ID)
                    {
                        lines = a.ID + "|" +
                        a.Title + "|" +
                        a.AuthorID + "|" +
                        a.ISBN10 + "|" +
                        a.ISBN13 + "|" +
                        a.Category + "|" +
                        a.Type + "|" +
                        a.Pub_Year + "|" +
                        a.PubID + "|" +
                        a.UnitPrice.ToString() + "|" +
                        a.Quantity.ToString();
                    }
                    using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                    {
                        wr.WriteLine(lines);
                    }
                    lines = re.ReadLine();
                }
            }
            File.Delete(idlocation);
            File.Move(tempfilelocation, idlocation);
        }
        static public void Update_a_Software(Software a)
        {
            using (StreamReader r = new StreamReader(softwarelocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[0] == a.ID)
                    {
                        lines = a.ID + "|" +
                        a.Title + "|" +
                        a.AuthorID + "|" +
                        a.Category + "|" +
                        a.Type + "|" +
                        a.Pub_Year + "|" +
                        a.PubID + "|" +
                        a.UnitPrice.ToString() + "|" +
                        a.Software_Type + "|" +
                        a.Quantity.ToString();
                    }
                    using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                    {
                        wr.WriteLine(lines);
                    }
                    lines = r.ReadLine();
                }
            }
            File.Delete(softwarelocation);
            File.Move(tempfilelocation, softwarelocation);
            using (StreamReader re = new StreamReader(idlocation))
            {
                string lines = re.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[0] == a.ID)
                    {
                        lines = a.ID + "|" +
                        a.Title + "|" +
                        a.AuthorID + "|" +
                        a.Category + "|" +
                        a.Type + "|" +
                        a.Pub_Year + "|" +
                        a.PubID + "|" +
                        a.UnitPrice.ToString() + "|" +
                        a.Software_Type + "|" +
                        a.Quantity.ToString();
                    }
                    using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                    {
                        wr.WriteLine(lines);
                    }
                    lines = re.ReadLine();
                }
            }
            File.Delete(idlocation);
            File.Move(tempfilelocation, idlocation);
        }
        static public bool Delete_Author(string authorid, string userid, string fname)
        {
            InventoryController wang = new InventoryController();
            bool deleted = false;
            using (StreamReader r = new StreamReader(authorlocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (authorid == col[0] && col[1].ToLower().Contains(fname.ToLower()))
                    {
                        using (StreamWriter wr = new StreamWriter(deletedinvenlocation, true))
                        {
                            wr.WriteLine
                                (
                                    userid + "|" +
                                    "Author" + "|" +
                                    wang.Searched_author_by_id(authorid).AuthorID + "|" +
                                    wang.Searched_author_by_id(authorid).FirstName + "|" +
                                    wang.Searched_author_by_id(authorid).LastName + "|" +
                                    wang.Searched_author_by_id(authorid).Email
                                );
                        }
                        deleted = true;
                    }
                    else
                    {
                        using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                        {
                            wr.WriteLine(lines);
                        }
                    }
                    lines = r.ReadLine();
                }
            }
            File.Delete(authorlocation);
            File.Move(tempfilelocation, authorlocation);
            File.SetAttributes(deletedinvenlocation, FileAttributes.Hidden);
            Process.Start(deletedinvenlocation);
            return deleted;
        }
        static public bool Delete_Book(string bookid, string userid, string title)
        {
            InventoryController wang = new InventoryController();
            bool deleted = false;
            using (StreamReader r = new StreamReader(booklocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (bookid == col[0] && col[1].ToLower().Contains(title.ToLower()))
                    {
                        string line = "";
                        using (StreamWriter wr = new StreamWriter(deletedinvenlocation, true))
                        {
                            line = userid + "|" +
                                    "Book" + "|" +
                                    wang.Searched_Book_by_ID(bookid).ID + "|" +
                                    wang.Searched_Book_by_ID(bookid).Title + "|" +
                                    wang.Searched_Book_by_ID(bookid).AuthorID + "|" +
                                    wang.Searched_Book_by_ID(bookid).Category + "|" +
                                    wang.Searched_Book_by_ID(bookid).PubID + "|" +
                                    wang.Searched_Book_by_ID(bookid).Pub_Year + "|" +
                                    wang.Searched_Book_by_ID(bookid).UnitPrice + "|" +
                                    wang.Searched_Book_by_ID(bookid).ISBN10 + "|" +
                                    wang.Searched_Book_by_ID(bookid).ISBN13;
                            wr.WriteLine(line);
                        }
                        deleted = true;
                    }
                    else
                    {
                        using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                        {
                            wr.WriteLine(lines);
                        }
                    }
                    lines = r.ReadLine();
                }
            }
            File.Delete(booklocation);
            File.Move(tempfilelocation, booklocation);
            using (StreamReader r = new StreamReader(idlocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (bookid != col[0] || !col[1].ToLower().Contains(title.ToLower()))
                    {
                        using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                        {
                            wr.WriteLine(lines);
                        }
                    }
                    lines = r.ReadLine();
                }
            }
            File.Delete(idlocation);
            File.Move(tempfilelocation, idlocation);
            File.SetAttributes(deletedinvenlocation, FileAttributes.Hidden);
            Process.Start(deletedinvenlocation);
            return deleted;
        }
        static public bool Delete_Software(string s_id, string userid, string title)
        {
            InventoryController wang = new InventoryController();
            bool deleted = false;
            using (StreamReader r = new StreamReader(softwarelocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (s_id == col[0] && col[1].ToLower().Contains(title.ToLower()))
                    {
                        string line = "";
                        using (StreamWriter wr = new StreamWriter(deletedinvenlocation, true))
                        {
                            line = userid + "|" +
                                    "Software" + "|" +
                                    wang.Searched_Software_by_ID(s_id).ID + "|" +
                                    wang.Searched_Software_by_ID(s_id).Title + "|" +
                                    wang.Searched_Software_by_ID(s_id).AuthorID + "|" +
                                    wang.Searched_Software_by_ID(s_id).Category + "|" +
                                    wang.Searched_Software_by_ID(s_id).PubID + "|" +
                                    wang.Searched_Software_by_ID(s_id).Pub_Year + "|" +
                                    wang.Searched_Software_by_ID(s_id).Software_Type + "|" +
                                    wang.Searched_Software_by_ID(s_id).UnitPrice.ToString();
                            wr.WriteLine(line);
                        }
                        deleted = true;
                    }
                    else
                    {
                        using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                        {
                            wr.WriteLine(lines);
                        }
                    }
                    lines = r.ReadLine();
                }
            }
            File.Delete(softwarelocation);
            File.Move(tempfilelocation, softwarelocation);
            using (StreamReader r = new StreamReader(idlocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (s_id != col[0] || !col[1].ToLower().Contains(title.ToLower()))
                    {
                        using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                        {
                            wr.WriteLine(lines);
                        }
                    }
                    lines = r.ReadLine();
                }
            }
            File.Delete(idlocation);
            File.Move(tempfilelocation, idlocation);
            File.SetAttributes(deletedinvenlocation, FileAttributes.Hidden);
            Process.Start(deletedinvenlocation);
            return deleted;
        }
        static public bool Delete_Publisher(string pubid, string userid, string pubname)
        {
            InventoryController wang = new InventoryController();
            bool deleted = false;
            using (StreamReader read = new StreamReader(publisherlocation))
            {
                string lines = read.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (pubid == col[0] && col[1].ToLower().Contains(pubname.ToLower()))
                    {
                        using (StreamWriter wr = new StreamWriter(deletedinvenlocation, true))
                        {
                            wr.WriteLine
                                (
                                    userid + "|" +
                                    "Publisher" + "|" +
                                    wang.Searched_publisher_by_id(pubid).PubID + "|" +
                                    wang.Searched_publisher_by_id(pubid).Pub_Name
                                );
                        }
                        deleted = true;
                    }
                    else
                    {
                        using (StreamWriter wr = new StreamWriter(tempfilelocation, true))
                        {
                            wr.WriteLine(lines);
                        }
                    }
                    lines = read.ReadLine();
                }
            }
            File.Delete(publisherlocation);
            File.Move(tempfilelocation, publisherlocation);
            File.SetAttributes(deletedinvenlocation, FileAttributes.Hidden);
            Process.Start(deletedinvenlocation);
            return deleted;
        }
        static public List<Book> Searched_Books_by_Title(string title)
        {
            List<Book> one = new List<Book>();
            Book a;
            using (StreamReader r = new StreamReader(booklocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[1].ToLower().Contains(title.ToLower()))
                    {
                        a = new Book();
                        a.ID = col[0];
                        a.Title = col[1];
                        a.AuthorID = col[2];
                        a.ISBN10 = col[3];
                        a.ISBN13 = col[4];
                        a.Category = col[5];
                        a.Type = col[6];
                        a.Pub_Year = col[7];
                        a.PubID = col[8];
                        a.UnitPrice = Convert.ToDouble(col[9]);
                        a.Quantity = Convert.ToInt32(col[10]);
                        one.Add(a);
                    }
                    lines = r.ReadLine();
                }
            }
            return one;
        }
        static public List<Software> Searched_Software_by_Title(string title)
        {
            List<Software> one = new List<Software>();
            Software a;
            using (StreamReader r = new StreamReader(softwarelocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[1].ToLower().Contains(title.ToLower()))
                    {
                        a = new Software();
                        a.ID = col[0];
                        a.Title = col[1];
                        a.AuthorID = col[2];
                        a.Category = col[3];
                        a.Type = col[4];
                        a.Pub_Year = col[5];
                        a.PubID = col[6];
                        a.UnitPrice = Convert.ToDouble(col[7]);
                        a.Software_Type = col[8];
                        a.Quantity = Convert.ToInt32(col[9]);
                        one.Add(a);
                    }
                    lines = r.ReadLine();
                }
            }
            return one;
        }
        static public List<Software> Searched_Software_by_Pub_Year(string year)
        {
            List<Software> one = new List<Software>();
            Software a;
            using (StreamReader r = new StreamReader(softwarelocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[5] == year.Trim())
                    {
                        a = new Software();
                        a.ID = col[0];
                        a.Title = col[1];
                        a.AuthorID = col[2];
                        a.Category = col[3];
                        a.Type = col[4];
                        a.Pub_Year = col[5];
                        a.PubID = col[6];
                        a.UnitPrice = Convert.ToDouble(col[7]);
                        a.Software_Type = col[8];
                        a.Quantity = Convert.ToInt32(col[9]);
                        one.Add(a);
                    }
                    lines = r.ReadLine();
                }
            }
            return one;
        }
        static public List<Book> Searched_Book_by_Pub_Year(string year)
        {
            List<Book> one = new List<Book>();
            Book a;
            using (StreamReader r = new StreamReader(booklocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[7] == year.Trim())
                    {
                        a = new Book();
                        a.ID = col[0];
                        a.Title = col[1];
                        a.AuthorID = col[2];
                        a.ISBN10 = col[3];
                        a.ISBN13 = col[4];
                        a.Category = col[5];
                        a.Type = col[6];
                        a.Pub_Year = col[7];
                        a.PubID = col[8];
                        a.UnitPrice = Convert.ToDouble(col[9]);
                        a.Quantity = Convert.ToInt32(col[10]);
                        one.Add(a);
                    }
                    lines = r.ReadLine();
                }
            }
            return one;
        }
        static public List<Book> Searched_Book_by_AuthorID(string aid)
        {
            List<Book> one = new List<Book>();
            Book a;
            using (StreamReader r = new StreamReader(booklocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[2].Contains(aid.Trim()))
                    {
                        a = new Book();
                        a.ID = col[0];
                        a.Title = col[1];
                        a.AuthorID = col[2];
                        a.Category = col[3];
                        a.Type = col[4];
                        a.Pub_Year = col[5];
                        a.PubID = col[6];
                        a.UnitPrice = Convert.ToDouble(col[7]);
                        a.ISBN10 = col[8];
                        a.ISBN13 = col[9];
                        a.Quantity = Convert.ToInt32(col[10]);
                        one.Add(a);
                    }
                    lines = r.ReadLine();
                }
            }
            return one;
        }
        static public List<Software> Searched_Software_by_AuthorID(string aid)
        {
            List<Software> one = new List<Software>();
            Software a;
            using (StreamReader r = new StreamReader(softwarelocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[2].Contains(aid.Trim()))
                    {
                        a = new Software();
                        a.ID = col[0];
                        a.Title = col[1];
                        a.AuthorID = col[2];
                        a.Category = col[3];
                        a.Type = col[4];
                        a.Pub_Year = col[5];
                        a.PubID = col[6];
                        a.UnitPrice = Convert.ToDouble(col[7]);
                        a.Software_Type = col[8];
                        a.Quantity = Convert.ToInt32(col[9]);
                        one.Add(a);
                    }
                    lines = r.ReadLine();
                }
            }
            return one;
        }
        static public List<Author> Searched_Authors_by_name (string name)
        {
            List<Author> one = new List<Author>();
            Author a;
            using (StreamReader r = new StreamReader(authorlocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    string names = col[1] + col[2];
                    if (names.ToLower().Contains(name.ToLower()))
                    {
                        a = new Author();
                        a.AuthorID = col[0];
                        a.FirstName = col[1];
                        a.LastName = col[2];
                        a.Email = col[3];
                        one.Add(a);
                    }
                    lines = r.ReadLine();
                }
            }
            return one;
        }
        static public List<Publisher> Searched_Publishers_by_name(string name)
        {
            List<Publisher> one = new List<Publisher>();
            Publisher a;
            using (StreamReader r = new StreamReader(publisherlocation))
            {
                string lines = r.ReadLine();
                while (lines != null)
                {
                    string[] col = lines.Split('|');
                    if (col[1].ToLower().Contains(name.ToLower()))
                    {
                        a = new Publisher();
                        a.PubID = col[0];
                        a.Pub_Name = col[1];
                        one.Add(a);
                    }
                    lines = r.ReadLine();
                }
            }
            return one;
        }
        static public bool Is_It_a_Book(string id)
        {
            bool book = false;

            using (StreamReader re = new StreamReader(booklocation))
            {
                string lines = re.ReadLine();
                while(lines != null)
                {
                    string[] col = lines.Split('|');
                    if(col[0] == id)
                    {
                        book = true;
                        break;
                    }
                    lines = re.ReadLine();
                }
            }
            return book;
        }

    }
}
