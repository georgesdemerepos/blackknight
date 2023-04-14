using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {

        private readonly Dictionary<Type, Type> _bindings;

        public Container()
        {
            _bindings = new Dictionary<Type, Type>();
        }

        public void Bind(Type interfaceType, Type implementationType)
        {
            _bindings[interfaceType] = implementationType;
        }

        public T Get<T>()
        {
            Type implementationType = _bindings[typeof(T)];
            return (T)Activator.CreateInstance(implementationType);
        }
    }
}