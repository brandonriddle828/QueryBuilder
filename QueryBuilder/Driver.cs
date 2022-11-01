using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder
{
    public class Driver
    {
        static void Main(String[] args)
        {
            List<Author> authors = new List<Author>();
            //QueryBuilder queryBuilder = new QueryBuilder();

            Author a1 = new Author(57,"Billy","Bob");
            Author a2 = new Author(88, "James", "Patterson");
            Author a3 = new Author(32, "Bob", "Ross");
            Author a4 = new Author(12, "Stephen", "King");


            using (var queryBuilder = new QueryBuilder())
            {

                /*
                queryBuilder.Create(a1);
                queryBuilder.Create(a2);
                queryBuilder.Create(a3);
                */
                
                // Read All Method-----------------------------------------------------------

                Console.WriteLine();
                Console.WriteLine("Read all Method shows...");
                Console.WriteLine();
                var readAllData = queryBuilder.ReadAll<Author>();

                foreach (var item in readAllData)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("---------------------------------------");


                

                // Create Method -----------------------------------------------------------------

                queryBuilder.Create(a4);

                Console.WriteLine();
                Console.WriteLine("After creating the Author the new Author DB is...");
                Console.WriteLine();

                var newReadAll = queryBuilder.ReadAll<Author>();
                foreach (var item in newReadAll)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("---------------------------------------");


                //Read Single Method-------------------------------------------------------------------------
                Console.WriteLine();
                Console.WriteLine("Single Read Method shows...");
                Console.WriteLine();
                var readSingleData = queryBuilder.Read<Author>(57);
                Console.WriteLine(readSingleData);

                Console.WriteLine("---------------------------------------");




                // Update Method --------------------------------------------------------------------------


                queryBuilder.Update(a1);

                newReadAll = queryBuilder.ReadAll<Author>();
                foreach (var item in newReadAll)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("---------------------------------------");






                // Delete Method -----------------------------------------------------------------------

                Console.WriteLine($"Here we are going to delete {a2} from the db");

                queryBuilder.Delete(a2);
                newReadAll = queryBuilder.ReadAll<Author>();
                foreach (var item in newReadAll)
                {
                    Console.WriteLine(item);
                }




                

                /*
                // Delete All Method------------------------------


                queryBuilder.DeleteAll<Author>();
                var newReadAll = queryBuilder.ReadAll<Author>();
                foreach (var item in newReadAll)
                {
                    Console.WriteLine(item);
                }

               */
                

            }
        }
    }
}
