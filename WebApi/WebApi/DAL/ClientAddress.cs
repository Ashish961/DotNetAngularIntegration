using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.DAL
{
    [Table("Client_AddressTable")]
    public class ClientAddress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AddressId { set; get; }
        public string Address {set; get; }
     
        public Client Client { get; set; }
        
    }
}