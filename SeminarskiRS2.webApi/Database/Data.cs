using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRS2.webApi.Database
{
    public class Data
    {
        public static void Seed(_170120Context context)
        {
            context.Database.Migrate();
        }
    }
}
