﻿// Copyright 2007-2014 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit
{
    using System;
    using System.Runtime.Serialization;


    [Serializable]
    public class ConsumerMessageException :
        ConsumerException
    {
        public ConsumerMessageException(string message)
            : base(message)
        {
        }

        public ConsumerMessageException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if !NETCORE
        protected ConsumerMessageException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif

        public ConsumerMessageException()
        {
        }
    }


    [Serializable]
    public class ConsumerException :
        MassTransitException
    {
        public ConsumerException()
        {
        }

        public ConsumerException(string message)
            : base(message)
        {
        }

        public ConsumerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if !NETCORE
        protected ConsumerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}