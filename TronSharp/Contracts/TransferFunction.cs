﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TronSharp.ABI.FunctionEncoding.Attributes;

namespace TronSharp.Contract
{
    [Function("transfer", "bool")]
    public class TransferFunction : FunctionMessage
    {
        [Parameter("address", "_to", 1)]
        public string To { get; set; }

        [Parameter("uint256", "_value", 2)]
        public BigInteger TokenAmount { get; set; }
    }
}
