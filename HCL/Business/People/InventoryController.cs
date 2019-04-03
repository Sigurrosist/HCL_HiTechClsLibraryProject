using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCL.DataAccess;
using HCL.Business.People;
using HCL.Business.Company;
using HCL.Business.Items;

namespace HCL.Business.People
{
    public class InventoryController : User
    {
        public InventoryController() : base()
        {        }
        public void Save_new_author(Author newone)
        {
            InvenControl_DA.Save_New_Author(newone);
        } 
        public List<Author> Listed_authors ()
        {
            return InvenControl_DA.List_Authors();
        }
        public void Save_new_publisher(Publisher newone)
        {
            InvenControl_DA.Save_New_Publisher(newone);
        }
        public List<Publisher> Listed_publishers()
        {
            return InvenControl_DA.List_Publishers();
        }
        public string Author_id_generator()
        {
            return InvenControl_DA.Author_ID_Generator();
        }
        public void Update_author(Author upd)
        {
            InvenControl_DA.Update_Author(upd);
        }
        public Author Searched_author_by_id(string id)
        {
            return InvenControl_DA.Searched_Author_by_ID(id);
        }
        public string Publisher_id_generator()
        {
            return InvenControl_DA.Publisher_ID_Generator();
        }
        public Publisher Searched_publisher_by_id(string id)
        {
            return InvenControl_DA.Searched_Publisher_by_ID(id);
        }
        public void Update_publisher(Publisher upd)
        {
            InvenControl_DA.Update_publisher(upd);
        }
        public void Save_Inventory_Info(string id, string quantity)
        {
            InvenControl_DA.Save_Inventory(id, quantity);
        }
        public void Update_Inventory_Info(string id, string quantity)
        {
            InvenControl_DA.Update_Inventory(id, quantity);
        }
        public string Item_ID_Generator()
        {
            return InvenControl_DA.Item_ID_Generator();
        }
        public void Save_New_Book(Book a)
        {
            InvenControl_DA.Save_New_Book(a);
        }
        public List<Book> Listed_Books ()
        {
            return InvenControl_DA.Listed_Books();
        }
        public void Save_New_Software(Software a)
        {
            InvenControl_DA.Save_New_Software(a);
        }
        public List<Software> Listed_Software()
        {
            return InvenControl_DA.Listed_Softwares();
        }
        public Book Searched_Book_by_ID(string id)
        {
            return InvenControl_DA.Searched_Book_by_ID(id);
        }
        public Software Searched_Software_by_ID (string id)
        {
            return InvenControl_DA.Searched_Software_by_ID(id);
        }
        public void Update_a_Book(Book a)
        {
            InvenControl_DA.Update_a_Book(a);
        }
        public void Update_a_Software(Software a)
        {
            InvenControl_DA.Update_a_Software(a);
        }
        public bool Delete_Author(string authorid, string userid, string fname)
        {
            return InvenControl_DA.Delete_Author(authorid, userid, fname);
        }
        public bool Delete_Book(string bookid, string userid, string title)
        {
            return InvenControl_DA.Delete_Book(bookid, userid, title);
        }
        public bool Delete_Software(string sid, string userid, string title)
        {
            return InvenControl_DA.Delete_Software(sid, userid, title);
        }
        public bool Delete_Publisher(string pubid, string userid, string fname)
        {
            return InvenControl_DA.Delete_Publisher(pubid, userid, fname);
        }
        public List<Book> Searched_Books_by_Title(string title)
        {
            return InvenControl_DA.Searched_Books_by_Title(title);
        }
        public List<Software> Searched_Software_by_Title(string title)
        {
            return InvenControl_DA.Searched_Software_by_Title(title);
        }
        public List<Book> Searched_Books_by_PubYear(string year)
        {
            return InvenControl_DA.Searched_Book_by_Pub_Year(year);
        }
        public List<Software> Searched_Software_by_PubYear(string year)
        {
            return InvenControl_DA.Searched_Software_by_Pub_Year(year);
        }
        public List<Book> Searched_Book_by_AuthorID(string aid)
        {
            return InvenControl_DA.Searched_Book_by_AuthorID(aid);
        }
        public List<Software> Searched_Software_by_AuthorID(string aid)
        {
            return InvenControl_DA.Searched_Software_by_AuthorID(aid);
        }
        public List<Author> Searched_Authors_by_Name(string name)
        {
            return InvenControl_DA.Searched_Authors_by_name(name);
        }
        public List<Publisher> Searched_Publishers_by_Name(string name)
        {
            return InvenControl_DA.Searched_Publishers_by_name(name);
        }
        public bool Is_It_a_Book (string id)
        {
            return InvenControl_DA.Is_It_a_Book(id);
        }  
            
            
            
            //a.Void Save_Item_Information(Item item)
        //b.Void Update_Item_Information(int iid)
        //c.Void Delete_Item_Information(Item item)
        //d.List<Item> List_Item_Information()
        //e.List<Item> Searched_Items_By_Title(string title)
        //f.List<Item> Searched_Item_By_Type(string type)
        //g.Item Searched_Software_By_ID(int iid)
        //h.Item Searched_Books_By_ISBN(string isbn)
        //i.Item Searched_Item_By_Author(string author)

        // save new book
        //          - publisher select (if there is not then create a new publisher)
        //          - author select (if there is not then create a new author)
        //          - isbn validation
        //          - 
    }
}
