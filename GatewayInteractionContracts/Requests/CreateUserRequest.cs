using ApnaKhata.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayInteractionContracts.Requests
{
    public class CreateUserRequest
    {
        public User User { get; set; }
    }
}
