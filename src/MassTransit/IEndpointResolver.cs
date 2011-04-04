// Copyright 2007-2008 The Apache Software Foundation.
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

	/// <summary>
	/// The endpoint factory methods used to retrieve objects implementing IEndpoint from Uris
	/// </summary>
	public interface IEndpointResolver :
		IDisposable
	{
		/// <summary>
		/// Returns an IEndpoint for the Uri string specified. If the endpoint has not yet been created,
		/// the factory will attempt to create an endpoint for the Uri string.
		/// </summary>
		/// <param name="uriString">The Uri string to resolve to an endpoint (will be checked for valid Uri syntax)</param>
		/// <returns>An IEndpoint instance</returns>
		IEndpoint GetEndpoint(string uriString);

		/// <summary>
		/// Returns an IEndpoint for the Uri specified. If the endpoint has not yet been created,
		/// the factory will attempt to create an endpoint for the Uri.
		/// </summary>
		/// <param name="uri">The Uri to resolve to an endpoint</param>
		/// <returns>An IEndpoint instance</returns>
		IEndpoint GetEndpoint(Uri uri);
	}
}