using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.DAL
{
    [Table("ClientTable")]
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       [Key]
        public int ClientId {set; get; }
        public string FirstName {set; get;}
        public string LastName {set; get;}
        public string Dob { set; get;}
        public ICollection<ClientAddress> ClientAddress { get;set; }
    }
}