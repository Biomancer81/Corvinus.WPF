// <copyright file="MethodBindingExtension.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Interactivity.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Markup;
    using Corvinus.WPF.Interactivity.Dependency;

    /// <summary>
    /// MethodBindingExtension class.
    /// </summary>
    public class MethodBindingExtension : MarkupExtension
    {
        private static readonly List<DependencyProperty> StorageProperties = new List<DependencyProperty>();

        private readonly object[] arguments;
        private readonly List<DependencyProperty> argumentProperties = new List<DependencyProperty>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodBindingExtension"/> class.
        /// </summary>
        /// <param name="method">Method name.</param>
        public MethodBindingExtension(object method)
            : this(new[] { method })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodBindingExtension"/> class.
        /// </summary>
        /// <param name="arg0">Method Name.</param>
        /// <param name="arg1">Arguement One.</param>
        public MethodBindingExtension(object arg0, object arg1)
            : this(new[] { arg0, arg1 })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodBindingExtension"/> class.
        /// </summary>
        /// <param name="arg0">Method Name.</param>
        /// <param name="arg1">Arguement One.</param>
        /// <param name="arg2">Arguement Two.</param>
        public MethodBindingExtension(object arg0, object arg1, object arg2)
            : this(new[] { arg0, arg1, arg2 })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodBindingExtension"/> class.
        /// </summary>
        /// <param name="arg0">Method Name.</param>
        /// <param name="arg1">Arguement One.</param>
        /// <param name="arg2">Arguement Two.</param>
        /// <param name="arg3">Arguement Three.</param>
        public MethodBindingExtension(object arg0, object arg1, object arg2, object arg3)
            : this(new[] { arg0, arg1, arg2, arg3 })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodBindingExtension"/> class.
        /// </summary>
        /// <param name="arg0">Method Name.</param>
        /// <param name="arg1">Arguement One.</param>
        /// <param name="arg2">Arguement Two.</param>
        /// <param name="arg3">Arguement Three.</param>
        /// <param name="arg4">Arguement Four.</param>
        public MethodBindingExtension(object arg0, object arg1, object arg2, object arg3, object arg4)
            : this(new[] { arg0, arg1, arg2, arg3, arg4 })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodBindingExtension"/> class.
        /// </summary>
        /// <param name="arg0">Method Name.</param>
        /// <param name="arg1">Arguement One.</param>
        /// <param name="arg2">Arguement Two.</param>
        /// <param name="arg3">Arguement Three.</param>
        /// <param name="arg4">Arguement Four.</param>
        /// <param name="arg5">Arguement Five.</param>
        public MethodBindingExtension(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5)
            : this(new[] { arg0, arg1, arg2, arg3, arg4, arg5 })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodBindingExtension"/> class.
        /// </summary>
        /// <param name="arg0">Method Name.</param>
        /// <param name="arg1">Arguement One.</param>
        /// <param name="arg2">Arguement Two.</param>
        /// <param name="arg3">Arguement Three.</param>
        /// <param name="arg4">Arguement Four.</param>
        /// <param name="arg5">Arguement Five.</param>
        /// <param name="arg6">Arguement Six.</param>
        public MethodBindingExtension(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6)
            : this(new[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodBindingExtension"/> class.
        /// </summary>
        /// <param name="arg0">Method Name.</param>
        /// <param name="arg1">Arguement One.</param>
        /// <param name="arg2">Arguement Two.</param>
        /// <param name="arg3">Arguement Three.</param>
        /// <param name="arg4">Arguement Four.</param>
        /// <param name="arg5">Arguement Five.</param>
        /// <param name="arg6">Arguement Six.</param>
        /// <param name="arg7">Arguement Seven.</param>
        public MethodBindingExtension(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7)
            : this(new[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodBindingExtension"/> class.
        /// </summary>
        /// <param name="arg0">Method Name.</param>
        /// <param name="arg1">Arguement One.</param>
        /// <param name="arg2">Arguement Two.</param>
        /// <param name="arg3">Arguement Three.</param>
        /// <param name="arg4">Arguement Four.</param>
        /// <param name="arg5">Arguement Five.</param>
        /// <param name="arg6">Arguement Six.</param>
        /// <param name="arg7">Arguement Seven.</param>
        /// <param name="arg8">Arguement Eight.</param>
        public MethodBindingExtension(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8)
            : this(new[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodBindingExtension"/> class.
        /// </summary>
        /// <param name="args">object array of arguements.</param>
        private MethodBindingExtension(object[] args)
        {
            this.arguments = args;
        }

        /// <summary>
        /// Provides a return value from the method through the IServiceProvider instance.
        /// </summary>
        /// <param name="serviceProvider">Service Provider instance.</param>
        /// <returns>Return value for method.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValueTarget = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
            Type eventHandlerType = null;

            if (provideValueTarget.TargetProperty is EventInfo eventInfo)
            {
                eventHandlerType = eventInfo.EventHandlerType;
            }
            else if (provideValueTarget.TargetProperty is MethodInfo methodInfo)
            {
                var parameters = methodInfo.GetParameters();

                if (parameters.Length == 2)
                {
                    eventHandlerType = parameters[1].ParameterType;
                }
            }

            if (!(provideValueTarget.TargetObject is FrameworkElement target) || eventHandlerType == null)
            {
                return this;
            }

            foreach (object argument in this.arguments)
            {
                var argumentProperty = this.SetUnusedStorageProperty(target, argument);
                this.argumentProperties.Add(argumentProperty);
            }

            return this.CreateEventHandler(target, eventHandlerType);
        }

        private Delegate CreateEventHandler(FrameworkElement element, Type eventHandlerType)
        {
            EventHandler handler = (sender, eventArgs) =>
            {
                object arg0 = element.GetValue(this.argumentProperties[0]);

                if (arg0 == null)
                {
                    Debug.WriteLine("[MethodBinding] First method binding argument is required and cannot resolve to null - method name or method target expected.");
                    return;
                }

                int methodArgsStart;
                object methodTarget;

                if (arg0 is string methodName)
                {
                    methodTarget = element.DataContext;
                    methodArgsStart = 1;
                }
                else if (this.argumentProperties.Count >= 2)
                {
                    methodTarget = arg0;
                    methodArgsStart = 2;

                    object arg1 = element.GetValue(this.argumentProperties[1]);

                    if (arg1 == null)
                    {
                        Debug.WriteLine($"[MethodBinding] First argument resolved as a method target object of type '{methodTarget.GetType()}', second argument must resolve to a method name and cannot resolve to null.");
                        return;
                    }

                    methodName = arg1 as string;

                    if (methodName == null)
                    {
                        Debug.WriteLine($"[MethodBinding] First argument resolved as a method target object of type '{methodTarget.GetType()}', second argument (method name) must resolve to a '{typeof(string)}' (actual type: '{arg1.GetType()}').");
                        return;
                    }
                }
                else
                {
                    Debug.WriteLine($"[MethodBinding] Method name must resolve to a '{typeof(string)}' (actual type: '{arg0.GetType()}').");
                    return;
                }

                var arguments = new object[this.argumentProperties.Count - methodArgsStart];

                for (int i = methodArgsStart; i < this.argumentProperties.Count; i++)
                {
                    object argValue = element.GetValue(this.argumentProperties[i]);

                    if (argValue is EventSenderExtension)
                    {
                        argValue = sender;
                    }
                    else if (argValue is EventArgsExtension eventArgsEx)
                    {
                        argValue = eventArgsEx.GetArgumentValue(eventArgs, element.Language);
                    }

                    arguments[i - methodArgsStart] = argValue;
                }

                var methodTargetType = methodTarget.GetType();

                try
                {
                    methodTargetType.InvokeMember(methodName, BindingFlags.InvokeMethod, null, methodTarget, arguments);
                    return;
                }
                catch (MissingMethodException)
                {
                }

                var method = methodTargetType.GetMethods().SingleOrDefault(m => m.Name == methodName && m.GetParameters().Length == arguments.Length);

                if (method != null)
                {
                    var parameters = method.GetParameters();

                    for (int i = 0; i < this.arguments.Length; i++)
                    {
                        if (arguments[i] == null)
                        {
                            if (parameters[i].ParameterType.IsValueType)
                            {
                                method = null;
                                break;
                            }
                        }
                        else if (this.arguments[i] is string && parameters[i].ParameterType != typeof(string))
                        {
                            arguments[i] = TypeDescriptor.GetConverter(parameters[i].ParameterType).ConvertFromString((string)this.arguments[i]);
                        }
                        else if (!parameters[i].ParameterType.IsInstanceOfType(arguments[i]))
                        {
                            method = null;
                            break;
                        }
                    }

                    method?.Invoke(methodTarget, arguments);
                }

                if (method == null)
                {
                    Debug.WriteLine($"[MethodBinding] Could not find a method '{methodName}' on target type '{methodTargetType}' that accepts the parameters provided.");
                }
            };

            return Delegate.CreateDelegate(eventHandlerType, handler.Target, handler.Method);
        }

        private DependencyProperty SetUnusedStorageProperty(DependencyObject obj, object value)
        {
            var property = StorageProperties.FirstOrDefault(p => obj.ReadLocalValue(p) == DependencyProperty.UnsetValue);

            if (property == null)
            {
                property = DependencyProperty.RegisterAttached("Storage" + StorageProperties.Count, typeof(object), typeof(MethodBindingExtension), new PropertyMetadata());
                StorageProperties.Add(property);
            }

            MarkupExtension markupExtension = value as MarkupExtension;

            if (markupExtension != null)
            {
                object resolvedValue = markupExtension.ProvideValue(new ServiceProvider(obj, property));
                obj.SetValue(property, resolvedValue);
            }
            else
            {
                obj.SetValue(property, value);
            }

            return property;
        }
    }
}
