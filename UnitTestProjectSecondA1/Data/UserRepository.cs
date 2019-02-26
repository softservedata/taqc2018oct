using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondA1.Data
{
    public sealed class UserRepository
    {
        private volatile static UserRepository instance;
        private static object lockingObject = new object();

        private UserRepository()
        {
        }

        public static UserRepository Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new UserRepository();
                    }
                }
            }
            return instance;
        }

        public IUser Admin()
        {
            return User.Get()
               .SetName("admin")
               .SetPassword("qwerty")
               .SetAddress("myaddres")
               .SetEmail("myEmail")
               .Build();
        }

        public IUser NewUser()
        {
            return User.Get()
               .SetName("ivan")
               .SetPassword("qwerty")
               .SetAddress("myaddres")
               .SetEmail("myEmail")
               .Build();
        }

        //public IList<IUser> FromCsv()
        //{
        //    return FromCsv("ExistUsers.csv");
        //}

        //public IList<IUser> FromCsv(string filename)
        //{
        //    return User.GetAllUsers(new CSVReader(filename));
        //}

        //public IList<IUser> FromExcel()
        //{
        //    return FromExcel("ExistUsers.xlsx");
        //}

        //public IList<IUser> FromExcel(string filename)
        //{
        //    return User.GetAllUsers(new ExcelReader(filename));
        //}

    }
}
