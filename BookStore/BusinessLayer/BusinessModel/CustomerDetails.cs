using System;

namespace BookStore.BusinessLayer.BusinessModel
{
    /// <summary>
    /// Customer Details Class
    /// </summary>
    public class CustomerDetails
    {
        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// DOB
        /// </summary>
        public DateTime DOB { get; set; }
        /// <summary>
        /// Member
        /// </summary>
        public bool Member { get; set; }
        /// <summary>
        /// JoiningYear
        /// </summary>
        public int JoiningYear { get; set; }

    }
}
