using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Class to handle reading and writing of data to database
namespace DataLibrary
{
    public class DataManager
    {
        //Database created through ADO
        private UserAppDataEntities db = new UserAppDataEntities();

        //Remove all entries from database
        public void ClearDatabase()
        {
            foreach (Table1 data in db.Table1)
            {
                db.Table1.Remove(data);
            }
            db.SaveChanges();
        }

        //Get all entries from database
        public List<Table1> GetDataList()
        {
            return db.Table1.ToList();
        }

        //Update entries to database
        public void UpdateDatabase(List<string> userList)
        {
            int count = userList.Count;
            for (int i = 0; i < count; i = i + 3)
            {
                Table1 newentry = db.Table1.Create();
                newentry.EmailAddress = userList[i];
                newentry.FirstName = userList[i + 1];
                newentry.LastName = userList[i + 2];
                db.Table1.Add(newentry);
            }
            db.SaveChanges();
        }
    }
}
