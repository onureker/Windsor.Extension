using System;
using System.Collections.Generic;

namespace Windsor.ExtensionTests.Registration.Decorator
{
    public class ExecutionRegistry
    {
        private readonly IDictionary<Guid, Stack<object>> executionStacks;

        public ExecutionRegistry()
        {
            executionStacks = new Dictionary<Guid, Stack<object>>();
        }

        public void Push(Guid executionId, object instance)
        {
            var executionStack = GetStack(executionId);
            executionStack.Push(instance);
        }

        public object Pop(Guid executionId)
        {
            var executionStack = GetStack(executionId);
            var result = executionStack.Pop();
            return result;
        }

        public object Peek(Guid executionId)
        {
            var executionStack = GetStack(executionId);
            var result = executionStack.Peek();
            return result;
        }

        private Stack<object> GetStack(Guid executionId)
        {
            if (!executionStacks.ContainsKey(executionId))
            {
                executionStacks.Add(executionId, new Stack<object>());
            }

            return executionStacks[executionId];
        }

    }
}