using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Added successful";
        public static string Updated = "Updated successful";
        public static string Deleted = "Deleted successful";
        public static string Read = "Read successful";
        public static string CarError = "Daily Price must be greater than 0 and description must be greater than 2 characters.";
        public static string BrandError = "Brand name is 2 characters in small pieces because the transaction failed.";
        public static string RentalError = "The car was not delivered";
        public static string CarImageAdded="Car Images Added";
    }
} 
