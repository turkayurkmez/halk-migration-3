using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewInCsharp
{
    public record struct Employee(string Name, string LastName, int? Age);

}
