using System;
using System.Collections.Generic;

namespace Windsor.Extension.Tests.Registration.Decorator.Components
{
    public class ExecutionStack
    {
        private readonly IDictionary<Guid, Stack<object>> executionStacks;

        public ExecutionStack()
        {
            executionStacks = new Dictionary<Guid, Stack<object>>();
        }

        public void PushInstance(Guid executionId, object instance)
        {
            var executionStack = GetStack(executionId);
            executionStack.Push(instance);
        }

        public object PopInstance(Guid executionId)
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