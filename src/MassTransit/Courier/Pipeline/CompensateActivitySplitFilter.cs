﻿// Copyright 2007-2016 Chris Patterson, Dru Sellers, Travis Smith, et. al.
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
namespace MassTransit.Courier.Pipeline
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using GreenPipes;
    using Util;


    /// <summary>
    /// Splits a context item off the pipe and carries it out-of-band to be merged
    /// once the next filter has completed
    /// </summary>
    /// <typeparam name="TActivity"></typeparam>
    /// <typeparam name="TLog"></typeparam>
    public class CompensateActivitySplitFilter<TActivity, TLog> :
        IFilter<CompensateActivityContext<TActivity, TLog>>
        where TActivity : class, CompensateActivity<TLog>
        where TLog : class
    {
        readonly IFilter<CompensateActivityContext<TLog>> _next;

        public CompensateActivitySplitFilter(IFilter<CompensateActivityContext<TLog>> next)
        {
            _next = next;
        }

        void IProbeSite.Probe(ProbeContext context)
        {
            var scope = context.CreateFilterScope("split");
            scope.Set(new
            {
                ActivityType = TypeMetadataCache<TActivity>.ShortName
            });

            _next.Probe(scope);
        }

        [DebuggerNonUserCode]
        public Task Send(CompensateActivityContext<TActivity, TLog> context, IPipe<CompensateActivityContext<TActivity, TLog>> next)
        {
            var mergePipe = new CompensateActivityMergePipe<TActivity, TLog>(next);

            return _next.Send(context, mergePipe);
        }
    }
}