using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsWPFTestLibrary
{
    public class TestMethodClass
    {
        TrainsDBEntities db = new TrainsDBEntities();

        public bool CreateBuyer(string telnum, string fname, string lname, string email, string password)
        {
            int counter = 0;
            Buyer buyer = new Buyer();
            buyer.TelNum = telnum;
            buyer.FirstName = fname;
            buyer.LastName = lname;
            buyer.Email = email;
            buyer.Password = password;
            db.Buyer.Add(buyer);
            db.SaveChanges();
            foreach (Buyer _buyer in db.Buyer)
            {
                if (_buyer.TelNum == telnum) counter++;
            }
            if (counter == 1) return true;
            else return false;
        }

        public bool CreateAdmin(string login, string password)
        {
            int counter = 0;
            Employee employee = new Employee();
            employee.Login = login;
            employee.Password = password;
            db.Employee.Add(employee);
            db.SaveChanges();
            foreach (Employee _employee in db.Employee)
            {
                if (_employee.Login == login) counter++;
            }
            if (counter == 1) return true;
            else return false;
        }
        public string ReadBuyerEmail()
        {
            string email = "";
            foreach (Buyer _buyer in db.Buyer)
            {
                if (_buyer.TelNum == "001")
                {
                    email = _buyer.Email;
                    break;
                }
            }
            return email;
        }

        public string UpdateBuyerEmail(string nEmail)
        {
            Buyer buyer = new Buyer();
            foreach (Buyer _buyer in db.Buyer)
            {
                if (_buyer.Email == "test@t.ru")
                {
                    buyer = _buyer;
                    break;
                }
            }
            buyer.Email = nEmail;
            db.SaveChanges();
            string email = "";
            foreach (Buyer _buyer in db.Buyer)
            {
                if (_buyer.TelNum == "001")
                {
                    email = _buyer.Email;
                    break;
                }
            }
            return email;
        }

        public bool DeleteBuyer(string telnum)
        {
            Buyer buyer = new Buyer();
            foreach (Buyer _buyer in db.Buyer)
            {
                if (_buyer.TelNum == telnum)
                {
                    buyer = _buyer;
                    break;
                }
            }
            db.Buyer.Remove(buyer);
            db.SaveChanges();
            int counter = 0;
            foreach (Buyer _buyer in db.Buyer)
            {
                if (_buyer.TelNum == telnum) counter++;
            }
            if (counter == 0) return true;
            else return false;
        }
    }
}
