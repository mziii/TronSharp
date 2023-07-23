using System.Collections.Concurrent;
using TronSharp.ABI.FunctionEncoding.Attributes;
using TronSharp.ABI.Model;

namespace TronSharp.ABI
{
    public static class ABITypedRegistry
    {
        private static ConcurrentDictionary<Type, FunctionABI> _functionAbiRegistry = new();
        private static AttributesToABIExtractor _abiExtractor = new();

        public static FunctionABI GetFunctionABI<TFunctionMessage>()
        {
            return GetFunctionABI(typeof(TFunctionMessage));
        }

        public static FunctionABI GetFunctionABI(Type functionABIType)
        {
            if (!_functionAbiRegistry.ContainsKey(functionABIType))
            {
                var functionAbi = _abiExtractor.ExtractFunctionABI(functionABIType);
                _functionAbiRegistry[functionABIType] = functionAbi ?? throw new ArgumentException(functionABIType.ToString() + " is not a valid Function Type");
            }
            return _functionAbiRegistry[functionABIType];
        }
    }
}
