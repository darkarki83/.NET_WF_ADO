using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    public class MyUserContextInitializer : CreateDatabaseIfNotExists<MyUserContext>
    {
        protected override void Seed(MyUserContext context)
        {
            var users = new User[]
            {
                new User{ Login = "artem", Password =  "art1234" },
                new User{ Login = "arik", Password =  "ar1234" }
            };
            Array.ForEach(users, user => context.Users.Add(user));

            var informations = new Information[]
            {
                new Information {Adress = "zabolotnogo 23", Phone = "+972547285882", Admin = true, User = users[0]},
                new Information {Adress = "ole gardom 52", Phone = "+972545522552", Admin = false, User = users[1]}
            };
            foreach (var information in informations)
                context.Informations.Add(information);

            base.Seed(context);
        }




    }
}
