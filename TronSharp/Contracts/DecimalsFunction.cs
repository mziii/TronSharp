using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TronSharp.ABI.FunctionEncoding.Attributes;

namespace TronSharp.Contract
{
    [Function("decimals", "uint8")]
    public class DecimalsFunction : FunctionMessage
    {
    }
}
